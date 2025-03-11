using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Text.Json;
using TestBE.Infrastructure.Database;
using TestBE.Infrastructure.Database.Entities;
using TestBE.Models.Request.Products;
using TestBE.Models.Response.Products;

namespace TestBE.Business.ProductService;

public class ProductService : IProductService
{
    private readonly HttpClient _httpClient;
    private readonly AppDbContext dbContext;
    public ProductService(IHttpClientFactory httpClientFactory, AppDbContext dbContext)
    {
        _httpClient = httpClientFactory.CreateClient("ResilientHttpClient");
        this.dbContext = dbContext;
    }
    public Task<List<Product>> GetAll(OptionFilterProduct option)
    {
        return dbContext.Products
            .Skip((option.PageIndex - 1) * option.PageSize)
            .Take(option.PageSize)
            .ToListAsync();
    }
    public async Task<List<Product>> GetProductsAsync(string domain, string? cursor, int pageSize)
    {
        var query = new
        {
            query = $@"
                    {{
                        products(first: {pageSize} {(string.IsNullOrEmpty(cursor) ? "" : $"after: \"{cursor}\"")}) {{
                            edges {{
                                node {{
                                    id
                                    title
                                    handle
                                }}
                            }}
                        }}
                    }}"
        };
        Store? store = await dbContext.Stores.FirstOrDefaultAsync(x => x.Domain == domain);
        if (store is null) { throw new Exception(); }
        _httpClient.BaseAddress = new Uri($"https://{domain}/admin/api/2025-01/graphql.json");
        _httpClient.DefaultRequestHeaders.Add("X-Shopify-Access-Token", store.Token); 
        var jsonContent = new StringContent(JsonSerializer.Serialize(query), Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("", jsonContent);
        response.EnsureSuccessStatusCode();
        var jsonResponse = await response.Content.ReadAsStringAsync();
        var shopifyData = JsonSerializer.Deserialize<ShopifyProductResponse>(jsonResponse, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (shopifyData?.Data?.Products?.Edges == null)
        {
            return new List<Product>();
        }
        List<Product>? products = shopifyData?.Data?.Products?.Edges.Select(x => new Product()
        {
            Title = x.Node.Title,
            Handle = x.Node.Handle,
        }).ToList();
        return products ?? new List<Product>();
    }

}
