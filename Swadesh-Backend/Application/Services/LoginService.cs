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

public class LoginService : ILoginService
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;
    private readonly ILogger<LoginService> _logger;
    private readonly ApplicationDBContext _dbContext;

    public LoginService(UserManager<User> userManager, IConfiguration configuration, ILogger<LoginService> logger, ApplicationDBContext dBContext)
    {
        _userManager = userManager;
        _configuration = configuration;
        _logger = logger;
        _dbContext = dBContext;
    }

    public async Task<object> AuthenticateUserAsync(LoginDto loginDto)
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

            _logger.LogInformation("User with email {Email} authenticated successfully.", loginDto.Email);

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
                    Email = user.Email
                };
                return simplifiedResponse;
            }
            else
            {
                // Return full UserDto for other users
                var loginResponse = new UserDto
                {
                    Id = user.Id,
                    RestaurantId = restaurant?.Id ?? 0, // Handle cases where restaurant might be null
                    Email = user.Email,
                    Role = user.Role, // Assuming only one role
                    JwtToken = token
                };
                return loginResponse;
            }
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Argument exception occurred in AuthenticateUserAsync.");
            throw new ArgumentException("Invalid login details provided.");
        }
        catch (UnauthorizedAccessException ex)
        {
            _logger.LogError(ex, "Unauthorized access exception occurred in AuthenticateUserAsync.");
            throw new UnauthorizedAccessException("Authentication failed.");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred in AuthenticateUserAsync.");
            throw new Exception("An error occurred while processing your request.");
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
