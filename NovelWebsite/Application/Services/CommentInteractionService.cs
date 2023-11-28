﻿using Application.Interfaces;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using Application.Models.Dtos;
using NovelWebsite.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace NovelWebsite.Application.Services
{
    public class CommentInteractionService : GenericService<CommentUsers, CommentUserDto>, IInteractionService
    {
        public CommentInteractionService() : base() { }

        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var comment = await _repository.Get(x => x.CommentId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefaultAsync();
            if (comment == null)
            {
                return false;
            }
            return true;
        }
        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var comment = await _repository.Get(x => x.CommentId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefaultAsync();
            if (comment == null)
            {
                comment = new CommentUsers()
                {
                    CommentId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _repository.InsertAsync(comment);
                _repository.SaveAsync();
                return true;
            }
            _repository.Delete(comment);
            _repository.SaveAsync();
            return false;
        }

    }
}
