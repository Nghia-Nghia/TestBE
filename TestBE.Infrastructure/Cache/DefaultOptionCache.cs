namespace TestBE.Infrastructure.Cache;

internal static class DefaultOptionCache
{
    public static TimeSpan Expiration = TimeSpan.FromDays(30);
    public static TimeSpan LocalCacheExpiration = TimeSpan.FromDays(365);
}
