using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.CBR;

/// <summary>
/// Категории потребительского кредита, для которой ЦБ РФ публикует
/// среднерыночное значение полной стоимости кредита (ПСК).
/// </summary>
public class Category : EntityAbstract
{
    public IList<Limit> Limits { get; set; } = [];
}
