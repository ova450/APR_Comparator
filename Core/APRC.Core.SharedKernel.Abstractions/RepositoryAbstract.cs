using APRC.Core.SharedKernel.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APRC.Core.SharedKernel.Abstractions;

public class RepositoryAbstract<TEntity>(ContextAbstract context) : IRepository<TEntity> where TEntity : class, IEntityBase
{
    protected readonly DbSet<TEntity> _dbSet =
    (context ?? throw new ArgumentNullException(nameof(context))).Set<TEntity>();

    public IQueryable<TEntity> GetAll() => _dbSet;

    public EntityEntry<TEntity> Add(TEntity entity) => _dbSet.Add(entity);

    public EntityEntry<TEntity> Update(TEntity entity) => _dbSet.Update(entity);

    public EntityEntry<TEntity> Remove(TEntity entity) => _dbSet.Remove(entity);

    public TEntity? GetItem(int id) => _dbSet.Find(id);

    public List<TEntity> GetList() => _dbSet.ToList();

    public int Count() => _dbSet.Count();

    public async Task<TEntity?> GetItemAsync(int id, CancellationToken cancellationToken = default)
        => await _dbSet.FindAsync(new object?[] { id }, cancellationToken);

    public Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default)
        => _dbSet.ToListAsync(cancellationToken);

    public Task<int> CountAsync(CancellationToken cancellationToken = default)
        => _dbSet.CountAsync(cancellationToken);

    public async Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await GetItemAsync(id, cancellationToken);
        if (entity is null) return false;
        _dbSet.Remove(entity);
        return true;
    }
}
