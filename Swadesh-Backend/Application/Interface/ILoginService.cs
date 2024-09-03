using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Models;
using Shared;



namespace Application.Interface
{
    public interface ILoginService
    {
        Task<UserDto> AuthenticateUserAsync(LoginDto loginDto);
    }
}
