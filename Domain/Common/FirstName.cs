using Domain.Primitives;

namespace Domain.Common;

public sealed class FirstName : ValueObject
{
    public string Value { get; private set; }

    private FirstName(string value)
    {
        Value = value;
    }

    public static FirstName Create(string value)
    {
        return new(value);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
