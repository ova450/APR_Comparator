using APRC.Core.Domain.Model.CBR;
using APRC.Core.SharedKernel.Abstractions;
using APRC.Core.SharedKernel.Abstractions.Interfaces;

namespace APRC.Core.Domain.Service.Repositories;

public interface IStrataRepository : IRepository<Strata>;

public class StrataRepository(ContextAbstract context)
    : RepositoryAbstract<Strata>(context), IStrataRepository;
