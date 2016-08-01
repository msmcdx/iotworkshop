using System;

namespace Iot.Common
{
    /// <summary>
    /// enumeration extensions
    /// </summary>
    /// <remarks>based on http://kirillosenkov.blogspot.com/2007/09/making-c-enums-more-usable-parse-method.html</remarks>
    public static class EnumExtensions
    {
        /// <summary>
        /// Parses as enum.
        /// </summary>
        /// <typeparam name="T">enum type</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>enum type or throws an exception</returns>
        /// <exception cref="System.ArgumentNullException">value</exception>
        /// <exception cref="System.InvalidOperationException">element is not an enum</exception>
        public static T ParseAsEnum<T>(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Type enumType = typeof(T);
            if (!enumType.IsEnum)
            {
                throw new InvalidOperationException
                    ("element is not an enum");
            }

            return (T)Enum.Parse(enumType, value);
        }
    }
}