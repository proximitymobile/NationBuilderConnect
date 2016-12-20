using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     A person's address details
    /// </summary>
    public class Address : JsonReadOnlyDto
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

        /// <summary>
        ///     The county
        /// </summary>
        [JsonProperty("county")]
        public string County { get; private set; }

        /// <summary>
        ///     The FIPS county code
        /// </summary>
        [JsonProperty("fips")]
        public string FipsCode { get; private set; }

        /// <summary>
        ///     The street number
        /// </summary>
        [JsonProperty("street_number")]
        public string StreetNumber { get; private set; }

        /// <summary>
        ///     The street prefix
        /// </summary>
        [JsonProperty("street_prefix")]
        public string StreetPrefix { get; private set; }

        /// <summary>
        ///     The street name
        /// </summary>
        [JsonProperty("street_name")]
        public string StreetName { get; private set; }

        /// <summary>
        ///     The street type
        /// </summary>
        [JsonProperty("street_type")]
        public string StreetType { get; private set; }

        /// <summary>
        ///     The street suffix
        /// </summary>
        [JsonProperty("street_suffix")]
        public string StreetSuffix { get; private set; }

        /// <summary>
        ///     The unit number
        /// </summary>
        [JsonProperty("unit_number")]
        public string UnitNumber { get; private set; }

        /// <summary>
        ///     The zip 4
        /// </summary>
        [JsonProperty("zip4")]
        public string Zip4 { get; private set; }

        /// <summary>
        ///     The zip 5
        /// </summary>
        [JsonProperty("zip5")]
        public string Zip5 { get; private set; }

        /// <summary>
        ///     The sequence to sort on
        /// </summary>
        [JsonProperty("sort_sequence")]
        public string SortSequence { get; private set; }

        /// <summary>
        ///     The delivery point
        /// </summary>
        [JsonProperty("delivery_point")]
        public string DeliveryPoint { get; private set; }

        /// <summary>
        ///     The lot
        /// </summary>
        [JsonProperty("lot")]
        public string Lot { get; private set; }

        /// <summary>
        ///     The carrier route
        /// </summary>
        [JsonProperty("carrier_route")]
        public string CarrierRoute { get; private set; }
    }
}