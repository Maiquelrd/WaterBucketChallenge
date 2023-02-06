using System.Net;

namespace WaterBucketChallenge.Commons.Exceptions
{
    public class ExceptionStatusCodes
    {
        private static Dictionary<Type, HttpStatusCode> exceptionStatusCodes = new Dictionary<Type, HttpStatusCode>
        {
            {typeof(ValidationException), HttpStatusCode.BadRequest}
        };

        public static HttpStatusCode GetExceptionStatusCode(Exception exception)
        {
            bool exceptionFound = exceptionStatusCodes.TryGetValue(exception.GetType(), out var statusCode);
            return exceptionFound ? statusCode : HttpStatusCode.InternalServerError;
        }

    }
}
