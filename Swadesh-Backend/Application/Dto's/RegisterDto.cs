using Microsoft.AspNetCore.Http;

namespace Dtos;

public class RegisterDto
{
    public string RestaurantName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Logo { get; set; }
    public string OwnerName { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
}