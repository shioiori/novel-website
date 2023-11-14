using NovelWebsite.NovelWebsite.Core.Enums;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IInteractionService
    {
        bool IsInteractionEnabled(string tId, string uId, InteractionType type);
        bool SetStatusOfInteraction(string tId, string uId, InteractionType type);
    }
}