namespace APRC.Core.SharedKernel.Abstractions.Interfaces;

/// <summary>
/// Интерфейс для всех сущностей домена. Содержит суррогатный первичный ключ.
/// </summary>
public interface IEntityBase
{
    public int Id { get; set; }
}

/// <summary>
/// Интерфейс для именованных сущностей домена. Содержит суррогатный первичный ключ и свойство Name.
/// </summary>
public interface IEntity : IEntityBase
{
    public string Name { get; set; }
}
