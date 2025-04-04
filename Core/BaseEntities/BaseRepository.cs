using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.BaseEntities;

public class BaseRepository<T>: IRepository<T>
where T: class, IEntityWithUUID, new()
{
    private readonly DbContext _dbContext;

    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public virtual async Task<T> GetAsync(Guid id)
    {
        DbSet<T> set = _dbContext.Set<T>();
        T result = await set.AsNoTracking().FirstOrDefaultAsync(e => e.UUID == id);
        return result;
    }

    public virtual async Task<IEnumerable<T>> GetAsync(IEnumerable<Guid> ids)
    {
        DbSet<T> set = _dbContext.Set<T>();
        IEnumerable<T> result = await set.AsNoTracking().Where(e => ids.Contains(e.UUID)).ToListAsync();
        return result;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync()
    {
        DbSet<T> set = _dbContext.Set<T>();
        return set.AsNoTracking().ToList();
    }

    public virtual async Task DeleteAsync(Guid id)
    {
        DbSet<T> set = _dbContext.Set<T>();
        
        T entity = new T()
        {
            UUID = id
        };

        set.Remove(entity);
        await _dbContext.SaveChangesAsync();
    }

    public virtual async Task<T> CreateAsync(T entity)
    {
        DbSet<T> set = _dbContext.Set<T>();
        
        await set.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity)
    {
        DbSet<T> set = _dbContext.Set<T>();

        set.Update(entity);
        await _dbContext.SaveChangesAsync();

        return entity;
    }
}