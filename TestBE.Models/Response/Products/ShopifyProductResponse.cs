using System.Text.Json.Serialization;

namespace TestBE.Models.Response.Products;

public class ShopifyProductResponse
{
    [JsonPropertyName("data")]
    public ShopifyProductData Data { get; set; } = new();
}

public class ShopifyProductData
{
    [JsonPropertyName("products")]
    public ShopifyProductList Products { get; set; } = new();
}

public class ShopifyProductList
{
    [JsonPropertyName("edges")]
    public List<ShopifyProductEdge> Edges { get; set; } = new();
}

public class ShopifyProductEdge
{
    [JsonPropertyName("node")]
    public ShopifyProductNode Node { get; set; } = new();
}

public class ShopifyProductNode
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = string.Empty; 

    [JsonPropertyName("title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("handle")]
    public string Handle { get; set; } = string.Empty;
}
