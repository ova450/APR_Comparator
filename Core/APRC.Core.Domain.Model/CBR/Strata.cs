using APRC.Core.SharedKernel.Abstractions;

namespace APRC.Core.Domain.CBR;

public class Strata : EntityBaseAbstract
{
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    public IList<Category> Categories { get; set; } = [];
    public decimal StrataUpperLimit { get; set; } = 0;
}
