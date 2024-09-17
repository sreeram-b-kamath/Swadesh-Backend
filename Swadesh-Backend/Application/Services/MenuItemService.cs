using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Application.Interface;
using Shared;
using Shared.Data;
﻿using Application.Dto_s;
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

        public async Task<List<CategoryMenuItemsResponseDto>> GetMenuItemsByFiltersAsync(MenuItemsRequest request)
        {
            var categories = await _context.menuCategories
                                           .Where(c => c.RestaurantId == request.RestaurantId && c.Active)
                                           .ToListAsync();
            foreach (var category in categories)
            {
                Console.WriteLine($"Category Id: {category.Id}, Name: {category.Name}, Active: {category.Active}");
            }
            if (!categories.Any())
            {
                throw new InvalidOperationException("No categories found for the given restaurant.");
            }
            
             var menuItems = await _context.menuItems
.Where(mi => mi.RestaurantId == request.RestaurantId && mi.Active &&
             (
                 request.FilterIds == null ||
                 !request.FilterIds.Any() ||
                 mi.MenuFilterIds.Any(fid => request.FilterIds.Contains(fid))
             ))
.Include(mi => mi.MenuCategory)
.Include(mi => mi.MenuItemIngredients)
    .ThenInclude(mii => mii.Ingredients)
.Include(mi => mi.MenuItemRatings)
.ToListAsync();


            var menuItemResponses = _mapper.Map<List<MenuItemResponse>>(menuItems);

        

            if (!menuItemResponses.Any())
            {
                Console.WriteLine("No menu item responses found.");
            }
            else
            {
                foreach (var menuItemResponse in menuItemResponses)
                {
                    Console.WriteLine($"MenuItem Id: {menuItemResponse.Id}");
                    Console.WriteLine($"Name: {menuItemResponse.Name}");
                    Console.WriteLine($"Category Name: {menuItemResponse.CategoryName}");
                    Console.WriteLine($"Price: {menuItemResponse.Money}");
                    Console.WriteLine($"Rating: {menuItemResponse.Rating}");
                    Console.WriteLine($"Category Id: {menuItemResponse.CategoryId}");
                    Console.WriteLine(new string('-', 30)); // Separator for readability
                }
            }
            var groupedItems = menuItemResponses.GroupBy(mi => new { mi.CategoryId, mi.CategoryName }).Select(group => new CategoryMenuItemsResponseDto
    {                   CategoryId = group.Key.CategoryId,
                        CategoryName = group.Key.CategoryName,
                        MenuItems = group.ToList() // Get all menu items in this category
                        }).ToList();
            foreach (var group in groupedItems)
            {
                Console.WriteLine($"Category: {group.CategoryName}, Items Count: {group.MenuItems.Count}");
            }

            return groupedItems;

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
        public async Task<bool> UpdateMenuItemAsync(int menuItemId, PostToMenuDto dto)
        {
            var menuItem = await _context.menuItems.FindAsync(menuItemId);
            if (menuItem == null)
            {
                return false; // Menu item not found
            }

            // Update the fields
            menuItem.Name = dto.Name;
            menuItem.PrimaryImage = dto.PrimaryImage;
            menuItem.Description = dto.Description;
            menuItem.Money = dto.Money;


            // Save changes to the database
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<GetMenuItemDto> GetMenuItemByIdAsync(int menuItemId)
        {
            var menuItem = await _context.menuItems
                                         .Where(m => m.Id == menuItemId)
                                         .Include(m => m.MenuItemIngredients) // Include the ingredients relation
                                         .FirstOrDefaultAsync();

            if (menuItem == null)
            {
                return null; // Menu item not found
            }

            // Map to GetMenuItemDto
            var menuItemDto = _mapper.Map<GetMenuItemDto>(menuItem);

            // Map the ingredient IDs
            menuItemDto.IngredientIds = menuItem.MenuItemIngredients.Select(mi => mi.IngredientId).ToList();

            return menuItemDto;
        }

    }
}
