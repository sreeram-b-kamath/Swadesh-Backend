using Enums;
using System;

namespace Shared;

public class UserDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string Email { get; set; }
    public UserRoles Role { get; set; }
}