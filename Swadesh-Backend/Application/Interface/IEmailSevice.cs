using System.Threading.Tasks;
using Models;

namespace Interface.EmailService;

public interface IEmailService
{
    Task<bool> SendEmail(Restaurant restaurant = null, User user = null, bool isUpdateEmail = false);
}