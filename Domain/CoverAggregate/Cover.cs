using Domain.ArtistAggregate;
using Domain.ArtistAggregate.ValueObjects;
using Domain.AuthorAggregate.ValueObjects;
using Domain.Common;
using Domain.CoverAggregate.ValueObjects;
using Domain.Primitives;

namespace Domain.CoverAggregate;

public class Cover : AggregateRoot<CoverId>
{
    private readonly List<Artist> _artists = new();
    public DesignIdea DesignIdea { get; private set; }
    public DigitalOnly DigitalOnly { get; private set; }
    public BookId BookId { get; private set; }
    public IReadOnlyList<Artist> Artists => _artists.AsReadOnly();

    private Cover()
    {
    }

    private Cover(CoverId id, DesignIdea designIdea, DigitalOnly digitalOnly, BookId bookId, List<Artist> artists) : base(id ?? CoverId.CreateUnique())
    {
        // Hvis artists er tom må Cover ikke kunne creates

        DesignIdea = designIdea;
        DigitalOnly = digitalOnly;
        BookId = bookId;
        _artists = artists;
    }

    public static Cover Create(CoverId id, DesignIdea designIdea, DigitalOnly digitalOnly, BookId bookId, List<Artist> artists)
    {
        return new(id, designIdea, digitalOnly, bookId, artists);
    }

    public static Cover CreateNew(DesignIdea designIdea, DigitalOnly digitalOnly, BookId bookId, List<Artist> artists)
    {
        return new(CoverId.CreateUnique(), designIdea, digitalOnly, bookId, artists);
    }

    public void Edit(DesignIdea desingIdea, DigitalOnly digitalOnly)
    {
        if (DesignIdea != desingIdea)
            DesignIdea = desingIdea;
        if (DigitalOnly != digitalOnly)
            DigitalOnly = digitalOnly;
    }

    public void AddArtist(Artist artist)
    {
        _artists.Add(artist);
    }

    public void RemoveArtist(Artist artist)
    {
        if (_artists.Count == 1)
            throw new Exception("Cover skal altid have mindst 1 artist");

        if (_artists.Contains(artist))
            _artists.Remove(artist);
    }
}
