using System;

namespace QGate.Core.Logging
{
    public interface ILogger
    {
        void Info(string message, object data = null);
        void Error(Exception exception, object data = null);
        void Error(string message, Exception exception, object data = null);

        void Error(string message, object data = null);
    }
}
