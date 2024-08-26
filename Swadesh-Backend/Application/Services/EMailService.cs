using Application.Interface;
using Models;
using Shared.Data;
using IEmailService = Interface.EmailService.IEmailService;

namespace Application.Services.EMailService;

public class EmailService : IEmailService
{
    private readonly ApplicationDBContext _dataContext;
    private readonly IEmailSender _emailSender;
    public EmailService(ApplicationDBContext dataContext, IEmailSender emailSender)
    {
        _dataContext = dataContext;
        _emailSender = emailSender;
    }
    public async Task<bool> SendEmail(User user, int otp)
    {
        bool isEmailSend = false;
        if (user is not null || user is not null)
        {
            var emailId = user?.Email;
            var subject = "Email Verification from Swadesh";
            var emailContent = $"<h1>Your OTP for Swasdesh : {otp}</h1>";

            await _emailSender.SendEmailAsync(emailId, subject, emailContent);
        }
        return isEmailSend;
    }

}