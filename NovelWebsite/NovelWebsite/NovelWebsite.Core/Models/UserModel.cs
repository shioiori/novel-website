﻿using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Avatar { get; set; }
        public string? CoverPhoto { get; set; }
        public int AccountId { get; set; }
        public AccountRole Role {  get; set; }
        public AccountModel? Account { get; set; }
    }
}