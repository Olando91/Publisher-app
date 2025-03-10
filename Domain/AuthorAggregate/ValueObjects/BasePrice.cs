using Domain.Primitives;

namespace Domain.AuthorAggregate.ValueObjects;

public sealed class BasePrice : ValueObject
{
    public int Value { get; private set; }

    private BasePrice(int value)
    {
        Value = value;
    }

    public static BasePrice Create(int value)
    {
        return new(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
