using Application.Dto_s;
using Application.Interface;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Net;
using System.Runtime.CompilerServices;

namespace Swadesh_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAdminService _adminService;


        public AdminController(IMapper mapper, IAdminService adminService)
        {
            _mapper = mapper;
            _adminService = adminService;
        }

        [Authorize]
        [HttpGet("GetAllRestaurants")]
        public async Task<ActionResult<ApiResponse>> GetAllRestaurants(int page = 1, int pageSize = 2)
        {

            var response = new ApiResponse();
            try
            {
                var restaurants = await _adminService.GetRestaurantList(page, pageSize);

                if (restaurants == null || !restaurants.Any())
                {
                    Console.WriteLine("no restaurants found");
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.ErrorMessages = new List<string> { "no restaurants found" };
                    response.Result = new GetRestaurantDTO();
                    return response;
                }

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = restaurants;
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.ErrorMessages.Add(ex.ToString());
                response.Result = "cannot load restaurants";
                return response;
            }

        }

        [Authorize]
        [HttpGet("SearchRestaurant/{searchText}")]
        public async Task<ActionResult<ApiResponse>> SearchRestaurant(string searchText)
        {

            var response = new ApiResponse();
            try
            {
                var restaurants = await _adminService.GetRestaurantsByNameOrMail(searchText);

                if (restaurants == null || restaurants.Count() == 0)
                {
                    Console.WriteLine("no restaurants found");
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Result = "no restaurants found";
                    return response;
                }

                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = restaurants;
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.ErrorMessages.Add(ex.ToString());
                response.Result = new GetRestaurantDTO();
                return response;
            }
        }

        [Authorize]
        [HttpDelete("DeleteRestaurant/{id:int}")]
        public async Task<ActionResult<ApiResponse>> DeleteRestaurant(int id)
        {
            var response = new ApiResponse();
            try
            {
                var restaurant = await _adminService.GetRestaurantById(id);
                if (restaurant == null)
                {
                    Console.WriteLine("no restaurants found");
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Result = "no restaurants found";
                    return response;
                }
                await _adminService.DeleteRestaurant(restaurant);
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = "restaurant deleted successfully";
                return response;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.ErrorMessages.Add(ex.ToString());
                response.Result = "cannot delete restaurant";
                return response;
            }
        }

        [Authorize]
        [HttpPatch("ChangeRestaurantState")]
        public async Task<ActionResult<ApiResponse>> ChangeRestaurantState(ChangeRestaurantStateDTO changeRestaurantStateDTO)
        {
            var response = new ApiResponse();
            try
            {
                var restaurant = await _adminService.GetRestaurantById(changeRestaurantStateDTO.Id);
                if (restaurant == null)
                {
                    Console.WriteLine("no restaurants found");
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Result = "no restaurants found";
                    return response;
                }
                await _adminService.ChangeRestaurantState(changeRestaurantStateDTO.Id, changeRestaurantStateDTO.IsActive);
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = "status updated successfully";

                return response;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.Result = ex.ToString();
                return response;
            }


        }
        [Authorize]
        [HttpGet("GetAllRestrictions")]
        public async Task<ActionResult<ApiResponse>> GetAllRestrictions()
        {
            var response = new ApiResponse();
            try
            {
                var restrictions = await _adminService.GetAllRestrictions();

                if (restrictions == null || !restrictions.Any())
                {
                    Console.WriteLine("no restrictions");
                    response.ErrorMessages = ["Could not find any restrictions"];
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Result = "no restrictions found";
                    return response;
                }
                Console.WriteLine("Successfullt fetched restrictions");
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = restrictions;
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.ErrorMessages = [""];
                response.ErrorMessages.Add(ex.ToString());
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.NotFound;
                response.Result = ex.ToString();
                return response;

            }


        }

        [Authorize]
        [HttpGet("GetAllRestrictionsByFilter")]
        public async Task<ActionResult<ApiResponse>> GetAllRestrictionsByFilter([FromQuery] string[] filterList)
        {
            var response = new ApiResponse();
            try
            {
                var restrictions = await _adminService.GetRestaurantsByFilter(filterList);

                if (restrictions == null || !restrictions.Any())
                {
                    Console.WriteLine("No restrictions found.");
                    response.ErrorMessages = new List<string> { "Could not find any restrictions." };
                    response.IsSuccess = false;
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Result = "No restrictions found.";
                    return NotFound(response);
                }

                Console.WriteLine("Successfully fetched restrictions.");
                response.IsSuccess = true;
                response.StatusCode = HttpStatusCode.OK;
                response.Result = restrictions;
                Console.WriteLine(restrictions.ToString());
                return Ok(response);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                response.ErrorMessages = new List<string> { ex.ToString() };
                response.IsSuccess = false;
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Result = ex.ToString();
                return StatusCode((int)HttpStatusCode.InternalServerError, response);
            }
        }
    }

}