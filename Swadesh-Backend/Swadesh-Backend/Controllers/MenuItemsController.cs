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
        public MenuItemsController(IMenuItemService menuItemService )
        {
            _menuItemService = menuItemService;
            
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
        [HttpGet("ByRestaraunt/{restarauntId}")]
        public async Task<ActionResult<List<GetMenuItemDto>>> GetMenuItemByRestarauntId(int restarauntId)
        {
            var menuItems=await _menuItemService.GetMenuItemsByRestarauntIdAsync(restarauntId);
            if (menuItems == null) { 
                return NotFound();
            }
            return Ok(menuItems);

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

