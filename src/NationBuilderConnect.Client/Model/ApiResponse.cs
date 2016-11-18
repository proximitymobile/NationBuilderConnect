using System.Net;

namespace NationBuilderConnect.Client.Model
{
    /// <summary>
    ///     A response from the API
    /// </summary>
    public class ApiResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiResponse" /> class
        /// </summary>
        /// <param name="httpStatusCode">The HTTP status code</param>
        /// <param name="rateLimit">Rate limit imformation</param>
        /// <param name="error">Error details</param>
        public ApiResponse(HttpStatusCode httpStatusCode, ApiRateLimitDetails rateLimit, ApiErrorDetails error = null)
        {
            HttpStatusCode = httpStatusCode;
            RateLimit = rateLimit;
            Error = error;
        }

        /// <summary>
        ///     The HTTP status code
        /// </summary>
        public HttpStatusCode HttpStatusCode { get; private set; }

        /// <summary>
        ///     Erroe details (if the API call failed)
        /// </summary>
        public ApiErrorDetails Error { get; private set; }

        /// <summary>
        ///     Rate limit details
        /// </summary>
        public ApiRateLimitDetails RateLimit { get; private set; }
    }

    /// <summary>
    ///     A response from the API
    /// </summary>
    public class ApiResponse<TPayload> : ApiResponse
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiResponse" /> class
        /// </summary>
        /// <param name="httpStatusCode">The status code</param>
        /// <param name="rateLimit">Rate limit imformation</param>
        /// <param name="payload">The payload (body) of the response</param>
        /// <param name="error">Error details</param>
        public ApiResponse(HttpStatusCode httpStatusCode, ApiRateLimitDetails rateLimit, TPayload payload,
            ApiErrorDetails error = null) : base(httpStatusCode, rateLimit, error)
        {
            Payload = payload;
        }

        /// <summary>
        ///     The payload (body) of the response
        /// </summary>
        public TPayload Payload { get; private set; }
    }
}