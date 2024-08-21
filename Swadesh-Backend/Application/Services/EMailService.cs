using Models;
using Shared.Data;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using Application.Interface;
using Interface.EmailService;
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
    public async Task<bool> SendEmail(Restaurant restaurant, User user, bool isUpdateEmail = false)
    {
        bool isEmailSend = false;
        if (restaurant is not null || user is not null)
        {
            var emailId = (isUpdateEmail == true) ? restaurant.UpdateEmail : restaurant?.Email ?? user?.Email;
            var subject = "Email Verification from Swadesh";
            int num = new Random().Next(1000, 9999);
            var emailContent = $"<h1>Your OTP for Swasdesh : {num}</h1>";

            await _emailSender.SendEmailAsync(emailId, subject, emailContent);

            try
            {
                if (!string.IsNullOrEmpty(emailContent))
                {
                    if (restaurant is not null)
                    {
                        var restaurantData = await _dataContext.restaurants.FirstOrDefaultAsync(x => x.Id == restaurant.Id);
                        restaurantData.OTP = num;
                        restaurantData.OTPUsed = false;
                        restaurantData.OtpExpiry = DateTime.UtcNow;
                        await _dataContext.SaveChangesAsync();
                    }
                    else
                    {
                        var userData = await _dataContext.users.FirstOrDefaultAsync(x => x.Id == user.Id);
                        userData.OTP = num;
                        userData.OTPUsed = false;
                        userData.OtpExpiry = DateTime.UtcNow;
                        await _dataContext.SaveChangesAsync();
                    }

                    isEmailSend = true;
                }
                else
                {
                    Console.WriteLine($"Failed to send email.");
                    return isEmailSend;
                }

                return isEmailSend;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in sending email, {ex}");
                return isEmailSend;
            }
        }
        return isEmailSend;
    }

}