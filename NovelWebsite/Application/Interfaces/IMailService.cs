using NovelWebsite.Application.Models.Dtos;

namespace NovelWebsite.Application.Interfaces
{
    public interface IMailService
    {
        Task ConfirmEmailAsync(string email, string token);
        Task GenerateEmailConfimationAsync(UserDto model);
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}