using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public abstract class InteractionService
    {
        public abstract bool IsInteractionEnabled(string tId, string uId, InteractionType type);
        public abstract bool SetStatusOfInteraction(string tId, string uId, InteractionType type);
    }
}