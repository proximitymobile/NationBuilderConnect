using System;
using NationBuilderConnect.Client.Utilities.Auth;

namespace NationBuilderConnect.Client.Utilities
{
    /// <summary>
    ///     Options to use for each request
    /// </summary>
    public class RequestOptions
    {
        /// <summary>
        ///     The nation slug to use for each request. If not provided, the value provided while configuring the client will be
        ///     used.
        /// </summary>
        public string NationSlug { get; set; }

        /// <summary>
        ///     The timeout to use for each request. If not provided, the value provided while configuring the client will be
        ///     used.
        /// </summary>
        public TimeSpan? Timeout { get; set; }

        /// <summary>
        ///     The credentials to use for each request. If not provided, the value provided while configuring the client will be
        ///     used.
        /// </summary>
        public ICredentials Credentials { get; set; }

        /// <summary>
        ///     The number of times to retry a request if the rate limit has been reached for each request. If not provided, the
        ///     value provided while configuring the client will be used.
        /// </summary>
        public short? RateLimitRetries { get; set; }

        /// <summary>
        ///     The result page size. If not provided, the value provided while configuring the client will be used.
        /// </summary>
        public short? ResultsPageSize { get; set; }

        /// <summary>
        ///     Combines 2 request options
        /// </summary>
        /// <param name="options1">The first options. Values will be overridden by values provided in options2.</param>
        /// <param name="options2">The second options. Values provided will override values in options1.</param>
        /// <returns></returns>
        public static RequestOptions Combine(RequestOptions options1, RequestOptions options2)
        {
            if (options2 == null) return options1;
            if (options1 == null) return options2;

            return new RequestOptions
            {
                NationSlug = options2.NationSlug ?? options1.NationSlug,
                Timeout = options2.Timeout ?? options1.Timeout,
                Credentials = options2.Credentials ?? options1.Credentials,
                RateLimitRetries = options2.RateLimitRetries ?? options1.RateLimitRetries,
                ResultsPageSize = options2.ResultsPageSize ?? options1.ResultsPageSize
            };
        }
    }
}