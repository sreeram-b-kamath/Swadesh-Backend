using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dtos;
using Application.Interface;
using Microsoft.Extensions.Logging;
using Application.Services;
using Shared;
using Application.Dto_s;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }
        [HttpGet("{restaurantId}")]
        public async Task<IActionResult> GetCategoriesByRestaurantId(int restaurantId)
        {
            try
            {
                var categories = await _categoryService.GetCategoriesByRestaurantIdAsync(restaurantId);

                if (categories == null || !categories.Any())
                {
                    return NotFound(new { message = "No categories found for the given restaurant ID." });
                }

                return Ok(categories);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching categories for restaurant ID {RestaurantId}.", restaurantId);
                return StatusCode(500, "An internal server error occurred.");
            }
        }


        [HttpGet("category/{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            try
            {
                var category = await _categoryService.GetCategoryByIdAsync(id);

                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching the category.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] MenuCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _categoryService.CreateCategoryAsync(categoryDto);

                if (result)
                {
                    return CreatedAtAction(nameof(GetCategoryById), new { id = categoryDto.Id }, categoryDto);
                }

                return BadRequest("Unable to create category.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating the category.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromBody] MenuCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _categoryService.UpdateCategoryAsync(categoryDto);

                if (result)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the category.");
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCategoryActive(int id, [FromBody] UpdateCategoryActiveDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _categoryService.UpdateCategoryActiveAsync(id, updateDto.Active);

                if (result)
                {
                    return NoContent(); // Successfully updated, but no content to return
                }

                return NotFound("Category not found.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating the category.");
                return StatusCode(500, "Internal server error.");
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                var result = await _categoryService.DeleteCategoryAsync(id);

                if (result)
                {
                    return NoContent();
                }

                return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting the category.");
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
