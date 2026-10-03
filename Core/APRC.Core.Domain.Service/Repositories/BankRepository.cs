using APRC.Core.Domain.Model.Offers;
using APRC.Core.SharedKernel.Abstractions;
using APRC.Core.SharedKernel.Abstractions.Interfaces;

namespace APRC.Core.Domain.Service.Repositories;

public interface IBankRepository : IRepository<Bank>;

public class BankRepository(ContextAbstract context)
    : RepositoryAbstract<Bank>(context), IBankRepository;
