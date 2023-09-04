using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IStatisticService
    {
        IEnumerable<BookModel> StatisticOfEachInteractionType(IEnumerable<BookModel> books, InteractionType type);
    }

}