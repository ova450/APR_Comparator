using APRC.Core.Domain.Model.Offers;
using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.Model.FinancialBase;

/// <summary>
/// Категория кредитной организаций (банк, небанковская кредитная организация, микрофинансовая организация, кредитный потребительский кооператив, ломбарды и т.д.)
/// </summary>
public class BankCategory : EntityAbstract
{
    public IList<Bank> Banks { get; set; } = [];
}
