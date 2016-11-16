using System;
using NationBuilderConnect.Utilities.Auth;

namespace NationBuilderConnect.Utilities
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