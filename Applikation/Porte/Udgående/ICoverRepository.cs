using Domain.CoverAggregate;
using Domain.CoverAggregate.ValueObjects;

namespace Applikation.Porte.Udgående;

public interface ICoverRepository
{
    Task AddCoverAsync(Cover cover);
    Task SaveChangesAsync();
    Task DeleteCoverByIdAsync(CoverId coverId);
    Task<Cover> GetCoverByIdAsync(CoverId coverId);
    Task<List<Cover>> GetAllCoversAsync();
}
