using Applikation.DTOs;
using Domain.ArtistAggregate;
using Domain.AuthorAggregate;
using Domain.AuthorAggregate.Entities;
using Domain.CoverAggregate;

namespace Applikation.ExtensionMetoder;

public static class ExtensionMetoder
{
    public static AuthorDTO TilDTO(this Author author)
    {
        return new AuthorDTO
        {
            Id = author.Id.Value,
            FirstName = author.FirstName.Value,
            LastName = author.LastName.Value,
            Books = author.Books.Select(book => book.TilDTO()).ToList()
        };
    }

    public static BookDTO TilDTO(this Book book)
    {
        return new BookDTO
        {
            Id = book.Id.Value,
            Title = book.Title.Value,
            PublishDate = book.PublishDate.Value,
            BasePrice = book.BasePrice.Value,
            AuthorId = book.AuthorId.Value,
            CoverId = book.CoverId.Value
        };
    }

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

    public static CoverDTO TilDTO(this Cover cover)
    {
        return new CoverDTO
        {
            Id = cover.Id.Value,
            DesignIdea = cover.DesignIdea.Value,
            DigitalOnly = cover.DigitalOnly.Value,
            BookId = cover.BookId.Value,
            Artists = cover.Artists.Select(artist => artist.TilCoverArtistDTO()).ToList()
        };
    }

    public static ArtistCoverDTO TilArtistCoverDTO(this Cover cover)
    {
        return new ArtistCoverDTO
        {
            Id = cover.Id.Value,
            DesignIdea = cover.DesignIdea.Value,
            DigitalOnly = cover.DigitalOnly.Value,
            BookId = cover.BookId.Value
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
