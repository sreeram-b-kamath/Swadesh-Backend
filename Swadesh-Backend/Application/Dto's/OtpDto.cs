namespace Dtos
{
    public class OtpRequestDto
    {
        public string Email { get; set; }
    }

    public class VerifyOtpDto
    {
        public string Email { get; set; }
        public string Otp { get; set; }
        public RegisterDto RegisterDto { get; set; }
    }

    public class LoginOtpVerificationDto
    {
        public string Email { get; set; }
        public string Otp { get; set; }
    }
}
