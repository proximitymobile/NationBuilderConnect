using System;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Entities
{
    public class Ballot
    {
        /// <summary>
        ///     when the ballot was cast
        /// </summary>
        [JsonProperty("cast_at")]
        public DateTime CastAt { get; set; }

        /// <summary>
        ///     country code for the country the ballot was cast (required)
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        ///     when the election was held (required)
        /// </summary>
        [JsonProperty("election_at")]
        public DateTime ElectionAt { get; set; }

        /// <summary>
        ///     the type of election (General, Primary, Presidential Primary, or Special, not case sensitive, not required for
        ///     international elections)
        /// </summary>
        [JsonProperty("election_period")]
        public string ElectionPeriod { get; set; }

        /// <summary>
        ///     party for primary elections (http://nationbuilder.com/political_party_codes)
        /// </summary>
        [JsonProperty("party")]
        public char? Party { get; set; }

        /// <summary>
        ///     which state the election was held in (required for US elections)
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        ///     how the ballot was cast (required)
        /// </summary>
        [JsonProperty("vote_method")]
        public string VoteMethod { get; set; }
    }
}