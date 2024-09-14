using Application.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using Shared;
using Shared.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Interface.EmailService;

public class LoginService : ILoginService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<LoginService> _logger;
    private readonly ApplicationDBContext _dbContext;
    private readonly IEmailService _emailService;

    public LoginService(UserManager<User> userManager, IConfiguration configuration, ILogger<LoginService> logger, ApplicationDBContext dBContext, IEmailService emailService)
    {
        _userManager = userManager;
        _configuration = configuration;
        _logger = logger;
        _dbContext = dBContext;
        _emailService = emailService;
    }

    public async Task<string> InitiateLoginAsync(LoginDto loginDto)
    {
        try
        {
            if (loginDto == null || string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.Password))
            {
                _logger.LogWarning("Invalid login request with email: {Email}", loginDto?.Email);
                throw new ArgumentException("Invalid login request.");
            }

            var normalizedEmail = loginDto.Email.Trim().Normalize().ToUpperInvariant();
            _logger.LogInformation("Attempting to find user with normalized email: {Email}", normalizedEmail);

            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.NormalizedUserName == normalizedEmail);
            if (user == null)
            {
                _logger.LogWarning("User with normalized email {Email} not found.", normalizedEmail);
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            _logger.LogInformation("User with email {Email} found. Checking password.", loginDto.Email);

            bool isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
            {
                _logger.LogWarning("Invalid password attempt for user with email {Email}.", loginDto.Email);
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            _logger.LogInformation("User with email {Email} authenticated successfully. Sending OTP.", loginDto.Email);

            // Generate and send OTP
            var otp = new Random().Next(1000, 9999);
            user.OTP = otp;
            user.OtpExpiry = DateTime.UtcNow.AddMinutes(10);
            await _dbContext.SaveChangesAsync();

            var emailSent = await _emailService.SendEmail(user, otp);
            if (!emailSent)
            {
                _logger.LogError("Failed to send OTP email to {Email}.", loginDto.Email);
                return "Faied ro send OTP mail";
            }

            return "OTP sent successfully. Please verify to complete login.";
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in InitiateLoginAsync.");
            return "An error occured";
        }
    }

    public async Task<object> VerifyOtpAndCompleteLoginAsync(string email, string otp)
    {
        try
        {
            var normalizedEmail = email.Trim().Normalize().ToUpperInvariant();
            var user = await _userManager.Users.SingleOrDefaultAsync(u => u.NormalizedUserName == normalizedEmail);
            if (user == null)
            {
                _logger.LogWarning("User with email {Email} not found during OTP verification.", email);
                throw new UnauthorizedAccessException("Invalid email.");
            }

            if (user.OTP.ToString() != otp || user.OtpExpiry < DateTime.UtcNow)
            {
                _logger.LogWarning("Invalid or expired OTP for user with email {Email}.", email);
                throw new UnauthorizedAccessException("Invalid or expired OTP.");
            }

            _logger.LogInformation("OTP verified successfully for user with email {Email}.", email);

            // Clear OTP after successful verification
            user.OTP = 0;
            await _dbContext.SaveChangesAsync();

            var restaurant = await _dbContext.restaurants.SingleOrDefaultAsync(r => r.UserId == user.Id);
            var userRoles = await _userManager.GetRolesAsync(user);

            var token = GenerateJwtToken(user, userRoles);

            // Check if the user is a super admin
            if (userRoles.Contains("SuperAdmin"))
            {
                // Return only the token, user ID, and email for super admins
                var simplifiedResponse = new
                {
                    Token = token,
                    UserId = user.Id,
                    Email = user.Email,
                    Role = "SuperAdmin"
                };
                return simplifiedResponse;
            }
            else
            {
                // Return full UserDto for other users
                var loginResponse = new UserDto
                {
                    Id = user.Id,
                    RestaurantId = restaurant?.Id ?? 0,
                    Email = user.Email,
                    Role = user.Role,
                    JwtToken = token
                };
                return loginResponse;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred in VerifyOtpAndCompleteLoginAsync.");
            throw;
        }
    }

    private string GenerateJwtToken(User user, IList<string> roles)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireMinutes"])),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}
