﻿namespace Domain.Primitives
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public override bool Equals(object? obj) => obj is ValueObject valueObject && ValuesAreEqual(valueObject);

        public static bool operator == (ValueObject? left, ValueObject? right)
        {
            if (left is null && right is null)
                return true;

            if (left is null || right is null)
                return false;

            return left.Equals(right);
        }

        public static bool operator != (ValueObject? left, ValueObject? right)
        {
            return !(left == right);
        }

        public virtual bool Equals(ValueObject? other) => other is not null && ValuesAreEqual(other);

        public override int GetHashCode() => GetEqualityComponents().Aggregate(default(int), (hashcode, value) => HashCode.Combine(hashcode, value.GetHashCode()));

        protected abstract IEnumerable<object> GetEqualityComponents();

        private bool ValuesAreEqual(ValueObject valueObject) => GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
    }
}
