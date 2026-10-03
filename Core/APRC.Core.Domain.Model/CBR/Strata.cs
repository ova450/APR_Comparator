using APRC.Core.Domain.Model.FinancialBase;
using APRC.Core.SharedKernel.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace APRC.Core.Domain.Model.CBR;

public class Strata : EntityBaseAbstract
{
    public int BankCategoryId { get; set; }
    public BankCategory BankCategory { get; set; } = null!;
    public int CreditCategoryId { get; set; }
    public CreditCategory CreditCategory { get; set; } = null!;

    public IList<Limit> Limits { get; set; } = [];

    [Column(TypeName = "decimal(18,2)")] public decimal StrataUpperLimit { get; set; } = 0; // верхняя граница страты (например, 1000000 для страты "до 1 млн. руб.")
}
