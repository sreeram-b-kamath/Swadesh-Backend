using Application.Interface;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace Swadesh_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly IMenuItemService _menuItemService;
        private readonly IMenuFilterService _menuFilterService;

        public RestaurantController(IMenuFilterService menuFilterService, IRestaurantService restaurantService, IMenuItemService menuItemService)
        {
            _restaurantService = restaurantService;
            _menuItemService = menuItemService;
            _menuFilterService = menuFilterService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurantDto = await _restaurantService.GetRestaurantByIdAsync(id);

            if (restaurantDto == null)
            {
                return NotFound(new { Message = $"Restaurant with ID {id} not found." });
            }

            return Ok(restaurantDto);
        }

        [HttpPost("Filter")]
        public async Task<IActionResult> GetMenuItemsByFilters([FromBody] MenuItemsRequest request)
        {
            var result = await _menuItemService.GetMenuItemsByFiltersAsync(request);

            if (!result.Any())
            {
                return NotFound(new { Message = "No menu items found matching the given filters." });
            }

            return Ok(result);
        }

        [HttpGet("Filters/{id}")]

        public async Task<IActionResult> GetFilters(int id)
        {
            var result = await _menuFilterService.GetMenuFiltersByRestaurantIdAsync(id);

            return Ok(result);
        }



    }

}



