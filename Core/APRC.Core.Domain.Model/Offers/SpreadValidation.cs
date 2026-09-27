using APRComparator.Domain.Common;

namespace APRComparator.Domain.Entities.Offers;

/// <summary>
/// Отметка о проверке актуальности спреда на определённую дату.
/// Соответствует таблице SpreadValidates на ER-диаграмме.
/// </summary>
public class SpreadValidation : BaseEntity
{
    public int SpreadId { get; set; }
    public Spread Spread { get; set; } = null!;

    public DateTime ValidateDate { get; set; }
}
