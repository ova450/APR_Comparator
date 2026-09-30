using APRC.Core.Domain.FinStructure;
using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.FinOffers;

/// <summary>
/// Диапазон ставок (спред) банка на определённую дату.
/// Соответствует таблице Spreads на ER-диаграмме.
/// </summary>
public class Spread : EntityAbstract
{
    public int BankId { get; set; }
    public Category Bank { get; set; } = null!;

    public DateTime Date { get; set; }
    public decimal Min { get; set; }
    public decimal Max { get; set; }

    public ICollection<SpreadValidation> Validations { get; set; } = [];
}
