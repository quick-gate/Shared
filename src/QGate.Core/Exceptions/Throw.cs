using QGate.Core.Collections;
using System;
using System.Collections.Generic;

namespace QGate.Core.Exceptions
{
    public static class Throw
    {
        public static void IfNull(object paramValue, params string[] paramPath)
        {
            if (paramValue == null)
            {
                throw new ArgumentNullException(GetFormattedParamPath(paramPath));
            }
        }

        public static void IfNullOrWhiteSpace(string paramValue, params string[] paramPath)
        {
            if (string.IsNullOrWhiteSpace(paramValue))
            {
                throw new ArgumentNullException(GetFormattedParamPath(paramPath));
            }
        }

        public static void IfNullOrEmpty<T>(IEnumerable<T> paramValue, params string[] paramPath)
        {
            var formattedParamPath = GetFormattedParamPath(paramPath);
            IfNull(paramValue, formattedParamPath);

            if(paramValue.IsNullOrEmpty())
            {
                throw new ArgumentNullException(formattedParamPath, "Collection is empty");
            }
        }

        private static string GetFormattedParamPath(params string[] paramPath)
        {
            if(paramPath.IsNullOrEmpty())
            {
                return "unknown parameter.";
            }

            return string.Join(".", paramPath);
        }
    }
}
