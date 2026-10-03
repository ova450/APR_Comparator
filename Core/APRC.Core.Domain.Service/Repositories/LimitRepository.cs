using APRC.Core.Domain.Model.CBR;
using APRC.Core.SharedKernel.Abstractions;
using APRC.Core.SharedKernel.Abstractions.Interfaces;

namespace APRC.Core.Domain.Service.Repositories;

public interface ILimitRepository : IRepository<Limit>;

public class LimitRepository(ContextAbstract context)
    : RepositoryAbstract<Limit>(context), ILimitRepository;
