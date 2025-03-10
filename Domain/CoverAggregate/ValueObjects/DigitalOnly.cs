using Domain.Primitives;

namespace Domain.CoverAggregate.ValueObjects;

public class DigitalOnly : ValueObject
{
    public bool Value { get; private set; }

    private DigitalOnly(bool value)
    {
        Value = value;
    }

    public static DigitalOnly Create(bool value)
    {
        return new(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
