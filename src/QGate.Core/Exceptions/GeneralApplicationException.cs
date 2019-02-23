using System;

namespace QGate.Core.Exceptions
{
    /// <summary>
    /// Serves as the base class for general application-defined exceptions.
    /// </summary>
    public class GeneralApplicationException : Exception
    {
        public GeneralApplicationException()
        {
        }

        public GeneralApplicationException(string message) : base(message)
        {
        }

        public GeneralApplicationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
