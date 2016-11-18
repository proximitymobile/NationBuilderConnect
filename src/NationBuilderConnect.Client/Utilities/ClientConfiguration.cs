using System;
using NationBuilderConnect.Client.Utilities.Auth;

namespace NationBuilderConnect.Client.Utilities
{
    internal class ClientConfiguration : IClientConfiguration
    {
        public const short DefaultPageSize = 20;

        public RequestOptions RequestOptions { get; private set; }

        public ClientConfiguration()
        {
            RequestOptions = new RequestOptions
            {
                RateLimitRetries = 3,
                Timeout = TimeSpan.FromSeconds(10),
                ResultsPageSize = DefaultPageSize
            };
        }

        public IUrlProvider UrlProvider { get; private set; }

        /// <inheritDoc/>
        public void WithDefaultNationSlug(string nationSlug)
        {
            RequestOptions.NationSlug = nationSlug;
        }

        /// <inheritDoc/>
        public void WithDefaultRequestTimeout(TimeSpan timeout)
        {
            RequestOptions.Timeout = timeout;
        }

        /// <inheritDoc/>
        public void WithUrlProvider(IUrlProvider provider)
        {
            UrlProvider = provider;
        }

        /// <inheritDoc/>
        public void WithRetriesWhenRateLimitHit(short number)
        {
            RequestOptions.RateLimitRetries = number;
        }

        /// <inheritDoc/>
        public void WithDefaultResultsPageSize(short pageSize)
        {
            RequestOptions.ResultsPageSize = pageSize;
        }

        /// <inheritDoc/>
        public void WithDefaultCredentials(ICredentials credentials)
        {
            RequestOptions.Credentials = credentials;
        }
    }
}