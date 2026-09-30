using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APRC.Core.SharedKernel.Abstractions.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        IEnumerable<TEntity> GetList();

        TEntity GetItem(int id);
        EntityEntry<TEntity> Add(TEntity entity);
        EntityEntry<TEntity> Update(int id);
        EntityEntry<TEntity> Update(TEntity entity);
        EntityEntry<TEntity> Remove(int id);
        EntityEntry<TEntity> Remove(TEntity entity);
        int Count();
    }
}