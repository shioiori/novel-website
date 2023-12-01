using AutoMapper;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Application.Models.Objects.MailKit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using NovelWebsite.Domain.Enums;
using System.Text;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Application.Utils;
using Application.Models.Dtos;
using Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _contextAccessor;

        public MailService(IOptions<MailSettings> mailSettings,
            UserManager<User> userManager,
            IHttpContextAccessor contextAccessor,
            IMapper mapper)
        {
            _userManager = userManager;
            _mailSettings = mailSettings.Value;
            _contextAccessor = contextAccessor;
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

        public async Task ConfirmEmailAsync(string email, string token)
        {
            try
            {
                var decode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
                User user = await _userManager.FindByEmailAsync(email);
                if (await _userManager.IsEmailConfirmedAsync(user))
                {
                    throw new Exception("Your email was confirmed");
                }

                var result = await _userManager.ConfirmEmailAsync(user, decode);
                if (result.Succeeded)
                {
                    user.Status = (int)AccountStatus.Active;
                    _userManager.UpdateAsync(user);
                    return;
                }
                throw new Exception("Oops, there is something wrong");
            }
            catch (Exception ex)
            {
                throw new Exception("Oops, there is something wrong");
            }
        }

        public async Task GenerateEmailConfimationAsync(UserDto model)
        {
            var user = _mapper.Map<User>(model);
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var url = _contextAccessor.HttpContext.Request.Scheme
                + "://"
                + _contextAccessor.HttpContext.Request.Host;
            var confirmUrl = url + "/email-verify"
                + "?email=" + user.Email
                + "&token=" + WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var content = new MailContent()
            {
                To = user.Email,
                Subject = "Xác minh tài khoản Novel Website",
                Body = EmailTemplate.GenerateEmailTemplate(user.UserName, confirmUrl)
            };
            await SendMail(content);
        }
    }
}
