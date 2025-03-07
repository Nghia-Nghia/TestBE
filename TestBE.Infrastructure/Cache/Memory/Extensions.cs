using Microsoft.Extensions.DependencyInjection;

namespace TestBE.Infrastructure.Cache.Memory
{
    public static class Extensions
    {
        public static IServiceCollection RegisterMemoryCacheClient(this IServiceCollection services)
        =>
            services
                .AddSingleton<ICacheService, MemoryCache>()
                .AddMemoryCache();
    }
}
