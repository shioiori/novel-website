using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.MailKit;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IAccountRepository _accountRepository;

        public MailService(IOptions<MailSettings> mailSettings, IAccountRepository accountRepository)
        {
            _mailSettings = mailSettings.Value;
            _accountRepository = accountRepository;
        }
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            await SendMail(new MailContent()
            {
                To = email,
                Subject = subject,
                Body = htmlMessage
            });
        }

        public async Task SendMail(MailContent mailContent)
        {
            var email = new MimeMessage();
            email.Sender = new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail);
            email.From.Add(new MailboxAddress(_mailSettings.DisplayName, _mailSettings.Mail));
            email.To.Add(MailboxAddress.Parse(mailContent.To));
            email.Subject = mailContent.Subject;

            var builder = new BodyBuilder();
            builder.HtmlBody = mailContent.Body;
            email.Body = builder.ToMessageBody();

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            try
            {
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                await smtp.SendAsync(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            smtp.Disconnect(true);
        }

        public AuthenticationResponse ConfirmEmail(string mail, string token)
        {
            var account = _accountRepository.GetAccountByEmail(mail);
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var claims = new ClaimsIdentity(jwtSecurityToken.Claims);
            if (claims.FindFirst(ClaimTypes.NameIdentifier).ToString() == ClaimTypes.NameIdentifier+": "+mail)
            {
                account.Status = (int)AccountStatus.Active;
                _accountRepository.Update(account);
                _accountRepository.Save();
                return new AuthenticationResponse()
                {    
                    Success = true,
                    Message = "Xác minh thành công. Từ giờ bạn có thể đăng nhập bình thường"
                };
            }
            return new AuthenticationResponse()
            {
                Success = false,
                Message = "Có lỗi xảy ra khi xác nhận mail"
            };
        }

    }
}
