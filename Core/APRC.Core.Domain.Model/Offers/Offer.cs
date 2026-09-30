using APRC.Core.Domain.FinStructure;
using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.FinOffers;

/// <summary>
/// Оферты (кредитное предложение) кредитных организаций.
/// </summary>
public class Offer : EntityAbstract
{
    public int BankId { get; set; }
    public Category Bank { get; set; } = null!;
    public int LoanTerm { get; set; }
    public int PaymentPeriodsPerYear { get; set; }
    public decimal AmountFinanced { get; set; }
    public decimal EquatedMonthlyInstallment { get; set; }
    public decimal CapitalizedFees { get; set; }
    public decimal LoanCashback { get; set; }

    // TODO: уточнить допустимые значения — возможно, стоит заменить на enum
    public string? Mode { get; set; }
    public string? Status { get; set; }
    public string? Comment { get; set; }

    public ICollection<OfferValidation> Validations { get; set; } = new List<OfferValidation>();
}
