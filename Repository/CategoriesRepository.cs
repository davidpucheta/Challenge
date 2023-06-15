using Models.Data;

namespace Repository;

public class CategoriesRepository
{
    private readonly AppDbContext _appDbContext;

    public CategoriesRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public List<Category> GetAllProducts()
    {
        return _appDbContext.Categories.ToList();
    }

    public void AddProduct(Category category)
    {
        _appDbContext.Categories.Add(category);
        _appDbContext.SaveChanges();
    }
}