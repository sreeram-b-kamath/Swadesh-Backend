using Enums;

namespace Models;
public class User
{ 
    public int Id { get; set; }
    public string Name { get; set; }
    public UserRoles Role { get; set; }
    public string Email { get; set; }
    public bool IsEmailVerified { get; set; }
    public string Mobile { get; set; }
    public string Password { get; set; }
    public bool Active { get; set; }
    public int OTP { get; set; }
    public bool OTPUsed { get; set; }
    public DateTime LastLogin { get; set; }
    public DateTime OtpExpiry { get; set; }
}