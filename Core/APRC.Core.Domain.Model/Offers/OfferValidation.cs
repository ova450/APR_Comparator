using APRComparator.Domain.Common;

namespace APRComparator.Domain.Entities.Offers;

/// <summary>
/// Отметка о проверке актуальности публичной оферты на определённую дату.
/// Соответствует таблице OfferValidates на ER-диаграмме.
/// </summary>
public class OfferValidation : BaseEntity
{
    public int OfferId { get; set; }
    public Offer Offer { get; set; } = null!;

    public DateTime ValidateDate { get; set; }
}
