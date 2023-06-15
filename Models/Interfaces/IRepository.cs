namespace Models.Interfaces;

public interface IRepository<T> where T : class
{
    public List<T> GetAll();

    public void Add(T type);
}