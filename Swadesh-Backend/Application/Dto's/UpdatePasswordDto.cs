namespace Shared;


public class UpdatePasswordDto
{
    public string Email { get; set; }
    public string UpdatePassword { get; set; }
    public int OTP { get; set; }
}