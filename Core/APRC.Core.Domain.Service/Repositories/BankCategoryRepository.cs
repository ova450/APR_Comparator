using APRC.Core.Domain.Model.FinancialBase;
using APRC.Core.SharedKernel.Abstractions;
using APRC.Core.SharedKernel.Abstractions.Interfaces;

namespace APRC.Core.Domain.Service.Repositories;

public interface IBankCategoryRepository : IRepository<BankCategory>;

public class BankCategoryRepository(ContextAbstract context)
    : RepositoryAbstract<BankCategory>(context), IBankCategoryRepository;
