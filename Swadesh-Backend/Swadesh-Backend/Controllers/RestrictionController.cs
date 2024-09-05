using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.Extensions.Logging;
using Shared;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestrictionController : ControllerBase
    {
        private readonly IRestrictionService _restrictionService;
        private readonly ILogger<RestrictionController> _logger;

        public RestrictionController(IRestrictionService restrictionService, ILogger<RestrictionController> logger)
        {
            _restrictionService = restrictionService;
            _logger = logger;
        }

        // GET: api/Restriction/{restaurantId}
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetRestrictionsByRestaurantId(int restaurantId)
        {
            try
            {
                var restrictions = await _restrictionService.GetRestrictionsByRestaurantIdAsync(restaurantId);

                if (restrictions == null || !restrictions.Any())
                {
                    return NotFound(new { message = "No restrictions found for the given restaurant ID." });
                }

                return Ok(restrictions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching restrictions for restaurant ID {RestaurantId}.", restaurantId);
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        // POSt
        [HttpPost]
        public async Task<IActionResult> AddRestriction([FromBody] MenuFilterDto restrictionDto)
        {
            try
            {
                if (restrictionDto == null)
                {
                    return BadRequest("Restriction data is null.");
                }

                var createdRestriction = await _restrictionService.AddRestrictionAsync(restrictionDto);

                return CreatedAtAction(nameof(GetRestrictionsByRestaurantId), new { restaurantId = createdRestriction.RestaurantID }, createdRestriction);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while adding a new restriction.");
                return StatusCode(500, "An internal server error occurred.");
            }
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestriction(int id)
        {
            try
            {
                var result = await _restrictionService.DeleteRestrictionAsync(id);

                if (!result)
                {
                    return NotFound(new { message = "Restriction not found." });
                }

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while deleting restriction with ID {RestrictionId}.", id);
                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}
