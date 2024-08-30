using Application.Dto_s;
using Application.Interface;
using Domain.Models;
using Models;
using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PostToMenuService : IPostToMenuService
    {
        private readonly ApplicationDBContext _context;
        public PostToMenuService(ApplicationDBContext context)
        {
            _context = context;

        }
        public async Task<MenuItem> PostToMenuAsync(PostToMenuDto dto)
        {
            var restaraunt = await _context.restaurants.FindAsync(dto.RestaurantId);
            if (restaraunt == null) 
            {
                throw new Exception("Restaurant not found.");
            }

            var menuItem = new MenuItem
            {
                Name = dto.Name,
                Description = dto.Description,
                Money = dto.Money,
                Rating=dto.Rating,
                RestaurantId = dto.RestaurantId,
                MenuCategoryId = dto.MenuCategoryId,

                MenuItemIngredients = dto.IngredientIds.Select(id => new MenuItemIngredients { IngredientId = id }).ToList()
            };
            _context.menuItems.Add(menuItem);
            await _context.SaveChangesAsync();

            return menuItem;
        }
    }
}
