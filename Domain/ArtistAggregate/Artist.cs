using Domain.ArtistAggregate.ValueObjects;
using Domain.Common;
using Domain.CoverAggregate;
using Domain.Primitives;

namespace Domain.ArtistAggregate;

public class Artist : AggregateRoot<ArtistId>
{
    private readonly List<Cover> _covers = new();
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }

    public IReadOnlyList<Cover> Covers => _covers.AsReadOnly();

    private Artist()
    {
    }

    private Artist(ArtistId id, FirstName firstName, LastName lastName) : base(id ?? ArtistId.CreateUnique())
    {
        FirstName = firstName;
        LastName = lastName;
        _covers = new();
    }

    public static Artist Create(ArtistId id, FirstName firstName, LastName lastName)
    {
        return new(id, firstName, lastName);
    }

    public static Artist CreateNew(FirstName firstName, LastName lastName)
    {
        return new(ArtistId.CreateUnique(), firstName, lastName);
    }

    public void Edit(FirstName firstName, LastName lastName)
    {
        if (FirstName != firstName)
            FirstName = firstName;
        if (LastName != lastName)
            LastName = lastName;
    }
}
