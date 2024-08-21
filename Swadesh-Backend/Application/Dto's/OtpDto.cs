namespace Shared;

public class OtpDto
{
    public string Email { get; set; }
    public int OTP { get; set; }
    public bool IsRegister { get; set; } = false;
}