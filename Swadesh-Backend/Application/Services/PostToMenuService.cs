using Application.Dto_s;
using Application.Interface;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
        private readonly IMapper _mapper;
        public PostToMenuService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }
        public async Task<MenuItem> PostToMenuAsync(PostToMenuDto dto)
        {
            var restaraunt = await _context.restaurants.FindAsync(dto.RestaurantId);
            if (restaraunt == null) 
            {
                throw new Exception("Restaurant not found.");
            }
            var MenuCategoryId = await _context.menuCategories.FindAsync(dto.MenuCategoryId);
            if (MenuCategoryId == null)
            {
                throw new Exception("Restaurant not found.");
            }
            var menuItem=_mapper.Map<MenuItem>(dto);
            menuItem.uid = Guid.NewGuid();


            try
            {
                await _context.menuItems.AddAsync(menuItem);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception("An error occurred while saving the menu item.", ex);
            }


            return menuItem;
        }
    }
}
