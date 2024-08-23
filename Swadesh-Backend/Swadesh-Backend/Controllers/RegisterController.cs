using Application.Services;
using Dtos;
using Microsoft.AspNetCore.Mvc;
using Helpers;
using Interface.EmailService;
using AutoMapper;
using Models;

namespace Swadesh_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegisterController : ControllerBase
    {
        public readonly IRegisterService _registerService;
        public readonly IEmailService _emailService;
        public readonly IMapper _mapper;

        public RegisterController(IRegisterService registerService, IEmailService emailSender, IMapper mapper)
        {
            _registerService = registerService;
            _emailService = emailSender;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterRestaurant(RegisterDto registerDto)
        {
            var hoteltoregister = registerDto;
            if (hoteltoregister == null)
            {
                throw new ArgumentNullException(nameof(registerDto));
            }
            else
            {
                var isEmailExisting = await _registerService.CheckEmailExist(hoteltoregister);
                if (isEmailExisting)
                {
                    return BadRequest("Email already exists");
                }

                if (!ValidatePassword.CheckPassWord(registerDto.Password))
                {
                    return BadRequest("Password not matching standards");
                }

                //ValidateEmail
                var isEmailValidated = ValidateEmail.ValidateEmailAddress(registerDto.Email);

                if (!ValidateEmail.ValidateEmailAddress(registerDto.Email))
                {
                    return BadRequest("Email domain does not exist");
                }

                //Register Restaurant
                var registerRestaurant = await _registerService.RegisterRestaurant(registerDto);

                if (registerRestaurant == null && registerRestaurant.Id <= 0)
                    throw new ArgumentNullException("Unable to Register");

                //Send Email
                var emailSend = await _emailService.SendEmail(registerRestaurant);

                if (!emailSend)
                    throw new Exception("Email not send");

                var restaurant = _mapper.Map<Restaurant>(registerRestaurant);

                return new OkObjectResult(restaurant);

            }
        }
    }
}
