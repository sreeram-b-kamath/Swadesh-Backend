using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto_s;
using Application.Interface;
using Dtos;
using Microsoft.EntityFrameworkCore;
using Models;
using Shared;
using Shared.Data;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDBContext _context;

        public CategoryService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MenuCategoryDto>> GetCategoriesByRestaurantIdAsync(int restaurantId)
        {
            return await _context.menuCategories
                .Where(c => c.RestaurantId == restaurantId && c.Active==true)
                .Select(c => new MenuCategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Active = c.Active,
                    RestaurantId = c.RestaurantId
                })
                .ToListAsync();
        }

        public async Task<MenuCategoryDto> GetCategoryByIdAsync(int id)
        {
            var category = await _context.menuCategories
                .Where(c => c.Id == id)
                .Select(c => new MenuCategoryDto
                {
                   
                    Name = c.Name,
                    Active = c.Active,
                    RestaurantId = c.RestaurantId
                })
                .FirstOrDefaultAsync();

            return category;
        }

       

        public async Task<bool> UpdateCategoryAsync(MenuCategoryDto categoryDto)
        {
            var category = await _context.menuCategories.FindAsync(categoryDto.Id);

            if (category == null)
                return false;

            category.Name = categoryDto.Name;
        
            category.Active = categoryDto.Active;

            _context.menuCategories.Update(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _context.menuCategories.FindAsync(id);

            if (category == null)
                return false;

            _context.menuCategories.Remove(category);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CreateCategoryAsync(MenuCategoryDto categoryDto)
        {
            try
            {
                int maxId = await _context.menuCategories.MaxAsync(c => c.Id);
                var category = new MenuCategory
                {
                    Id= maxId+1,
                    Name = categoryDto.Name,
                    Active = categoryDto.Active,
                    RestaurantId = categoryDto.RestaurantId,
                    Uid = Guid.NewGuid()
                };
                _context.menuCategories.Add(category);

                return await _context.SaveChangesAsync() > 0;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public  async Task<bool> UpdateCategoryActiveAsync(int id, bool active)
        {
            var category = await _context.menuCategories.FindAsync(id);

            if (category == null)
            {
                return false;
            }

            category.Active = active;

            return await _context.SaveChangesAsync() > 0;
        }
    }
    }

