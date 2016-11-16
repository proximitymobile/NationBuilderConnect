using NationBuilderConnect.Utilities;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Entities
{
    public class PersonAddressUpdate : ITracksChanges
    {
        /// <summary>
        ///     first address line
        /// </summary>
        [JsonProperty("address1")]
        public string Address1 { get; set; }

        /// <summary>
        ///     second address line
        /// </summary>
        [JsonProperty("address2")]
        public string Address2 { get; set; }

        /// <summary>
        ///     third address line
        /// </summary>
        [JsonProperty("address3")]
        public string Address3 { get; set; }

        /// <summary>
        ///     city
        /// </summary>
        [JsonProperty("city")]
        public string City { get; set; }

        /// <summary>
        ///     state
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; }

        /// <summary>
        ///     zip code
        /// </summary>
        [JsonProperty("zip")]
        public string Zip { get; set; }

        /// <summary>
        ///     country code
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        /// <summary>
        ///     latitude (using WGS-84)
        /// </summary>
        [JsonProperty("lat")]
        public double? Latitude { get; set; }

        /// <summary>
        ///     longitude (using WGS-84)
        /// </summary>
        [JsonProperty("lng")]
        public double? Longitude { get; set; }
    }
}