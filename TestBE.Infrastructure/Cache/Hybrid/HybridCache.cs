

using Microsoft.Extensions.Caching.Hybrid;

namespace TestBE.Infrastructure.Cache.Hybrid;

public class HybridCache: ICacheService
{
    private readonly Microsoft.Extensions.Caching.Hybrid.HybridCache _hybridCache;
    public HybridCache(Microsoft.Extensions.Caching.Hybrid.HybridCache hybridCache)
    {
        _hybridCache = hybridCache;
    }

    public Task<T?> GetAsync<T>(string key)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(string key)
    {
        throw new NotImplementedException();
    }

    public async Task SetAsync<T>(string key, T value, TimeSpan? expiration)
    {
        var cacheOptions = new HybridCacheEntryOptions
        {
            Expiration = expiration ?? DefaultOptionCache.Expiration,
            LocalCacheExpiration = expiration ?? DefaultOptionCache.LocalCacheExpiration,
        };

        await _hybridCache.SetAsync(key, value, cacheOptions);
    }
}
