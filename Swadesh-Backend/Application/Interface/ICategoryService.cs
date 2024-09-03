using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto_s;
using Dtos;
using Shared;

namespace Application.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<MenuCategoryDto>> GetCategoriesByRestaurantIdAsync(int restaurantId);
        Task<MenuCategoryDto> GetCategoryByIdAsync(int id);
        Task<bool> CreateCategoryAsync(MenuCategoryDto categoryDto);
        Task<bool> UpdateCategoryAsync(MenuCategoryDto categoryDto);
        Task<bool> DeleteCategoryAsync(int id);

        Task<bool> UpdateCategoryActiveAsync(int id, bool active);
    }
}

