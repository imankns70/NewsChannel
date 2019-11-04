using System.Threading.Tasks;

namespace NewsChannel.Service.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
