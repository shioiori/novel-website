using AutoMapper;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Application.Models.Objects.MailKit;

namespace NovelWebsite.Application.Services
{
    public class MailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IMapper _mapper;

        public MailService(IOptions<MailSettings> mailSettings, 
            IMapper mapper)
        {
            _mailSettings = mailSettings.Value;
            _mapper = mapper;
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

    }
}
