using APRComparator.Domain.Common;

namespace APRComparator.Domain.Entities.Offers;

/// <summary>
/// Публичная оферта (кредитное предложение) банка.
/// Соответствует таблице Offers на ER-диаграмме.
/// </summary>
public class Offer : BaseEntity
{
    public int BankId { get; set; }
    public Bank Bank { get; set; } = null!;

    public int LoanTerm { get; set; }
    public int PaymentPeriodsPerYear { get; set; }

    // На диаграмме: AmountFinansed — исправлена опечатка в имени свойства домена
    public decimal AmountFinanced { get; set; }
    public decimal EquatedMonthlyInstallment { get; set; }
    public decimal CapitalizedFees { get; set; }

    // На диаграмме: LoanCasnback — исправлена опечатка в имени свойства домена
    public decimal LoanCashback { get; set; }

    // TODO: уточнить допустимые значения — возможно, стоит заменить на enum
    public string? Mode { get; set; }
    public string? Status { get; set; }
    public string? Comment { get; set; }

    public ICollection<OfferValidation> Validations { get; set; } = new List<OfferValidation>();
}
