using APRComparator.Domain.Common;

namespace APRC.Domain.Model.CBR;

/// <summary>
/// Привязка предельных значений ЦБ к отчётному периоду (год/квартал) и статус проверки.
/// Соответствует таблице CBR_validates на ER-диаграмме.
/// </summary>
public class CbrValidation : BaseEntity
{
    public int LimitId { get; set; }
    public CbrLimit Limit { get; set; } = null!;

    public DateTime ValidateDate { get; set; }
    public int Year { get; set; }
    public int Quarter { get; set; }
    public string? Status { get; set; }
}
