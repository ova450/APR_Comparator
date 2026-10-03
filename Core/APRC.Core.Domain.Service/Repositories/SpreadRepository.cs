using APRC.Core.Domain.Model.Offers;
using APRC.Core.SharedKernel.Abstractions;
using APRC.Core.SharedKernel.Abstractions.Interfaces;

namespace APRC.Core.Domain.Service.Repositories;

public interface ISpreadRepository : IRepository<Spread>;

public class SpreadRepository(ContextAbstract context)
    : RepositoryAbstract<Spread>(context), ISpreadRepository;
