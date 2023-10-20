using NovelWebsite.NovelWebsite.Core.Enums;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IInteractionService
    {
        bool IsInteractionEnabled(int tId, int uId, InteractionType type);
        bool SetStatusOfInteraction(int tId, int uId, InteractionType type);
    }
}