using System.Threading.Tasks;
using Models;
using Dtos;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;
public interface IRegisterService
{
    Task<string> SendOtpAsync(string email);
    Task<IdentityResult> VerifyOtpAndRegisterAsync(string email, string otp, RegisterDto registerDto);
}