using APRComparator.Domain.Common;
using APRComparator.Domain.Entities.CBR;

namespace APRComparator.Domain.Entities;

/// <summary>
/// Предельные/среднерыночные значения ПСК ЦБ РФ по категории на период.
/// Соответствует таблице CBR_limits на ER-диаграмме.
/// </summary>
public class CbrLimit : BaseEntity
{
    public int CategoryId { get; set; }
    public CbrCategory Category { get; set; } = null!;

    public decimal LargeSumMinimum { get; set; }
    public decimal LargeSumAve { get; set; }
    public decimal LargeSumMax { get; set; }
    public decimal SimAve { get; set; }
    public decimal SumMax { get; set; }

    public ICollection<CbrValidation> Validations { get; set; } = new List<CbrValidation>();
}
