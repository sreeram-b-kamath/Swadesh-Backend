using System.Threading.Tasks;
using Models;
using Dtos;

namespace Application.Services;
public interface IRegisterService
{
    Task<Restaurant> RegisterRestaurant(RegisterDto registerDto);
    Task<bool> CheckEmailExist(RegisterDto registerDto);
}