using System.Threading.Tasks;

namespace Selfgram.Services.Senders
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
