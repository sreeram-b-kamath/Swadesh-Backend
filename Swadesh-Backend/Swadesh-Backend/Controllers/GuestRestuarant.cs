using Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Swadesh_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
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
    }

}
