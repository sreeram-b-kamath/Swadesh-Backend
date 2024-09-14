using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Dtos;
using Application.Services;
using Microsoft.Extensions.Logging;
using Application.Interface;
using Shared;
namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService _registerService;
        private readonly ILogger<RegisterController> _logger;
        private readonly ILoginService _loginService;
        public RegisterController(IRegisterService registerService, ILogger<RegisterController> logger, ILoginService loginService)
        {
            _registerService = registerService;
            _logger = logger;
            _loginService = loginService;
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

        [HttpPost("initiate-login")]
        public async Task<IActionResult> InitiateLogin([FromBody] LoginDto loginDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _loginService.InitiateLoginAsync(loginDto);
                return Ok(new { message = result });
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Failed login attempt for user {Email}", loginDto.Email);
                return Unauthorized(new { message = "Invalid credentials." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while initiating login for user {Email}", loginDto.Email);
                return StatusCode(500, "Internal server error while initiating login.");
            }
        }

        [HttpPost("verify-login-otp")]
        public async Task<IActionResult> VerifyLoginOtp([FromBody] LoginOtpVerificationDto verificationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _loginService.VerifyOtpAndCompleteLoginAsync(verificationDto.Email, verificationDto.Otp);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                _logger.LogWarning(ex, "Failed OTP verification for user {Email}", verificationDto.Email);
                return Unauthorized(new { message = "Invalid or expired OTP." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while verifying login OTP for user {Email}", verificationDto.Email);
                return StatusCode(500, "Internal server error while verifying login OTP.");
            }
        }
    }
}