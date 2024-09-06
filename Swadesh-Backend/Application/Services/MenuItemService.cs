using Application.Dto_s;
using Application.Interface;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Models;
using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class MenuItemService : IMenuItemService
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        public MenuItemService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<MenuItem> PostToMenuAsync(PostToMenuDto dto)
        {
            var restaraunt = await _context.restaurants.FindAsync(dto.RestaurantId);
            if (restaraunt == null ) 
            {
                throw new Exception("Restaurant not found.");
            }
            var MenuCategoryId = await _context.menuCategories.FindAsync(dto.MenuCategoryId);
            if (MenuCategoryId == null)
            {
                throw new Exception("category not found.");
            }
            var menuItem=_mapper.Map<MenuItem>(dto);
            menuItem.uid = Guid.NewGuid();


            try
            {
                await _context.menuItems.AddAsync(menuItem);
                await _context.SaveChangesAsync();
                foreach(int item in dto.IngredientIds)
                {
                   await AddToMenuIngredients(item, menuItem.Id);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception("An error occurred while saving the menu item.", ex);
            }


            return menuItem;
        }

        public async Task<MenuItemIngredients> AddToMenuIngredients(int ingredientId,int MenuId)
        {
            var menuIngredient = new MenuItemIngredients { IngredientId = ingredientId, MenuItemId = MenuId };
            try
            {
                
                await _context.MenuItemIngredients.AddAsync(menuIngredient);
                await _context.SaveChangesAsync();
                return menuIngredient;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return menuIngredient;
            }
        }

        public async Task<List<GetMenuItemDto>> GetMenuItemsByRestarauntIdAsync(int restarauntId)
        {
            var menuItems=await _context.menuItems.Where(u=>u.RestaurantId==restarauntId).Include(v=>v.MenuItemIngredients).ToListAsync();
            var menuItemDtos=_mapper.Map<List<GetMenuItemDto>>(menuItems);
            return menuItemDtos;
        }

        public async Task<bool> DeleteMenuItemAsync(int menuItemId)
        {
            var menuItem=await _context.menuItems.FindAsync(menuItemId);
            if (menuItemId==null)
            {
                return false; 
            }
            _context.menuItems.Remove(menuItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
