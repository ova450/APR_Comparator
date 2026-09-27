using APRComparator.Domain.Common;

namespace APRC.Domain.Model.Offers;

/// <summary>
/// Диапазон ставок (спред) банка на определённую дату.
/// Соответствует таблице Spreads на ER-диаграмме.
/// </summary>
public class Spread : BaseEntity
{
    public int BankId { get; set; }
    public Bank Bank { get; set; } = null!;

    public DateTime Date { get; set; }
    public decimal Min { get; set; }
    public decimal Max { get; set; }

    public ICollection<SpreadValidation> Validations { get; set; } = new List<SpreadValidation>();
}
