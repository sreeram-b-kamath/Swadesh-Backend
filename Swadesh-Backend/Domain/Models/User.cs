using Enums;
using Microsoft.AspNetCore.Identity;

namespace Models;
public class User : IdentityUser<int>
{ 
    public int Id { get; set; }
    public UserRoles Role { get; set; }
    public string Email { get; set; }
    public bool IsEmailVerified { get; set; }
    public bool Active { get; set; }
    public int OTP { get; set; }
    public bool OTPUsed { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime OtpExpiry { get; set; }
}