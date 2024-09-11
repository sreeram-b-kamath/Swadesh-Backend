using Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IMenuFilterService
    {
        Task<IEnumerable<MenuFilterIdNameDto>> GetMenuFiltersByRestaurantIdAsync(int restaurantId);
    }

}
