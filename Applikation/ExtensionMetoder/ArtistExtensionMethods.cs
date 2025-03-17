using Applikation.DTOs.Artist;
using Domain.ArtistAggregate;

namespace Applikation.ExtensionMetoder;

public static class ArtistExtensionMethods
{
    public static ArtistDTO TilDTO(this Artist artist)
    {
        return new ArtistDTO
        {
            Id = artist.Id.Value,
            FirstName = artist.FirstName.Value,
            LastName = artist.LastName.Value,
            Covers = artist.Covers.Select(cover => cover.TilArtistCoverDTO()).ToList()
        };
    }

    public static CoverArtistDTO TilCoverArtistDTO(this Artist artist)
    {
        return new CoverArtistDTO
        {
            Id = artist.Id.Value,
            FirstName = artist.FirstName.Value,
            LastName = artist.LastName.Value
        };
    }
}
