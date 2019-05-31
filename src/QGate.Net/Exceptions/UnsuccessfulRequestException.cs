using System.Net;

namespace QGate.Net.Exceptions
{
    public class UnsuccessfulRequestException : GeneralNetException
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public UnsuccessfulRequestException(string message, HttpStatusCode httpStatusCode) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
