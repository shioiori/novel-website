using Application.Interfaces;
using NovelWebsite.Domain.Entities;
using Application.Services.Base;
using NovelWebsite.Domain.Enums;
using Application.Models.Dtos;
using Microsoft.EntityFrameworkCore;

namespace NovelWebsite.Application.Services
{
    public class ChapterInteractionService : GenericService<ChapterUsers, ChapterUserDto>, IInteractionService
    {
        public ChapterInteractionService() : base() { }

        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var chapter = await _repository.Get(x => x.ChapterId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefaultAsync();
            if (chapter == null)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var chapter = await _repository.Get(x => x.ChapterId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefaultAsync();
            if (chapter == null)
            {
                chapter = new ChapterUsers()
                {
                    ChapterId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _repository.InsertAsync(chapter);
                _repository.SaveAsync();
                return true;
            }
            _repository.Delete(chapter);
            _repository.SaveAsync();
            return false;
        }

    }
}
