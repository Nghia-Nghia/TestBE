
using Microsoft.Extensions.Caching.Memory;

namespace TestBE.Infrastructure.Cache.Memory;

public class MemoryCache : ICacheService
{
    private readonly IMemoryCache _cache;

    public MemoryCache(IMemoryCache cache)
    {
        _cache = cache;
    }
    public async Task<T?> GetAsync<T>(string key)
    {
        if (_cache.TryGetValue(key, out T? value))
        {
            return value; 
        }
       await Task.CompletedTask;
       return default;
    }

    public Task RemoveAsync(string key)
    {
        _cache.Remove(key);
        return Task.CompletedTask;
    }

    public Task SetAsync<T>(string key, T value, TimeSpan? expiration = default)
    {
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration ?? DefaultOptionCache.Expiration
        };

        _cache.Set(key, value, cacheEntryOptions);
        return Task.CompletedTask;
    }
}
