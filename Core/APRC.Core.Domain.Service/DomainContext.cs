using APRC.Core.Domain.Model.Offers;
using APRC.Core.SharedKernel.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace APRC.Core.Domain.Service;

/// <summary>
/// Контекст домена. Сущности регистрируются автоматически из сборки модели (см. ContextAbstract).
/// Провайдер БД (UseSqlServer и т. п.) задаётся при регистрации в хосте.
/// </summary>
public class DomainContext(DbContextOptions<DomainContext> options)
    : ContextAbstract(options, typeof(Bank).Assembly);
