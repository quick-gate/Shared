using System;

namespace QGate.Core.Exceptions
{
    public class QGateException : GeneralApplicationException
    {
        public QGateException()
        {
        }

        public QGateException(string message) : base(message)
        {
        }

        public QGateException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
