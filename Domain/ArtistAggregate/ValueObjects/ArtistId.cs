using Domain.Primitives;

namespace Domain.ArtistAggregate.ValueObjects;

public class ArtistId : ValueObject
{
    public Guid Value { get; private set; }

    private ArtistId(Guid value)
    {
        Value = value;
    }

    public static ArtistId Create(Guid value)
    {
        return new(value);
    }

    public static ArtistId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
