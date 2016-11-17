using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Entities
{
    public class PersonAddress
    {
        /// <summary>
        ///     first address line
        /// </summary>
        [JsonProperty("address1")]
        public string Address1 { get; private set; }

        /// <summary>
        ///     second address line
        /// </summary>
        [JsonProperty("address2")]
        public string Address2 { get; private set; }

        /// <summary>
        ///     third address line
        /// </summary>
        [JsonProperty("address3")]
        public string Address3 { get; private set; }

        /// <summary>
        ///     city
        /// </summary>
        [JsonProperty("city")]
        public string City { get; private set; }

        /// <summary>
        ///     state
        /// </summary>
        [JsonProperty("state")]
        public string State { get; private set; }

        /// <summary>
        ///     zip code
        /// </summary>
        [JsonProperty("zip")]
        public string Zip { get; private set; }

        /// <summary>
        ///     country code
        /// </summary>
        [JsonProperty("country_code")]
        public string CountryCode { get; private set; }

        /// <summary>
        ///     latitude (using WGS-84)
        /// </summary>
        [JsonProperty("lat")]
        public double? Latitude { get; private set; }

        /// <summary>
        ///     longitude (using WGS-84)
        /// </summary>
        [JsonProperty("lng")]
        public double? Longitude { get; private set; }

/* Not sure about these
                "fips": null,
                "street_number": null,
                "street_prefix": null,
                "street_name": null,
                "street_type": null,
                "street_suffix": null,
                "unit_number": null,
                "zip4": null,
                "zip5": null,
                "sort_sequence": null,
                "delivery_point": null,
                "lot": null,
                "carrier_route": null
*/
    }
}