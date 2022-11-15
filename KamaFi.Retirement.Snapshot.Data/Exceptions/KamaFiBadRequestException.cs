using System.Net;

namespace KamaFi.Retirement.Snapshot.Data.Exceptions
{
    public class KamaFiBadRequestException : KamaFiException
    {
        private const string DefaultMessage = "Invalid request.";

        public KamaFiBadRequestException()
            : base(HttpStatusCode.BadRequest, DefaultMessage)
        { }

        public KamaFiBadRequestException(string message)
            : base(HttpStatusCode.NotFound, message)
        { }

        public KamaFiBadRequestException(string message, Exception inner)
            : base(message, inner)
        { }

        public KamaFiBadRequestException(Exception inner)
            : base(DefaultMessage, inner)
        { }
    }
}
