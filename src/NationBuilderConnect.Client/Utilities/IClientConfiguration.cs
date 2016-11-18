using System;
using NationBuilderConnect.Client.Utilities.Auth;

namespace NationBuilderConnect.Client.Utilities
{
    /// <summary>
    ///     Configuration options for the client
    /// </summary>
    public interface IClientConfiguration
    {
        /// <summary>
        ///     Sets the nation slug to use by default for each request if not overridden in the service constructor
        /// </summary>
        /// <param name="nationSlug">The default nation slug</param>
        void WithDefaultNationSlug(string nationSlug);

        /// <summary>
        ///     Sets the request timeout to use by default for each request if not overridden in the service constructor
        /// </summary>
        /// <param name="timeout">The default timeout. Defaults to 10 seconds if not provided.</param>
        void WithDefaultRequestTimeout(TimeSpan timeout);

        /// <summary>
        ///     Sets the credentials to use by default for each request if not overridden in the service constructor
        /// </summary>
        /// <param name="credentials">The credentials</param>
        void WithDefaultCredentials(ICredentials credentials);

        /// <summary>
        ///     Sets the URL provider to use for each request. If not provided the client default provider will be used
        /// </summary>
        /// <param name="provider">The URL provider</param>
        void WithUrlProvider(IUrlProvider provider);

        /// <summary>
        ///     Sets the number of times to retry a request if the rate limit has been reached if not overridden in the service
        ///     constructor
        /// </summary>
        /// <param name="number">The number of retries. Defaults to 3 if not proveded.</param>
        void WithRetriesWhenRateLimitHit(short number);

        /// <summary>
        ///     Sets the result page size to use by default if not overridden in the service constructor or in service method
        /// </summary>
        /// <param name="pageSize">The page size. Defaults to 20 if not provided.</param>
        void WithDefaultResultsPageSize(short pageSize);
    }
}