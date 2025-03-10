using Domain.Primitives;

namespace Domain.AuthorAggregate.ValueObjects;

public sealed class BookId : ValueObject
{
    public Guid Value { get; private set; }

    private BookId(Guid value)
    {
        Value = value;
    }

    public static BookId Create(Guid value)
    {
        return new(value);
    }

    public static BookId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
