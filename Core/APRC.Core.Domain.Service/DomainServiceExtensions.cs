using APRC.Core.Domain.Service.Repositories;
using APRC.Core.SharedKernel.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace APRC.Core.Domain.Service;

public static class DomainServiceExtensions
{
    /// <summary>
    /// Регистрирует контекст домена и репозитории.
    /// Провайдер БД задаётся в <paramref name="configureDb"/>, например: o => o.UseSqlServer(connectionString).
    /// Чтобы подменить реализацию, зарегистрируйте свою после вызова этого метода.
    /// </summary>
    public static IServiceCollection AddDomainService(
        this IServiceCollection services, Action<DbContextOptionsBuilder> configureDb)
    {
        services.AddDbContext<DomainContext>(configureDb);
        services.AddScoped<ContextAbstract>(sp => sp.GetRequiredService<DomainContext>());

        services.AddScoped<IBankCategoryRepository, BankCategoryRepository>();
        services.AddScoped<ICreditCategoryRepository, CreditCategoryRepository>();
        services.AddScoped<IBankRepository, BankRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<ISpreadRepository, SpreadRepository>();
        services.AddScoped<IStrataRepository, StrataRepository>();
        services.AddScoped<ILimitRepository, LimitRepository>();

        return services;
    }
}
