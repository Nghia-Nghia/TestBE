using Hangfire;
using Microsoft.Extensions.Options;
using ShopifySharp;
using System.Collections.Generic;
using TestBE.Infrastructure.Cache.Hybrid;
using TestBE.Infrastructure.Database.Entities;
using TestBE.Models.Models.Webhook;
using TestBE.Shared.Configurations;

namespace TestBE.Business.WebhookService;

class RegisterWebhookService(
     IOptions<LimitPurchaseConfiguration> setting )
    : IRegisterWebhookService
{
    public async Task RegisterUninstallWebhook(RegisterUninstallModel store)
    {
        var serviceWebhook = new ShopifySharp.WebhookService(store.Domain, store.Token);
        var newWebhook = new Webhook
        {
            Address = setting.Value.ShopifyWebhookUninstallUrl,
            CreatedAt = DateTime.Now,
            Format = "json",
            Topic = "app/uninstalled",
        };
        var uninstallEvent = await serviceWebhook.CreateAsync(newWebhook);

        if (uninstallEvent is null)
            return;
    }

}
