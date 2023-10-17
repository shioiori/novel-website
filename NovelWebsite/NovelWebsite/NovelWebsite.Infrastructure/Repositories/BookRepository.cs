﻿using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        Expression<Func<Book, object>> sortType = x => x.GetType().GetProperty("PropertyName");

        public BookRepository(AppDbContext dbContext) : base(dbContext) { }

    }
}
