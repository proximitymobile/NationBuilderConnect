using System.Net;

namespace NationBuilderConnect.Resources
{
    public class ApiResponse
    {
        public ApiResponse(HttpStatusCode httpStatusCode, ApiRateLimitDetails rateLimit, ApiErrorDetails error = null)
        {
            HttpStatusCode = httpStatusCode;
            RateLimit = rateLimit;
            Error = error;
        }

        public HttpStatusCode HttpStatusCode { get; private set; }
        public ApiErrorDetails Error { get; private set; }
        public ApiRateLimitDetails RateLimit { get; private set; }
    }

    public class ApiResponse<TPayload> : ApiResponse
    {
        public ApiResponse(HttpStatusCode httpStatusCode, ApiRateLimitDetails rateLimit, TPayload payload,
            ApiErrorDetails error = null) : base(httpStatusCode, rateLimit, error)
        {
            Payload = payload;
        }

        public TPayload Payload { get; private set; }
    }
}