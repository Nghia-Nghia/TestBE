namespace TestBE.Infrastructure.Database.Entities;

public partial class Variant
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    public Guid ProductId { get; set; }

    public virtual Product Product { get; set; } = null!;
}
