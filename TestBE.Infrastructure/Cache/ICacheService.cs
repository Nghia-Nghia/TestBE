using TestBE.Infrastructure.Lifetimes;

namespace TestBE.Infrastructure.Cache;

public interface ICacheService
{
    Task SetAsync<T>(string key, T value, TimeSpan? expiration = default);
    Task RemoveAsync(string key);
    Task<T?> GetAsync<T>(string key);
}
