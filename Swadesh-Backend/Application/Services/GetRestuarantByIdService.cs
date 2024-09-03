
    using Application.Interface;
    using AutoMapper;
    using Dtos;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Org.BouncyCastle.Crypto;
    using Shared.Data;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Application.Services
    {
        public class RestaurantService : IRestaurantService
        {
            private readonly ApplicationDBContext _context;

            private readonly IMapper _mapper;

            public RestaurantService(ApplicationDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

        

            public async Task<RestuarantUserGetDto> GetRestaurantByIdAsync(int id)
            {
                Restaurant restaurant = await _context.restaurants
                                       .Include(r => r.User)
                                       .Include(r => r.MenuCategories)
                                       .Include(r => r.MenuFilters)
                                       .Include(r => r.MenuItems)
                                       .FirstOrDefaultAsync(r => r.Id == id);

                if (restaurant == null)
                {
                    return null; // Or handle accordingly
                }

                // Map to the new DTO
                var restaurantDto = _mapper.Map<RestuarantUserGetDto>(restaurant);
                return restaurantDto;
            }
        }

    }


