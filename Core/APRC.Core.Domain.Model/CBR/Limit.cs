using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.CBR;

/// <summary>
/// Предельные/среднерыночные значения ПСК ЦБ РФ по категории на период.
/// </summary>
public class Limit : EntityAbstract
{
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public int BankCategoryId { get; set; }
    public FinStructure.Category BankCategory { get; set; } = null!;

    public decimal LargeSumMinimum { get; set; }
    public decimal LargeSumAve { get; set; }
    public decimal LargeSumMax { get; set; }
    public decimal SimAve { get; set; }
    public decimal SumMax { get; set; }

    public IList<Validation> Validations { get; set; } = [];
}
