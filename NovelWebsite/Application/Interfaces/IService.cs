﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelWebsite.NovelWebsite.Application.Interfaces
{
    public interface IService<TDto>
    {
        Task<TDto> AddAsync(TDto obj);
        Task<TDto> UpdateAsync(TDto obj);
        Task DeleteAsync(object id);
        Task DeleteAsync(TDto obj);
    }
}