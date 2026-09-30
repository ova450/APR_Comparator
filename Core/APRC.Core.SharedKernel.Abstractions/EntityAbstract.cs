using APRC.Core.SharedKernel.Abstractions.Interfaces;

namespace APRC.Core.SharedKernel.Abstractions;

/// <summary>
/// Базовый абстрактный класс для всех сущностей домена. Содержит суррогатный первичный ключ.
/// </summary>
public abstract class EntityBaseAbstract:IEntityBase
{
    public int Id { get; set; }
}

/// <summary>
/// Именованный базовый абстрактный класс для всех сущностей домена. Содержит суррогатный первичный ключ и свойство Name.
/// </summary>
public abstract class EntityAbstract : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
