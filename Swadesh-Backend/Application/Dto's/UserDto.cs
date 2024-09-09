using Enums;
using System;

namespace Shared;

public class UserDto
{
    public int Id { get; set; }
    public int RestaurantId { get; set; }
    public string Email { get; set; }
    public UserRoles Role { get; set; }
    public string JwtToken { get; set; }
}