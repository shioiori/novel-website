using LazyCache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using NovelWebsite.Entities;

public class CacheUpdateService : IHostedService
{
    private readonly IMemoryCache _cache;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IHostApplicationLifetime _appLifetime;

    public CacheUpdateService(IMemoryCache cacheProvider, IServiceScopeFactory scopeFactory, IHostApplicationLifetime appLifetime)
    {
        _cache = cacheProvider;
        _scopeFactory = scopeFactory;
        _appLifetime = appLifetime;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        if (!_cache.TryGetValue("cache_keys", out List<string> cachedList))
        {
            _cache.Set("cache_keys", new List<string>(), TimeSpan.FromMinutes(30));
        }
        _appLifetime.ApplicationStopping.Register(async () =>
        {
            await StopAsync(cancellationToken);
        });
        var timer = new Timer(UpdateDatabase, null, TimeSpan.Zero, TimeSpan.FromMinutes(30));
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        UpdateDatabase(null);    
    }

    public async void UpdateDatabase(object state)
    {
        using var scope = _scopeFactory.CreateScope();
        var _dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (_cache.TryGetValue("cache_keys", out List<string> cachedList))
        {
            foreach (var key in cachedList)
            {
                if (_cache.TryGetValue(key, out int value))
                {
                    var type = key.Split('-');
                    switch (type[0])
                    {
                        case "book":
                            var book = _dbContext.Books.Where(b => b.BookId == Int32.Parse(type[1])).FirstOrDefault();
                            book.Views = value;
                            break;
                        case "chapter":
                            var chapter = _dbContext.Chapters.Where(b => b.ChapterId == Int32.Parse(type[1])).FirstOrDefault();
                            chapter.Views = value;
                            break;
                    }
                }
            }
            await _dbContext.SaveChangesAsync();
        }
    }
}
