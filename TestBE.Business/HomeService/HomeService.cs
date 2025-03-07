
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TestBE.Business.ShopifyClient;
using TestBE.Business.WebhookService;
using TestBE.Infrastructure.Cache;
using TestBE.Infrastructure.Database;
using TestBE.Infrastructure.Database.Entities;
using TestBE.Models.Dtos;
using TestBE.Models.Models.Webhook;
using TestBE.Shared.Configurations;

namespace TestBE.Business.HomeService;

public class HomeService(
    AppDbContext dbContext,
    IShopifyClient shopifyClient,
    IOptions<LimitPurchaseConfiguration> options,
    IRegisterWebhookService registerWebhookService,
    ICacheService cacheService) : IHomeService
{
    public async Task<string> Auth(string domain, string code)
    {
        var token = await shopifyClient.FetchShopifyAccessToken(domain, code);
        var shopInfo = await shopifyClient.GetShopInformation(domain, token);

        var storeFromRepo = await dbContext.Stores
            .FirstOrDefaultAsync(s => s.Domain.ToLower() == domain.ToLower());

        if (storeFromRepo is null)
        {
            storeFromRepo = new Store
            {
                Domain = domain,
                Token = token,
                Email = shopInfo.Email ?? string.Empty,
                InstallDate = DateTime.UtcNow,
                MoneyWithCurrencyFormat =
                    shopInfo.MoneyWithCurrencyFormat ?? string.Empty,
                Currency = shopInfo.Currency ?? string.Empty,
            };

            await dbContext.Stores.AddAsync(storeFromRepo);
            await dbContext.SaveChangesAsync();

            await registerWebhookService.RegisterUninstallWebhook(
                new RegisterUninstallModel(
                    storeFromRepo.Id,
                    storeFromRepo.Domain,
                    storeFromRepo.Token
                )
            );
        }
        else
        {
            storeFromRepo.Token = token;
            storeFromRepo.MoneyWithCurrencyFormat = shopInfo.MoneyWithCurrencyFormat;
            storeFromRepo.Currency = shopInfo.Currency;
            storeFromRepo.Email = shopInfo.Email;
            storeFromRepo.InstallDate = DateTime.UtcNow;
            await dbContext.SaveChangesAsync();
        }

        var key = $"limit-shop-data-{domain}";
        await cacheService.SetAsync(
            key,
            new ShopDto
            {
                Domain = storeFromRepo.Domain,
                Currency = storeFromRepo.Currency,
                Id = storeFromRepo.Id,
            }
        );

        return $"https://{domain}/admin/apps/{options.Value.ShopifyAppHandle}";

    }
}
