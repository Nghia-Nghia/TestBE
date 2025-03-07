using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ShopifySharp;
using System.Net;
using System.Text;
using TestBE.Shared.Configurations;

namespace TestBE.Business.ShopifyClient;

class ShopifyClient(IOptions<LimitPurchaseConfiguration> options) : IShopifyClient
{
    public async Task<string> FetchShopifyAccessToken(string domain, string code)
    {
        var endpointHost = $"https://{domain}/admin/oauth/access_token";
        using var client = new HttpClient();
        client.BaseAddress = new Uri(endpointHost);
        using var request = new HttpRequestMessage(HttpMethod.Post, client.BaseAddress);
        var contentParams = new StringContent(
            $"client_id={options.Value.ClientId}&code={code}&client_secret={options.Value.ClientSecret}",
            Encoding.UTF8,
            "application/x-www-form-urlencoded"
        );

        request.Content = contentParams;

        using var response = await client.SendAsync(request);
        if (response.StatusCode != HttpStatusCode.OK)
            return "";

        var resultJson = await response.Content.ReadAsStringAsync();
        var r = JsonConvert.DeserializeObject<dynamic>(resultJson);

        return r is null ? "" : Convert.ToString(r.access_token);
    }

    public async Task<Shop> GetShopInformation(string domain, string token)
    {
        var shopService = new ShopService(domain, token);
        return await shopService.GetAsync();
    }
}
