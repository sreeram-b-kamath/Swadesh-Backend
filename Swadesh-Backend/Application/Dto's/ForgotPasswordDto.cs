namespace Shared;



public class ForgotPasswordDto
{
    public string Email { get; set; }
    public int Otp { get; set; }
    public bool IsOtpSend { get; set; }
    public bool OtpValidated { get; set; }
}