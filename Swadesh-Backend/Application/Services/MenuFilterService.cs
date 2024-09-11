using Application.Interface;
using AutoMapper;
using Models;
using Shared.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace Application.Services
{
    public class MenuFilterService : IMenuFilterService

    {


        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public MenuFilterService(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MenuFilterIdNameDto>> GetMenuFiltersByRestaurantIdAsync(int restaurantId)
        {
            return await _context.menuFilters
         .Where(mf => mf.RestaurantId == restaurantId && mf.Active)
         .Select(mf => new MenuFilterIdNameDto
         {
             Id = mf.Id,
             Name = mf.Name
         })
         .ToListAsync();
        }
    }
}
