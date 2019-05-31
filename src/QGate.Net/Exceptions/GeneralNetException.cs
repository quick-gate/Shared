using System;

namespace QGate.Net.Exceptions
{
    public class GeneralNetException : Exception
    {
        public GeneralNetException(string message) : base(message)
        {
        }
    }
}
