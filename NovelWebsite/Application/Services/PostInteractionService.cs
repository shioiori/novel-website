﻿
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Dtos;
using Application.Services.Base;
using AutoMapper;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class PostInteractionService : GenericService<PostUsers, PostUserDto>, IPostInteractionService
    {
        public PostInteractionService(IPostUserRepository postUserRepository, IMapper mapper) : base(postUserRepository, mapper) { }
        public async Task<bool> IsInteractionEnabledAsync(string tId, string uId, InteractionType type)
        {
            var post = _repository.Get(x => x.PostId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefault();
            if (post == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SetStatusOfInteractionAsync(string tId, string uId, InteractionType type)
        {
            var post = _repository.Get(x => x.PostId == tId && x.UserId == uId && x.InteractionId == (int)type).FirstOrDefault();
            if (post == null)
            {
                post = new PostUsers()
                {
                    PostId = tId,
                    UserId = uId,
                    InteractionId = (int)type,
                };
                await _repository.InsertAsync(post);
                _repository.SaveAsync();
                return true;
            }
            _repository.Delete(post);
            _repository.SaveAsync();
            return false;
        }

    }
}