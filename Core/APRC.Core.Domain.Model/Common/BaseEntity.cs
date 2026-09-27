namespace APRC.Domain.Model.Common;

/// <summary>
/// Базовый класс для всех сущностей домена. Содержит суррогатный первичный ключ.
/// </summary>
public abstract class BaseEntity
{
    public int Id { get; set; }
}
