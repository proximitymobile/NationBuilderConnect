using System;
using NationBuilderConnect.Client.Model;

namespace NationBuilderConnect.Client.Utilities
{
    /// <summary>
    ///     Exception that is raised when an error response is received from a call to the API
    /// </summary>
    public class ApiCallFailedException : Exception
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiCallFailedException" /> class
        /// </summary>
        /// <param name="response">The response details</param>
        public ApiCallFailedException(ApiResponse response)
            : base(response.Error?.Message ?? $"API Call failed ({response.HttpStatusCode})")
        {
            Response = response;
        }

        /// <summary>
        ///     The response details
        /// </summary>
        public ApiResponse Response { get; private set; }
    }
}