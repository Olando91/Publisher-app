﻿using Domain.Primitives;

namespace Domain.Common;

public sealed class LastName : ValueObject
{
    public string Value { get; private set; }

    private LastName(string value)
    {
        Value = value;
    }

    public static LastName Create(string value)
    {
        return new(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
