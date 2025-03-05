namespace TestBE.Infrastructure.Database.Entities;

public partial class Store
{
    public Guid Id { get; set; }

    public string Domain { get; set; } = null!;

    public string Token { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ShopifyShopId { get; set; } = null!;

    public DateTime InstallDate { get; set; }

    public string MoneyWithCurrencyFormat { get; set; } = null!;

    public string Currency { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
