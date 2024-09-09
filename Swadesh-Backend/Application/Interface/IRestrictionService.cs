using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto_s;
using Dtos;
using Shared;

namespace Application.Interface
{
    public interface IRestrictionService
    {
        Task<IEnumerable<MenuFilterDto>> GetRestrictionsByRestaurantIdAsync(int restaurantId);
        Task<MenuFilterDto> AddRestrictionAsync(MenuFilterDto restrictionDto);
        Task<bool> DeleteRestrictionAsync(int id);

    }
}
