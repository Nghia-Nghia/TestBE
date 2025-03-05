namespace TestBE.Infrastructure.Database.Entities;

public partial class Product
{
    public Guid Id { get; set; }

    public long ShopifyProductId { get; set; }

    public Guid StoreId { get; set; }

    public string Title { get; set; } = null!;

    public string Handle { get; set; } = null!;

    public virtual Store Store { get; set; } = null!;

    public virtual ICollection<Variant> Variants { get; set; } = new List<Variant>();
}
