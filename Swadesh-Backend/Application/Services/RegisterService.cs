/*using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Models;
using Dtos;
using Shared.Data;

namespace Application.Services;

public class RegisterService : IRegisterService
{
    private readonly ApplicationDBContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole<int>> _roleManager;
    public RegisterService(ApplicationDBContext dataContext, UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
    {
        _context = dataContext;
        _userManager = userManager;
        _roleManager = roleManager;
    }
    public async Task<IdentityResult> RegisterUserAsync(RegisterDto registerDto)
    {
        // Create the Restaurant
        var restaurant = new Restaurant
        {
            Name = registerDto.RestaurantName,
            Logo = registerDto.Logo,
            // Set other properties if needed
        };

        _context.Restaurants.Add(restaurant);
        await _context.SaveChangesAsync();

        // Create the User
        var user = new User
        {
            UserName = registerDto.Email,
            Email = registerDto.Email,
            RestaurantId = restaurant.Id // Link the user to the restaurant
        };

        var result = await _userManager.CreateAsync(user, registerDto.Password);

        if (result.Succeeded)
        {
            // Optionally assign roles or additional configuration
        }

        return result;
    }
}

*/