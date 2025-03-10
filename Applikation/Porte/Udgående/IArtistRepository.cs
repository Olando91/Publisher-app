using Domain.ArtistAggregate;
using Domain.ArtistAggregate.ValueObjects;

namespace Applikation.Porte.Udgående;

public interface IArtistRepository
{
    Task AddArtistAsync(Artist artist);
    Task SaveChangesAsync();
    Task DeleteArtistByIdAsync(ArtistId id);
    Task<Artist> GetArtistByIdAsync(ArtistId id);
    Task<List<Artist>> GetAllArtistsAsync();
    Task<List<Artist>> GetArtistsById(List<ArtistId> artistIds);
}
