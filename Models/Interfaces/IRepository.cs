namespace Models.Interfaces;

public interface IRepository<T> where T : class
{
    public IQueryable<T> Get();

    public void Add(T type);
}