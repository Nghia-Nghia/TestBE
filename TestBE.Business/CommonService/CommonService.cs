using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using TestBE.Business.ShopifyClient;
using TestBE.Infrastructure.Auth;
using TestBE.Infrastructure.Cache;
using TestBE.Infrastructure.Database;
using TestBE.Models.Dtos;
using TestBE.Models.Response.Common;

namespace TestBE.Business.CommonService;

public class CommonService(
    AppDbContext dbContext,
    ITokenService tokenService,
    ICacheService cacheService) : ICommonService
{
    public async Task<ShopInfoResponse> GetShopData(string domain)
    {

        var key = $"limit-shop-data-{domain}";
        ShopDto? shop = await cacheService.GetAsync<ShopDto>(key);

        if( shop is null)
        {
            shop = await dbContext.Stores.Where(x => x.Domain == domain).Select(x => new ShopDto
            {
                Id = x.Id,
                Currency = x.Currency,
                Domain = domain
            }).FirstOrDefaultAsync();

            if( shop is null ) { throw new Exception(); }

            await cacheService.SetAsync(key, shop);
        }

        var token = tokenService.GenerateJwt(domain, shop.Id);
        return new ShopInfoResponse(shop, token);
    }
}
