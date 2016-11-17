using System;
using NationBuilderConnect.Client.Utilities.Auth;

namespace NationBuilderConnect.Client.Utilities
{
    public interface IClientConfiguration
    {
        void WithDefaultNationSlug(string nationSlug);
        void WithDefaultRequestTimeout(TimeSpan timeout);
        void WithDefaultCredentials(ICredentials credentials);
        void WithUrlProvider(IUrlProvider provider);
        void WithRetriesWhenRateLimitHit(ushort number);
    }
}