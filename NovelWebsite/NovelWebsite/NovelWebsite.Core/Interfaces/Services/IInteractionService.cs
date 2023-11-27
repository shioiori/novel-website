using NovelWebsite.NovelWebsite.Core.Enums;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IInteractionService
    {
        Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type);
        Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type);
    }
}