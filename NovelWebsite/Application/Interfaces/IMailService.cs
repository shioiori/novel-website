using Application.Models.Dtos;

namespace Application.Interfaces
{
    public interface IMailService
    {
        Task ConfirmEmailAsync(string email, string token);
        Task GenerateEmailConfimationAsync(UserDto model);
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}