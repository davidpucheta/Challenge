using Models.Data;
using Models.Interfaces;

namespace Repository;

public class CategoriesRepository : IRepository<Category>
{
    private readonly AppDbContext _appDbContext;

    public CategoriesRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IQueryable<Category> Get()
    {
        return _appDbContext.Categories;
    }

    public void Add(Category category)
    {
        _appDbContext.Categories.Add(category);
        _appDbContext.SaveChanges();
    }
}