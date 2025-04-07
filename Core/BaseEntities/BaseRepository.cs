using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Core.BaseEntities;

public class BaseRepository<T> : IRepository<T>
    where T : class, IEntityWithUUID, new()
{
    private readonly DbContext _dbDataContext;

    public BaseRepository(DbContext dbDataContext)
    {
        _dbDataContext = dbDataContext;
    }

    public virtual async Task<T> GetAsync(Guid id, CancellationToken token)
    {
        DbSet<T> set = _dbDataContext.Set<T>();
        T result = await set.AsNoTracking().FirstOrDefaultAsync(e => e.UUID == id);
        return result;
    }

    public virtual async Task<IEnumerable<T>> GetAsync(IEnumerable<Guid> ids, CancellationToken token)
    {
        DbSet<T> set = _dbDataContext.Set<T>();
        IEnumerable<T> result = await set.AsNoTracking().Where(e => ids.Contains(e.UUID)).ToListAsync();
        return result;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken token)
    {
        DbSet<T> set = _dbDataContext.Set<T>();
        return set.AsNoTracking().ToList();
    }

    public virtual async Task DeleteAsync(Guid id, CancellationToken token)
    {
        DbSet<T> set = _dbDataContext.Set<T>();

        T entity = new T()
        {
            UUID = id
        };

        set.Remove(entity);
        await _dbDataContext.SaveChangesAsync();
    }

    public virtual async Task<T> CreateAsync(T entity, CancellationToken token)
    {
        DbSet<T> set = _dbDataContext.Set<T>();

        await set.AddAsync(entity);
        await _dbDataContext.SaveChangesAsync();

        return entity;
    }

    public virtual async Task<T> UpdateAsync(T entity, CancellationToken token)
    {
        DbSet<T> set = _dbDataContext.Set<T>();

        set.Update(entity);
        await _dbDataContext.SaveChangesAsync();

        return entity;
    }
}