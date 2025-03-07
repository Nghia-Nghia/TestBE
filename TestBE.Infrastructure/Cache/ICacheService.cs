using TestBE.Infrastructure.Lifetimes;

namespace TestBE.Infrastructure.Cache;

public interface ICacheService: ISingletonService
{
    Task SetAsync<T>(string key, T value, TimeSpan? expiration);
    Task RemoveAsync(string key);
    Task<T?> GetAsync<T>(string key);
}
