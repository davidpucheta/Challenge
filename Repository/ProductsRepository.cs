using Models.Data;

namespace Repository;

public class ProductsRepository
{
    private readonly AppDbContext _appDbContext;

    public ProductsRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Product> GetAllProducts()
    {
        return _appDbContext.Products.ToList();
    }

    public void AddProduct(Product product)
    {
        _appDbContext.Products.Add(product);
        _appDbContext.SaveChanges();
    }
}