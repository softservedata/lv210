using System;

namespace NumbersInRange
{
    public class Number<T> where T : struct, IComparable<T>
    {
        public T Value { get; private set; }

        public Number(T value)
        {
            Value = value;
        }

        public bool IsInRange(T a, T b)
        {
            return ((this.Value.CompareTo(a) >= 0) && (this.Value.CompareTo(b) <= 0)) ? true : false;
        }
    }
}