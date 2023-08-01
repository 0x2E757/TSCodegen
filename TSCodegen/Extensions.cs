using System;

namespace TSCodegen
{
    internal static class Extensions
    {
        public static string GetNameWithoutGenericArity(this Type type)
        {
            var result = type.Name;
            var genericMarkerIndex = result.IndexOf('`');

            if (genericMarkerIndex >= 0)
                return result.Substring(0, genericMarkerIndex);

            return result;
        }

        public static bool Implements(this Type type, Type target)
        {
            if (type.IsGenericType == target.IsGenericType)
                if (type.IsGenericType)
                {
                    if (type.GetGenericTypeDefinition() == target)
                        return true;

                    foreach (var typeInterface in type.GetInterfaces())
                        if (typeInterface.IsGenericType && typeInterface.GetGenericTypeDefinition() == target)
                            return true;
                }
                else
                {
                    if (type == target)
                        return true;

                    foreach (var typeInterface in type.GetInterfaces())
                        if (typeInterface == target)
                            return true;
                }

            return false;
        }

        public static string ToCamelCase(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return value;

            if (value.Length == 1)
                return value.ToLower();

            if (value == value.ToUpper())
                return value.ToLower();

            var upperPrefixLength = value.Length;

            for (var n = 0; n < value.Length; n += 1)
                if (char.IsLower(value[n]))
                {
                    upperPrefixLength = n;
                    break;
                }

            if (upperPrefixLength == 1)
                return value.Substring(0, 1).ToLower() + value.Substring(1);

            if (upperPrefixLength > 1)
                return value.Substring(0, upperPrefixLength - 1).ToLower() + value.Substring(upperPrefixLength - 1);

            return value;
        }
    }
}
