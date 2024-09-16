using Application.Dto_s;
using Application.Interface;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Swadesh_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngredientsController:ControllerBase
    {
        private readonly IIngredientsService _ingredientsService;
        public IngredientsController(IIngredientsService ingredientsService)
        {
            _ingredientsService = ingredientsService;
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<List<GetingredientsDto>>> GetIngredientsAsync()
        {
            try
            {
                var ingredients = await _ingredientsService.GetIngredientsAsync();
                if (ingredients == null)
                {
                    return NotFound();
                }
                return Ok(ingredients);
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }

        }
    }
}
