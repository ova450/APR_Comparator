using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APRC.Core.SharedKernel.Abstractions.Interfaces
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        Task<IQueryable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetListAsync();
        Task<TEntity> GetItemAsync(int id);
        Task<EntityEntry<TEntity>> AddAsync(TEntity entity);
        Task<EntityEntry<TEntity>> UpdateAsync(int id);
        Task<EntityEntry<TEntity>> UpdateAsync(TEntity entity);
        Task<EntityEntry<TEntity>> RemoveAsync(int id);
        Task<EntityEntry<TEntity>> RemoveAsync(TEntity entity);
        Task<int> CountAsync();
    }
}
