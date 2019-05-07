using QGate.Core.Exceptions;
using System;
using System.Collections;

namespace QGate.Core.Types
{
    public static class TypeExtensions
    {
        private static Type _enumerableType = typeof(IEnumerable);

        public static bool IsCollection(this Type type)
        {
            Throw.IfNull(type, nameof(type));
            return _enumerableType.IsAssignableFrom(type);
        }
    }
}
