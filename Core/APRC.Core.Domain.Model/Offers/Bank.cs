using APRComparator.Domain.Common;

namespace APRC.Domain.Model.Offers;

/// <summary>
/// Банк — источник кредитных предложений (Offers) и спредов (Spreads).
/// </summary>
public class Bank : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string? Site { get; set; }
    public string? Email { get; set; }

    public ICollection<Offer> Offers { get; set; } = new List<Offer>();
    public ICollection<Spread> Spreads { get; set; } = new List<Spread>();
}
