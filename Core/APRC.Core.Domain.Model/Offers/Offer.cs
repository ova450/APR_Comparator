using APRC.Core.Domain.Model.FinancialBase;
using APRC.Core.SharedKernel.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace APRC.Core.Domain.Model.Offers;

/// <summary>
/// Оферта (кредитное предложение кредитной организации).
/// </summary>
public class Offer : EntityBaseAbstract
{
    public int BankId { get; set; }
    public Bank Bank { get; set; } = null!;
    public int CreditCategoryId { get; set; }
    public CreditCategory CreditCategory { get; set; } = null!;


    public int LoanTerm { get; set; }               // срок кредита в базовых единицах (например, месяцах)
    public int PaymentPeriodsPerYear { get; set; }  // количество платежных периодов в году (12 для ежемесячных платежей)
    [Column(TypeName = "decimal(18,2)")] public decimal AmountFinanced { get; set; } // сумма кредита, предоставляемая заемщику

    [Column(TypeName = "decimal(18,2)")] public decimal EquatedMonthlyInstallment { get; set; }  // равные периодические платежи, которые заемщик должен вносить

    [Column(TypeName = "decimal(18,2)")] public decimal CapitalizedFees { get; set; } // комиссии, которые могут быть добавлены к основной сумме кредита

    [Column(TypeName = "decimal(18,2)")] public decimal LoanCashback { get; set; } // сумма, возвращаемая заемщику в виде кэшбэка при погашении кредита

    public DateTime DateFrom { get; set; }

    public OfferStatus Status { get; set; } // флаги статуса (в БД хранится как int)
    public string? Comment { get; set; }
}
