using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.MailKit;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IMailService
    {
        Task SendMail(MailContent mailContent);
        Task SendEmailAsync(string email, string subject, string htmlMessage);
        AuthenticationResponse ConfirmEmail(string mail, string token);
    }
}
