using System;
using NationBuilderConnect.Utilities.Auth;

namespace NationBuilderConnect.Utilities
{
    internal class ClientConfiguration : IClientConfiguration
    {
        public RequestOptions RequestOptions { get; private set; }

        public ClientConfiguration()
        {
            RequestOptions = new RequestOptions { RateLimitRetries = 3, Timeout = TimeSpan.FromSeconds(10)};
        }

        public IUrlProvider UrlProvider { get; private set; }

        public void WithDefaultNationSlug(string nationSlug)
        {
            RequestOptions.NationSlug = nationSlug;
        }

        public void WithDefaultRequestTimeout(TimeSpan timeout)
        {
            RequestOptions.Timeout = timeout;
        }

        public void WithUrlProvider(IUrlProvider provider)
        {
            UrlProvider = provider;
        }

        public void WithRetriesWhenRateLimitHit(ushort number)
        {
            RequestOptions.RateLimitRetries = number;
        }

        public void WithDefaultCredentials(ICredentials credentials)
        {
            RequestOptions.Credentials = credentials;
        }
    }
}