using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.FinOffers;

/// <summary>
/// Отметка о проверке актуальности публичной оферты на определённую дату.
/// </summary>
public class OfferValidation : EntityAbstract
{
    public int OfferId { get; set; }
    public Offer Offer { get; set; } = null!;

    public DateTime ValidateDate { get; set; }
}
