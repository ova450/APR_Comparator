using APRC.Core.SharedKernel.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APRC.Core.SharedKernel.Abstractions
{
    public class RepositoryAbstractAsync<TEntity> : RepositoryAbstract<TEntity>, IRepositoryAsync<TEntity> where TEntity : class, IEntity
    {
        public RepositoryAbstractAsync(ContextAbstract databasecontext) : base(databasecontext) { }

        public async Task<IQueryable<TEntity>> GetAllAsync() => await Task.Run(() => GetAll());
        public async Task<IEnumerable<TEntity>> GetListAsync() => await Task.Run(() => GetList());

        public async Task<TEntity> GetItemAsync(int id) => await Task.Run(() => GetItem(id));

        public async Task<EntityEntry<TEntity>> AddAsync(TEntity entity) => await Task.Run(() => Add(entity));

        public async Task<EntityEntry<TEntity>> UpdateAsync(int id) => await Task.Run(() => Update(id));
        public async Task<EntityEntry<TEntity>> UpdateAsync(TEntity entity) => await Task.Run(() => Update(entity));

        public async Task<EntityEntry<TEntity>> RemoveAsync(int id) => await Task.Run(() => Remove(id));
        public async Task<EntityEntry<TEntity>> RemoveAsync(TEntity entity) => await Task.Run(() => Remove(entity));

        public async Task<int> CountAsync() => await Task.Run(() => Count());
    }
}