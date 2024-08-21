using Microsoft.EntityFrameworkCore;
using Models;
using Shared.Data;
using Helpers.Hashing;
using Dtos;

namespace Application.Services;

public class RegisterService : IRegisterService
{
    private readonly ApplicationDBContext _dataContext;
    public RegisterService(ApplicationDBContext dataContext)
    {
        _dataContext = dataContext;
    }

    public async Task<bool> CheckEmailExist(RegisterDto registerDto)
    {
        if (registerDto != null)
        {
            var userEmail = await _dataContext.users
            .FirstOrDefaultAsync(x => x.Email == registerDto.Email);

            var restaurantEmail = await _dataContext.restaurants
            .FirstOrDefaultAsync(x => x.Email == registerDto.Email);

            if (userEmail != null || restaurantEmail != null)
                return true;

        }
        return false;
    }

    public async Task<Restaurant> RegisterRestaurant(RegisterDto registerDto)
    {
        Restaurant restaurant = new();

        if (registerDto == null)
            return restaurant;


        restaurant.Name = registerDto.RestaurantName;
        restaurant.Email = registerDto.Email;
        restaurant.Password = Hashing.Encyrpt(registerDto.Password);
        restaurant.Logo = registerDto.Logo;
        restaurant.Uid = Guid.NewGuid().ToString();

        await _dataContext.restaurants.AddAsync(restaurant);
        var rowEffected = await _dataContext.SaveChangesAsync();

        return restaurant;
    }
}

