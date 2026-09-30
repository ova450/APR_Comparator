using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.FinStructure;

/// <summary>
/// Кредитные организации — источники кредитных предложений (Offers) и спредов (Spreads).
/// </summary>
public class Bank : EntityAbstract
{
    public string? Site { get; set; }
    public string? Email { get; set; }

    public IList<Offers> Offers { get; set; } = [];
    public IList<Spreads> Spreads { get; set; } = [];
}
