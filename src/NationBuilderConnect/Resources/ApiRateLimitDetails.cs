using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using NationBuilderConnect.Utilities.Extensions;

namespace NationBuilderConnect.Resources
{
    /// <summary>
    ///     Details about rate limits returned from the server
    /// </summary>
    public class ApiRateLimitDetails
    {
        private static readonly TimeSpan MinResetInterval = TimeSpan.FromSeconds(2);

        private ApiRateLimitDetails(TimeSpan interval, int remaining, long reset, DateTime requestedAt)
        {
            Interval = interval;
            Remaining = remaining;
            Reset = reset;
            RequestedAt = requestedAt;
        }

        /// <summary>
        ///     The rate limit interval (the time after which the rate limit resets)
        /// </summary>
        public TimeSpan Interval { get; private set; }

        /// <summary>
        ///     The number of requests remaining in the interval
        /// </summary>
        public int Remaining { get; private set; }

        /// <summary>
        ///     The date that the interval resets, expressed in epoch time
        /// </summary>
        public long Reset { get; private set; }

        /// <summary>
        ///     When the request was made, according to the server
        /// </summary>
        public DateTime RequestedAt { get; private set; }

        /// <summary>
        ///     When the interval resets in our (client) time
        /// </summary>
        public DateTime GetResetsAt()
        {
            return DateTime.UtcNow.Add(GetResetsIn());
        }

        /// <summary>
        ///     When the interval resets in our (client) time
        /// </summary>
        public TimeSpan GetResetsIn()
        {
            var resetAtAsRemoteTime = Reset.AsUnixTimeToDateTime();
            var resetsIn = resetAtAsRemoteTime - RequestedAt;
            return resetsIn > MinResetInterval ? resetsIn : MinResetInterval;
        }

        /// <summary>
        ///     Creates an instance of <see cref="ApiRateLimitDetails" /> based on the response from the server
        /// </summary>
        /// <param name="response">The response from the server</param>
        /// <returns>The rate limit details</returns>
        public static ApiRateLimitDetails CreateFromResponse(HttpResponseMessage response)
        {
            IEnumerable<string> limitRaws, remainingRaws, resetRaws, dateRaws;

            if (!response.Headers.TryGetValues("x-ratelimit-limit", out limitRaws)) return null;
            if (!response.Headers.TryGetValues("x-ratelimit-remaining", out remainingRaws)) return null;
            if (!response.Headers.TryGetValues("x-ratelimit-reset", out resetRaws)) return null;
            if (!response.Headers.TryGetValues("date", out dateRaws)) return null;

            string limitRaw, remainingRaw, resetRaw, dateRaw;

            if ((limitRaw = limitRaws?.SingleOrDefault()) == null) return null;
            if ((remainingRaw = remainingRaws?.SingleOrDefault()) == null) return null;
            if ((resetRaw = resetRaws?.SingleOrDefault()) == null) return null;
            if ((dateRaw = dateRaws?.SingleOrDefault()) == null) return null;

            TimeSpan limit;
            if (!TryGetLimitAsTimeSpan(limitRaw, out limit)) return null;

            int remaining;
            if (!int.TryParse(remainingRaw, out remaining)) return null;

            long reset;
            if (!long.TryParse(resetRaw, out reset)) return null;

            DateTime date;
            if (!DateTime.TryParse(dateRaw, out date)) return null;

            return new ApiRateLimitDetails(limit, remaining, reset, date);
        }

        private static bool TryGetLimitAsTimeSpan(string limitRaw, out TimeSpan limit)
        {
            if (string.IsNullOrWhiteSpace(limitRaw))
            {
                limit = TimeSpan.Zero;
                return false;
            }

            limitRaw = limitRaw.Trim().ToUpperInvariant();

            var limitRawWithoutUnit = limitRaw.Substring(0, limitRaw.Length - 1);
            int limitNumber;

            if (!int.TryParse(limitRawWithoutUnit, out limitNumber))
            {
                limit = TimeSpan.Zero;
                return false;
            }

            if (limitRaw.EndsWith("S"))
            {
                limit = TimeSpan.FromSeconds(limitNumber);
                return true;
            }

            if (limitRaw.EndsWith("M"))
            {
                limit = TimeSpan.FromMinutes(limitNumber);
                return true;
            }

            if (limitRaw.EndsWith("H"))
            {
                limit = TimeSpan.FromHours(limitNumber);
                return true;
            }

            limit = TimeSpan.Zero;
            return false;
        }
    }
}