using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Shared;



namespace Application.Interface
{
    public interface ILoginService
    {
        Task<string> AuthenticateUserAsync(LoginDto loginDto);
    }
}
