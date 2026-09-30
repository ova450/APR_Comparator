using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.CBR;

/// <summary>
/// Привязка предельных значений ЦБ к отчётному периоду (год/квартал) и статус проверки.
/// </summary>
public class Validation : EntityAbstract
{
    public int LimitId { get; set; }
    public Limit Limits { get; set; } = null!;

    public DateTime ValidateDate { get; set; }
    public int Year { get; set; }
    public int Quarter { get; set; }
    public string? Status { get; set; }
}
