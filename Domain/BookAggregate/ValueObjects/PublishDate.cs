using Domain.Primitives;

namespace Domain.BookAggregate.ValueObjects;

public sealed class PublishDate : ValueObject
{
    public DateOnly Value { get; private set; }

    private PublishDate(DateOnly value)
    {
        Value = value;
    }

    public static PublishDate Create(DateOnly value)
    {
        return new(value);
    }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
