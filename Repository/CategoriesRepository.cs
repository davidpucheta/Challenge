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

    public List<Category> GetAll()
    {
        return _appDbContext.Categories.ToList();
    }

    public void Add(Category category)
    {
        _appDbContext.Categories.Add(category);
        _appDbContext.SaveChanges();
    }
}