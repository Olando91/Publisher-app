using Domain.Primitives;

namespace Domain.AuthorAggregate.ValueObjects;

public sealed class AuthorId : ValueObject
{
    public Guid Value { get; private set; }

    private AuthorId(Guid value)
    {
        Value = value;
    }

    public static AuthorId Create(Guid value)
    {
        return new(value);
    }

    public static AuthorId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
