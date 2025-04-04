using Core.Interfaces;

namespace Core.BaseEntities;

public class BaseService<T>: IService<T> where T: class
{
    private readonly IRepository<T> _repository;

    public BaseService(IRepository<T> repository)
    {
        _repository = repository;
    }
    
    public async Task<T> GetAsync(Guid id)
    {
        return await _repository.GetAsync(id);
    }

    public async Task<IEnumerable<T>> GetAsync(IEnumerable<Guid> ids)
    {
        return await _repository.GetAsync(ids);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        await _repository.DeleteAsync(id);
    }

    public async Task<T> CreateAsync(T entity)
    {
        return await _repository.CreateAsync(entity);
    }

    public async Task<T> UpdateAsync(T entity)
    {
        return await _repository.UpdateAsync(entity);
    }
}