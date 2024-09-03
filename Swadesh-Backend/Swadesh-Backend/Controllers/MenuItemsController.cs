using Application.Dto_s;
using Application.Interface;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Swadesh_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuItemsController:ControllerBase
    {
        private readonly IPostToMenuService _postToMenuService;
        public MenuItemsController(IPostToMenuService postToMenuService )
        {
            _postToMenuService = postToMenuService;
            
        }
        [HttpPost("PostToMenuAsync")]
        public async Task<IActionResult> PostToMenuAsync([FromBody] PostToMenuDto dto)
        {
            try
            {
                var menuItem = await _postToMenuService.PostToMenuAsync(dto);
                return Ok(menuItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
