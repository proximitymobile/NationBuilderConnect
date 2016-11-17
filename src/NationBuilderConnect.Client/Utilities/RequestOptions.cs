using System;
using NationBuilderConnect.Client.Utilities.Auth;

namespace NationBuilderConnect.Client.Utilities
{
    public class RequestOptions
    {
        public string NationSlug { get; set; }
        public TimeSpan? Timeout { get; set; }
        public ICredentials Credentials { get; set; }
        public ushort? RateLimitRetries { get; set; }

        public static RequestOptions Combine(RequestOptions options1, RequestOptions options2)
        {
            if (options2 == null) return options1;
            if (options1 == null) return options2;

            return new RequestOptions
            {
                NationSlug = options2.NationSlug ?? options1.NationSlug,
                Timeout = options2.Timeout ?? options1.Timeout,
                Credentials = options2.Credentials ?? options1.Credentials,
                RateLimitRetries = options2.RateLimitRetries ?? options1.RateLimitRetries
            };
        }
    }
}