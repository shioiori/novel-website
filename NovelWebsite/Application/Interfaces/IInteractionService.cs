using NovelWebsite.Domain.Enums;

namespace Application.Interfaces
{
    public interface IInteractionService
    {
        Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type);
        Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
    }
}