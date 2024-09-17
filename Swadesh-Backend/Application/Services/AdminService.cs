using Application.Dto_s;
using Application.Interface;
using Domain.Models;
using MailKit.Search;
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
    public class AdminService : IAdminService
    {

        private readonly ApplicationDBContext _context;

        public AdminService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> ChangeRestaurantState(int restaurantId, bool isActive)
        {
            try
            {
                var restaurant = await GetRestaurantById(restaurantId);
                restaurant.Active = isActive;
                _context.restaurants.Update(restaurant);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }


        }

        public async Task<bool> DeleteRestaurant(Restaurant restaurant)
        {
            try
            {

                _context.restaurants.Remove(restaurant);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");

                return false;
            }
        }




        public async Task<Restaurant> GetRestaurantById(int restaurantId)
        {
            try
            {
                var restaurant = await _context.restaurants
                    .FirstOrDefaultAsync(u => u.Id == restaurantId);

                if (restaurant == null)
                {
                    Console.WriteLine($"No restaurant found with ID {restaurantId}.");
                    return new Restaurant();
                }

                return restaurant;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Restaurant();
            }
        }

        public async Task<ICollection<GetRestaurantDTO>> GetRestaurantsByNameOrMail(string nameOrMail)
        {
            try
            {
                var restaurants = await _context.restaurants
                    .Include(r => r.User) // Ensure User is included if you are using it
                    .Where(u => u.Name.ToLower().Contains(nameOrMail.ToLower()) || u.User.Email.ToLower().Contains(nameOrMail.ToLower()))
                    .Select(u => new GetRestaurantDTO
                    {
                        Id = u.Id,
                        Name = u.Name,
                        IsActive = u.Active,
                        Email = u.User.Email,
                        Logo = u.Logo
                    })
                    .ToListAsync();

                if (restaurants == null)
                {
                    Console.WriteLine($"No restaurants found with name or email containing: {nameOrMail}.");
                    return new List<GetRestaurantDTO>();
                }

                return restaurants;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }


        public async Task<ICollection<GetRestaurantDTO>> GetRestaurantList(int page, int pageSize)
        {
            try
            {
                var restaurantList = await _context.restaurants
                    .Include(r => r.User)
                    .Select(r => new GetRestaurantDTO
                    {
                        Id = r.Id,
                        Name = r.Name,
                        IsActive = r.Active,
                        Email = r.User.Email,
                        Logo = r.Logo
                    })
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                // Check if the list is empty and log if necessary
                if (restaurantList.Count == 0)
                {
                    Console.WriteLine("No restaurants found.");
                }

                return restaurantList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<GetRestaurantDTO>();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GetRestaurantDTO>> GetRestaurantsByFilter(string[] filterList)
        {
            var restaurants = new List<GetRestaurantDTO>();

            try
            {
                var allResults = new List<GetRestaurantDTO>();

                foreach (string item in filterList)
                {
                    Console.WriteLine(item);
                    if (string.Equals(item.ToLower(), "active") || string.Equals(item.ToLower(), "inactive"))
                    {
                        var searchResults = await _context.restaurants
                            .Where(u => (item.ToLower() == "active" ? true : false) == u.Active)
                            .Select(u => new GetRestaurantDTO
                            {
                                Id = u.Id,
                                Name = u.Name,
                                IsActive = u.Active,
                                Email = u.User.Email,
                                Logo = u.Logo
                            })
                            .ToListAsync();

                        allResults.AddRange(searchResults);
                    }
                    else
                    {
                        var searchResults = await _context.restaurants
                            .Where(r => _context.menuFilters
                                .Where(mf => mf.Name.ToLower() == item.ToLower())
                                .Select(mf => mf.RestaurantId)
                                .Contains(r.Id))
                            .Select(u => new GetRestaurantDTO
                            {
                                Id = u.Id,
                                Name = u.Name,
                                IsActive = u.Active,
                                Email = u.User.Email,
                                Logo = u.Logo
                            })
                            .ToListAsync();

                        allResults.AddRange(searchResults);
                    }
                }

                // Remove duplicates based on Id
                var uniqueResults = allResults
                    .GroupBy(r => r.Id)
                    .Select(g => g.First())
                    .ToList();

                // Add the results to the list
                restaurants.AddRange(uniqueResults);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return restaurants;
        }

        public async Task<ICollection<string>> GetAllRestrictions()
        {

            try
            {
                var uniqueRestrictions = await _context.menuFilters
               .Select(u => u.Name)
               .Distinct()
               .ToListAsync();

                if (!uniqueRestrictions.Any() || uniqueRestrictions == null)
                {
                    Console.WriteLine("error... failed to fetch restrictions");
                    uniqueRestrictions = [""];
                    return uniqueRestrictions;
                }

                return uniqueRestrictions;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                var uniqueRestrictions = new string[0];

                return uniqueRestrictions;
            }


        }
    }
}