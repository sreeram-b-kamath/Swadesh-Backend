using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;
using Dtos;

using Shared.Data;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;
using Interface.EmailService;

namespace Application.Services;

public class RegisterService : IRegisterService
{
    private readonly ApplicationDBContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    private readonly ILogger<RegisterService> _logger;
    public readonly IEmailService _emailService;
    public RegisterService(ApplicationDBContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager, ILogger<RegisterService> logger, IEmailService emailService)
    {
        _context = dataContext;
        _userManager = userManager;
        _roleManager = roleManager;
        _logger = logger;
        _emailService = emailService;
    }

    public async Task<string> SendOtpAsync(string email)
    {
        // Generate a new OTP
        var otp = new Random().Next(1000, 9999);

        // Check if the user already exists
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            // If the user doesn't exist, create a temporary user entry
            user = new User
            {
                UserName = email,
                Email = email,
                OTP = otp,
                OtpExpiry = DateTime.UtcNow.AddMinutes(10), // OTP valid for 10 minutes
            };
            _context.Users.Add(user);
        }
        else
        {
            // If the user already exists, update the OTP
            user.OTP = otp;
            user.OtpExpiry = DateTime.UtcNow.AddMinutes(10);
        }

        await _context.SaveChangesAsync();

        // Send OTP via email
        var emailSend = await _emailService.SendEmail(user, otp);
        return emailSend ? "OTP sent successfully." : "Failed to send OTP.";
    }

    public async Task<IdentityResult> VerifyOtpAndRegisterAsync(string email, string otp, RegisterDto registerDto)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        if (user == null)
        {
            _logger.LogError("User not found for email: {Email}", email);
            return IdentityResult.Failed(new IdentityError { Description = "Invalid email or OTP." });
        }

        if (user.OTP.ToString() != otp || user.OtpExpiry < DateTime.UtcNow)
        {
            _logger.LogError("Invalid or expired OTP for email: {Email}", email);
            return IdentityResult.Failed(new IdentityError { Description = "Invalid or expired OTP." });
        }

        user.OTPUsed = true;
        user.IsEmailVerified = true;


        // Set the password
        var result = await _userManager.AddPasswordAsync(user, registerDto.Password);
        if (!result.Succeeded)
        {
            _logger.LogError("Failed to set password: {Errors}", string.Join(", ", result.Errors));
            return result;
        }

        // Create the associated Restaurant
        var restaurant = new Restaurant
        {
            Name = registerDto.RestaurantName,
            Logo = registerDto.Logo,
            UserId = user.Id,
            Uid = Guid.NewGuid().ToString()
        };
        _context.restaurants.Add(restaurant);

        await _context.SaveChangesAsync();
        return IdentityResult.Success;
    }

}

