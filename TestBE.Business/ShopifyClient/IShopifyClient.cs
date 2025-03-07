using ShopifySharp;
using TestBE.Infrastructure.Lifetimes;

namespace TestBE.Business.ShopifyClient;

public interface IShopifyClient : IScopedService
{
    Task<string> FetchShopifyAccessToken(string domain, string code);
    Task<Shop> GetShopInformation(string domain, string token);
}
