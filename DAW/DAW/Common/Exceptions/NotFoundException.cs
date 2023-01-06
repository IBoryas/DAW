using System.Net;

namespace DAW.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public HttpStatusCode Code { get; } = HttpStatusCode.NotFound;

        public NotFoundException(string message) : base(message)
        {
        }
    }
}
