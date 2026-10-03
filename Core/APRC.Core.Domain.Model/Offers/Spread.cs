using APRC.Core.SharedKernel.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace APRC.Core.Domain.Model.Offers;

/// <summary>
/// Текущий диапазон ставок (спред) банка.
/// </summary>
public class Spread : EntityBaseAbstract
{
    public int BankId { get; set; }
    public Bank Bank { get; set; } = null!;

    [Column(TypeName = "decimal(18,2)")] public decimal Min { get; set; }   // минимальная ставка, предлагаемая банком в процентах
    [Column(TypeName = "decimal(18,2)")] public decimal Max { get; set; }   // максимальная ставка, предлагаемая банком в процентах

    public DateTime DateFrom { get; set; }
}
