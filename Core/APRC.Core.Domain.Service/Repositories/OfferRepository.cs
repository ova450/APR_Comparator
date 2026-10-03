
using APRC.Core.Domain.Model.Offers;
using APRC.Core.SharedKernel.Abstractions;
using APRC.Core.SharedKernel.Abstractions.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APRC.Core.Domain.Service.Repositories;

public interface IOfferRepository : IRepository<Offer>
{
    /// <summary>
    /// Действующие оферты банка: оферты, у которых установлены все флаги <paramref name="status"/>
    /// (остальные флаги не важны), с максимальной DateFrom среди них.
    /// Например, OfferStatus.Actual вернёт актуальные оферты независимо от Public, Personal, Updated.
    /// При OfferStatus.None фильтр по статусу не применяется.
    /// </summary>
    Task<List<Offer>> GetActualAsync(int bankId, OfferStatus status, CancellationToken cancellationToken = default);
}

public class OfferRepository(ContextAbstract context)
    : RepositoryAbstract<Offer>(context), IOfferRepository
{
    public Task<List<Offer>> GetActualAsync(int bankId, OfferStatus status, CancellationToken cancellationToken = default)
    {
        var offers = _dbSet.Where(o => o.BankId == bankId && (o.Status & status) == status);

        return offers
            .Where(o => o.DateFrom == offers.Max(x => (DateTime?)x.DateFrom))
            .ToListAsync(cancellationToken);
    }
}
