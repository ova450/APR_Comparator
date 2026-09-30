using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.FinOffers;

/// <summary>
/// Отметка о проверке актуальности спреда на определённую дату.
/// Соответствует таблице SpreadValidates на ER-диаграмме.
/// </summary>
public class SpreadValidation : EntityAbstract
{
    public int SpreadId { get; set; }
    public Spread Spread { get; set; } = null!;

    public DateTime ValidateDate { get; set; }
}
