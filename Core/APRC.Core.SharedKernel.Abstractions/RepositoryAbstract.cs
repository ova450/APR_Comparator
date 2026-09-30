using APRC.Core.SharedKernel.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APRC.Core.SharedKernel.Abstractions;

public class RepositoryAbstract<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    protected DbSet<TEntity> _dbSet;

    public RepositoryAbstract(ContextAbstract databasecontext)
    {
        if (databasecontext == null) Console.WriteLine("Database not installed");
        try
        {
            _dbSet = databasecontext.Set<TEntity>();
        }
        catch (Exception ex) { Console.WriteLine($"Dataset <{typeof(TEntity).Name}> not setted to database context <{databasecontext.ContextId}>. ExceptionMessage: {ex.Message}"); }
    }

    public IQueryable<TEntity> GetAll() => _dbSet;

    public IEnumerable<TEntity> GetList() => _dbSet;

    public TEntity GetItem(int id)
    {
        var result = _dbSet.FirstOrDefault((p) => p.Id == id);
        if (result == null) Console.WriteLine($"'id' <{id}> not found");
        return result;
    }

    public EntityEntry<TEntity> Add(TEntity entity) => _dbSet.Add(entity);

    public EntityEntry<TEntity> Update(int id) => _dbSet.Update(GetItem(id));
    public EntityEntry<TEntity> Update(TEntity entity) => _dbSet.Update(entity);

    public EntityEntry<TEntity> Remove(int id) => _dbSet.Remove(GetItem(id));
    public EntityEntry<TEntity> Remove(TEntity entity) => _dbSet.Remove(entity);

    public int Count() => _dbSet.Count();
}
