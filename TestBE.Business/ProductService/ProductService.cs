using Microsoft.EntityFrameworkCore;
using TestBE.Infrastructure.Database;
using TestBE.Infrastructure.Database.Entities;
using TestBE.Models.Request.Products;

namespace TestBE.Business.ProductService;

public class ProductService(AppDbContext dbContext) : IProductService
{
    public Task<List<Product>> GetAll(OptionFilterProduct option)
    {
        return dbContext.Products
            .Skip((option.PageIndex - 1) * option.PageSize)
            .Take(option.PageSize)
            .ToListAsync();
    }
}
