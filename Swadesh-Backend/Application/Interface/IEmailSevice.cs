using System.Threading.Tasks;
using Models;

namespace Interface.EmailService;

public interface IEmailService
{
    Task<bool> SendEmail(User user, int otp);
}