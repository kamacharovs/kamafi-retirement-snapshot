using System.Net;
using System.Text.Json;

namespace KamaFi.Retirement.Snapshot.Data.Exceptions
{
    public class KamaFiException : ApplicationException
    {
        public int StatusCode { get; set; }
        public string ContentType { get; set; } = @"application/json";

        protected KamaFiException()
        { }

        protected KamaFiException(int statusCode)
        {
            StatusCode = statusCode;
        }

        protected KamaFiException(string message)
            : base(message)
        {
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }

        protected KamaFiException(string message, Exception inner)
            : base(message, inner)
        { }

        protected KamaFiException(int statusCode, string message)
            : base(message)
        {
            StatusCode = statusCode;
        }

        protected KamaFiException(HttpStatusCode statusCode)
        {
            StatusCode = (int)statusCode;
        }

        protected KamaFiException(HttpStatusCode statusCode, string message)
            : base(message)
        {
            StatusCode = (int)statusCode;
        }

        protected KamaFiException(int statusCode, Exception inner)
            : this(statusCode, inner.ToString())
        { }

        protected KamaFiException(HttpStatusCode statusCode, Exception inner)
            : this(statusCode, inner.ToString())
        { }

        protected KamaFiException(int statusCode, JsonElement errorObject)
            : this(statusCode, errorObject.ToString())
        {
            ContentType = @"application/problem+json";
        }
    }
}
