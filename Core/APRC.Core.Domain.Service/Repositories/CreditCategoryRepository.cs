using APRC.Core.Domain.Model.FinancialBase;
using APRC.Core.SharedKernel.Abstractions;
using APRC.Core.SharedKernel.Abstractions.Interfaces;

namespace APRC.Core.Domain.Service.Repositories;

public interface ICreditCategoryRepository : IRepository<CreditCategory>;

public class CreditCategoryRepository(ContextAbstract context)
    : RepositoryAbstract<CreditCategory>(context), ICreditCategoryRepository;
