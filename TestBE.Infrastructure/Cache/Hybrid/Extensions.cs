using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Hybrid;


namespace TestBE.Infrastructure.Cache.Hybrid;

public static class Extensions
{
    public static void RegisterHybridCacheClient(this WebApplicationBuilder builder)
    {
        //builder.Services.AddHybridCache(options =>
        //{
        //    options.MaximumPayloadBytes = 1024 * 1024 * 10;
        //    options.MaximumKeyLength = 512;

        //    options.DefaultEntryOptions = new HybridCacheEntryOptions
        //    {
        //        Expiration = TimeSpan.FromDays(30),
        //        LocalCacheExpiration = TimeSpan.FromDays(365),
        //    };
        //});
    }
}
