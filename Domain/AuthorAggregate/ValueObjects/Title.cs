using Domain.Primitives;

namespace Domain.AuthorAggregate.ValueObjects;

public sealed class Title : ValueObject
{
    public string Value { get; private set; }

    private Title(string value)
    {
        Value = value;
    }

    public static Title Create(string value)
    {
        return new(value);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
