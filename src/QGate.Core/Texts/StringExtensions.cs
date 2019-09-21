using System;

namespace QGate.Core.Texts
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines (safely) whether are string equals with ignore case comparison
        /// </summary>
        /// <param name="a">Can be null</param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool EqualsIgnoreCase(this string a, string b)
        {
            return string.Equals(a, b, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
