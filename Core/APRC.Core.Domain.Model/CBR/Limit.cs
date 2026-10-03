using APRC.Core.SharedKernel.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace APRC.Core.Domain.Model.CBR;

/// <summary>
/// Предельные/среднерыночные значения ПСК ЦБ РФ по категории на период.
/// </summary>
public class Limit : EntityBaseAbstract
{
    public int StrataId { get; set; }
    public Strata Strata { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")] public decimal RateAve { get; set; }   // среднерыночная ставка по категории на период в процентах

    [Column(TypeName = "decimal(18,2)")] public decimal RateMax { get; set; }   // предельная ставка по категории на период в процентах

    public DateTime DateFrom { get; set; }
    public int ValidYear { get; set; }
    public int ValidQuarter { get; set; }
    public string? Status { get; set; }
}
