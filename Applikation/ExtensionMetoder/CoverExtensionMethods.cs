using Applikation.DTOs.Cover;
using Domain.CoverAggregate;

namespace Applikation.ExtensionMetoder;

public static class CoverExtensionMethods
{
    public static CoverDTO TilDTO(this Cover cover)
    {
        return new CoverDTO
        {
            Id = cover.Id.Value,
            DesignIdea = cover.DesignIdea.Value,
            DigitalOnly = cover.DigitalOnly.Value,
            Book = cover.Book.TilCoverBookDTO(),
            Artists = cover.Artists.Select(x => x.TilCoverArtistDTO()).ToList(),
        };
    }
    public static BookCoverDTO TilBookCoverDTO(this Cover cover)
    {
        return new BookCoverDTO
        {
            Id = cover.Id.Value,
            DesignIdea = cover.DesignIdea.Value,
            DigitalOnly = cover.DigitalOnly.Value,
            Artists = cover.Artists.Select(x => x.TilCoverArtistDTO()).ToList()
        };
    }

    public static ArtistCoverDTO TilArtistCoverDTO(this Cover cover)
    {
        return new ArtistCoverDTO
        {
            Id = cover.Id.Value,
            DesignIdea = cover.DesignIdea.Value,
            DigitalOnly = cover.DigitalOnly.Value,
            Book = cover.Book.TilCoverBookDTO()
        };
    }
}
