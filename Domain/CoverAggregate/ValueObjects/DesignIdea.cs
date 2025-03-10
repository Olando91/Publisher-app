using Domain.Primitives;

namespace Domain.CoverAggregate.ValueObjects;

public class DesignIdea : ValueObject
{
    public string Value { get; private set; }

    private DesignIdea(string value)
    {
        Value = value;
    }

    public static DesignIdea Create(string value)
    {
        return new(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
