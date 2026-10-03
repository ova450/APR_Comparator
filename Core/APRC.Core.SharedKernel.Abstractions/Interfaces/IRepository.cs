using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace APRC.Core.SharedKernel.Abstractions.Interfaces;

/// <summary>
/// Репозиторий сущностей с суррогатным ключом Id.
/// Методы без обращения к БД синхронные. Методы, которые обращаются к БД, есть в двух вариантах:
/// асинхронном (предпочтительный) и синхронном (блокирует поток, для консоли, тестов и WinForms).
/// Изменения попадают в БД только после SaveChanges контекста.
/// </summary>
public interface IRepository<TEntity> where TEntity : class, IEntityBase
{
    // --- Без обращения к БД: строят запрос или меняют состояние в ChangeTracker ---

    /// <summary>Запрос ко всем записям. Выполняется у вызывающего (ToListAsync, FirstOrDefaultAsync и т. д.).</summary>
    IQueryable<TEntity> GetAll();

    EntityEntry<TEntity> Add(TEntity entity);

    /// <summary>Помечает сущность (и связанные с ней) как изменённую. Нужен для отсоединённых сущностей.</summary>
    EntityEntry<TEntity> Update(TEntity entity);

    EntityEntry<TEntity> Remove(TEntity entity);

    // --- Обращаются к БД: синхронные варианты (блокируют поток) ---

    /// <summary>Возвращает сущность по Id или null, если она не найдена.</summary>
    TEntity? GetItem(int id);

    List<TEntity> GetList();

    int Count();

    // --- Обращаются к БД: асинхронные варианты ---

    /// <summary>Возвращает сущность по Id или null, если она не найдена.</summary>
    Task<TEntity?> GetItemAsync(int id, CancellationToken cancellationToken = default);

    Task<List<TEntity>> GetListAsync(CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);

    /// <summary>Находит сущность по Id и помечает её на удаление. Возвращает false, если не найдена.</summary>
    Task<bool> RemoveAsync(int id, CancellationToken cancellationToken = default);
}
