using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dtos;
using Application.Services;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ILogger<RegisterController> _logger;

        public RegisterController(IRegisterService registerService, ILogger<RegisterController> logger)
        {
            _registerService = registerService;
            _logger = logger;
        }

        // POST: api/register/send-otp
        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] OtpRequestDto otpRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _registerService.SendOtpAsync(otpRequestDto.Email);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while sending OTP.");
                return StatusCode(500, "Internal server error while sending OTP.");
            }
        }

        // POST: api/register/verify-otp
        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtpAndRegister([FromBody] VerifyOtpDto verifyOtpDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _registerService.VerifyOtpAndRegisterAsync(
                    verifyOtpDto.Email,
                    verifyOtpDto.Otp,
                    verifyOtpDto.RegisterDto
                );

                if (result.Succeeded)
                {
                    return Ok("Registration completed successfully.");
                }

                return BadRequest(result.Errors);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while verifying OTP and registering user.");
                return StatusCode(500, "Internal server error while verifying OTP and registering user.");
            }
        }
    }
}
