using APRC.Core.SharedKernel.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace APRC.Core.SharedKernel.Abstractions;

/// <summary>
/// Базовый контекст.
/// Сущности: автоматически регистрирует в модели все неабстрактные классы, реализующие IEntityBase,
/// из сборки <paramref name="entitiesAssembly"/> (DbSet в производном контексте не нужны).
/// Сохранение изменений (SaveChanges, SaveChangesAsync) унаследовано от DbContext.
/// База данных: проверяет наличие БД и создаёт её, если её нет.
/// </summary>
public abstract class ContextAbstract(DbContextOptions options, Assembly entitiesAssembly) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        foreach (var type in entitiesAssembly.GetTypes().Where(IsEntity))
            modelBuilder.Entity(type);
    }

    private static bool IsEntity(Type type)
        => type is { IsClass: true, IsAbstract: false, IsNested: false, IsGenericTypeDefinition: false }
           && typeof(IEntityBase).IsAssignableFrom(type);

    /// <summary>
    /// Если в сборке есть миграции, применяет их (создаёт БД при необходимости);
    /// иначе создаёт БД и схему по модели (EnsureCreated).
    /// </summary>
    public void EnsureDatabase()
    {
        if (Database.GetMigrations().Any()) Database.Migrate();
        else Database.EnsureCreated();
    }

    public async Task EnsureDatabaseAsync(CancellationToken cancellationToken = default)
    {
        if (Database.GetMigrations().Any()) await Database.MigrateAsync(cancellationToken);
        else await Database.EnsureCreatedAsync(cancellationToken);
    }
}

