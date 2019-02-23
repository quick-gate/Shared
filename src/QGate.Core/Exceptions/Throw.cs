using System;

namespace QGate.Core.Exceptions
{
    public static class Throw
    {
        public static void IfNull(object paramValue, string paramName)
        {
            if (paramValue == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        public static void IfNullOrWhiteSpace(string paramValue, string paramName)
        {
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
