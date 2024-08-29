using Microsoft.AspNetCore.Mvc;
using Shared;



namespace Application.Interface
{
    public interface ILoginService
    {
        Task<IActionResult> Login(LoginDto loginDto);
    }
}
