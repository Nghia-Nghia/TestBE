namespace TestBE.Shared.Configurations;

public class LimitPurchaseConfiguration
{
    public required string ClientId { get; set; }
    public required string ClientSecret { get; set; }
    public required string ShopifyWebhookUninstallUrl { get; set; }
    public required string ShopifyAppHandle { get; set; }
    public required string Scope { get; set; }
    public required string ShopifyAppUrl { get; set; }
    public required string GraphqlAdminApi { get; set; }
    public required string ValidationFunctionId { get; set; }
    public required string FunctionNameSpace { get; set; }
    public required string FunctionKeyInputValidation { get; set; }
    public required string FunctionKeyValidation { get; set; }
    public required string MetafieldValidation { get; set; }

    public required string MetafieldParameter { get; set; }
    public required string AppBlockId { get; set; }
}
