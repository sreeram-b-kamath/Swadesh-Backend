using Application.Dto_s;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IAdminService
    {
        Task<ICollection<GetRestaurantDTO>> GetRestaurantList(int page, int pageSize);
        Task<bool> ChangeRestaurantState(int restaurantId, bool isActive);
        Task<bool> DeleteRestaurant(Restaurant restaurant);
        Task<Restaurant> GetRestaurantById(int restaurantId);
        Task<ICollection<GetRestaurantDTO>> GetRestaurantsByNameOrMail(string nameOrMail);
        Task<ICollection<GetRestaurantDTO>> GetRestaurantsByFilter(string[] filterList);
        Task<ICollection<string>> GetAllRestrictions();
        Task SaveAsync();
    }
}