namespace Core.Interfaces;

public interface IService<T> where T: class
{
    Task<T> GetAsync(Guid id);

    Task<IEnumerable<T>> GetAsync(IEnumerable<Guid> ids);

    Task<IEnumerable<T>> GetAllAsync();

    Task DeleteAsync(Guid id);

    Task<T> CreateAsync(T entity);

    Task<T> UpdateAsync(T entity);
}