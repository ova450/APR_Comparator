using APRC.Domain.Model.Common;

namespace APRC.Domain.Model.CBR;

/// <summary>
/// Категория потребительского кредита, для которой ЦБ РФ публикует
/// среднерыночное значение полной стоимости кредита (ПСК).
/// Соответствует таблице CBR_Categories на ER-диаграмме.
/// </summary>
public class CbrCategory : BaseEntity
{
    public string Category { get; set; } = string.Empty;

    public ICollection<CbrLimit> Limits { get; set; } = new List<CbrLimit>();
}
