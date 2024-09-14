using Shared;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface ILoginService
    {
        Task<string> InitiateLoginAsync(LoginDto loginDto);
        Task<object> VerifyOtpAndCompleteLoginAsync(string email, string otp);
    }
}