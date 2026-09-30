using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.FinStructure;

/// <summary>
/// Категории кредитных организаций по версии ЦБР.
/// </summary>
public class Category : EntityAbstract
{
    public IList<Bank> Banks { get; set; } = [];
}
