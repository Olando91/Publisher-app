using Domain.Primitives;

namespace Domain.CoverAggregate.ValueObjects;

public sealed class CoverId : ValueObject
{
    public Guid Value { get; private set; }
    private CoverId(Guid value)
    {
        Value = value;
    }

    public static CoverId Create(Guid value)
    {
        return new(value);
    }

    public static CoverId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
