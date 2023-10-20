using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public abstract class InterationService : IInteractionService
    {
        public abstract bool IsInteractionEnabled(int tId, int uId, InteractionType type);
        public abstract bool SetStatusOfInteraction(int tId, int uId, InteractionType type);
    }
}