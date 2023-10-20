using AutoMapper;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.MailKit;
using NovelWebsite.NovelWebsite.Domain.Utils;
using NovelWebsite.NovelWebsite.Infrastructure.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public MailService(IOptions<MailSettings> mailSettings, IAccountRepository accountRepository, IUserRepository userRepository, IMapper mapper)
        {
            _mailSettings = mailSettings.Value;
            _accountRepository = accountRepository;
            _userRepository = userRepository;
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

        public AuthenticationResponse ConfirmEmail(string mail, string token)
        {
            try
            {
                var account = _accountRepository.GetAccountByEmail(mail);
                account.Status = (int)AccountStatus.Active;
                var decrypt = AesOperation.DecryptString(token);
                var user = JsonConvert.DeserializeObject<UserModel>(decrypt);
                _userRepository.Insert(_mapper.Map<UserModel, User>(user));
                _userRepository.Save();
                return new AuthenticationResponse()
                {
                    Success = true,
                    Message = "Xác minh thành công. Từ giờ bạn có thể đăng nhập bình thường"
                };
            }
            catch (Exception ex)
            {
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = "Có lỗi xảy ra khi xác nhận mail"
                };
            }
        }
    }
}
