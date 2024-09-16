using Application.Dto_s;
using Application.Interface;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Swadesh_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemsController:ControllerBase
    {
        private readonly IMenuItemService _menuItemService;
        private readonly ILogger<MenuItemsController> _logger;
        public MenuItemsController(IMenuItemService menuItemService, ILogger<MenuItemsController> logger)
        {
            _menuItemService = menuItemService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost("PostToMenuAsync")]
        public async Task<IActionResult> PostToMenuAsync([FromBody] PostToMenuDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var menuItem = await _menuItemService.PostToMenuAsync(dto);
                return Ok(menuItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("ByRestaurant/{restaurantId}")]
        public async Task<ActionResult<List<GetMenuItemDto>>> GetMenuItemByRestaurantId(int restaurantId)
        {
            try
            {
                // Log the restaurantId
                _logger.LogInformation($"Attempting to get menu items for RestaurantId: {restaurantId}");

                // Get the bearer token from the headers
                var bearerToken = Request.Headers["Authorization"].ToString();
                if (string.IsNullOrEmpty(bearerToken))
                {
                    _logger.LogWarning("Authorization header is missing.");
                    return Unauthorized("Authorization header is missing.");
                }

                // Log the token (mask part of it for security purposes)
                _logger.LogInformation($"Authorization token received: {bearerToken.Substring(0, 10)}...");

                // Call service to get the menu items
                var menuItems = await _menuItemService.GetMenuItemsByRestarauntIdAsync(restaurantId);

                if (menuItems == null)
                {
                    _logger.LogWarning($"No menu items found for RestaurantId: {restaurantId}");
                    return NotFound();
                }

                _logger.LogInformation($"Menu items retrieved successfully for RestaurantId: {restaurantId}");

                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                // Log the exception for further debugging
                _logger.LogError(ex, $"An error occurred while fetching menu items for RestaurantId: {restaurantId}");
                return StatusCode(500, "An internal server error occurred.");
            }
        }


        [Authorize]
        [HttpDelete("{menuItemId}")]
        public async Task<IActionResult> DeleteMenuItemAsync(int menuItemId)
        {
            var isDeleted=await _menuItemService.DeleteMenuItemAsync(menuItemId);
            if (!isDeleted)
            {
                return NotFound("Menu item not found");
            }

            return Ok("Menu item deleted successfully");
        }

        [HttpPatch("{menuItemId}")]
        public async Task<IActionResult> UpdateMenuItemAsync(int menuItemId, [FromBody] PostToMenuDto dto)
        {
            try
            {
                var isUpdated = await _menuItemService.UpdateMenuItemAsync(menuItemId, dto);
                if (!isUpdated)
                {
                    return NotFound("Menu item not found");
                }

                return Ok("Menu item updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{menuItemId}")]
        public async Task<IActionResult> GetMenuItemByMenuIdAsync(int menuItemId)
        {
            try
            {
               
                var menuItem = await _menuItemService.GetMenuItemByIdAsync(menuItemId);

                if (menuItem == null)
                {
                    return NotFound("Menu item not found");
                }

                return Ok(menuItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }

}

