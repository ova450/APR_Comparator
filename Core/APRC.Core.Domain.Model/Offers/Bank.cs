using APRC.Core.Domain.Model.FinancialBase;
using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.Model.Offers;

/// <summary>
/// Кредитная организация.
/// </summary>
public class Bank : EntityAbstract
{
    public int BankCategoryId { get; set; }
    public BankCategory BankCategory { get; set; } = null!;

    public string? Phone { get; set; }
    public string? Email { get; set; }
    public string? Site { get; set; }


}
