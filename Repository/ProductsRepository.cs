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

    public List<Product> GetAll()
    {
        return _appDbContext.Products.ToList();
    }

    public void Add(Product product)
    {
        _appDbContext.Products.Add(product);
        _appDbContext.SaveChanges();
    }
}