using System.Net;

namespace KamaFi.Retirement.Snapshot.Data.Exceptions
{
    public class KamaFiNotFoundException : KamaFiException
    {
        private const string DefaultMessage = "The requested item was not found.";

        public KamaFiNotFoundException()
            : base(HttpStatusCode.NotFound, DefaultMessage)
        { }

        public KamaFiNotFoundException(string message)
            : base(HttpStatusCode.NotFound, message)
        { }

        public KamaFiNotFoundException(string message, Exception inner)
            : base(message, inner)
        { }

        public KamaFiNotFoundException(Exception inner)
            : base(DefaultMessage, inner)
        { }
    }
}
