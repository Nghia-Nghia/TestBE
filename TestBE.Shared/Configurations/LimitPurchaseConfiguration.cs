namespace TestBE.Shared.Configurations;

public class LimitPurchaseConfiguration
{
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
    public required string ShopifyWebhookUninstallUrl { get; set; }
    public required string ShopifyAppHandle { get; set; }
}
