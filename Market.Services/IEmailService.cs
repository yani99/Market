using System.Threading.Tasks;

namespace Market.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string msg);
    }
}
