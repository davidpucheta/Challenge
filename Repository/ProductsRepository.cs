using Models.Data;
using Models.Interfaces;

namespace Repository;

public class ProductsRepository : IRepository<Product>
{
    private readonly AppDbContext _appDbContext;

    public ProductsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<Product> Get()
    {
        return _appDbContext.Products;
    }

    public void Add(Product product)
    {
        _appDbContext.Products.Add(product);
        _appDbContext.SaveChanges();
    }
}