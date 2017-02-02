using System;

namespace Wow.Helpers
{
    public static class Extensions
    {
        private static bool IsNullableType(Type type)
        {
            if (!type.IsValueType)
            {
                return true;

            }

            if (Nullable.GetUnderlyingType(type) != null)
            {
                return true;
            }

            return false;
        }

        public static T FromDb<T>(this object input)
        {
            var type = typeof(T);
            if (input == DBNull.Value)
            {
                if (!IsNullableType(type))
                {
                    throw new InvalidOperationException($"Cannot convert DBNull to {type.Name}");
                }

                return (T)(object)null;
            }

            return (T)input;
        }
    }
}
