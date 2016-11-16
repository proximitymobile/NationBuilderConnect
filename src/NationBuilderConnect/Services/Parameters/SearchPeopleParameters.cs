using System;
using System.Collections.Generic;
using NationBuilderConnect.Utilities;

namespace NationBuilderConnect.Services.Parameters
{
    public class SearchPeopleParameters
    {
        /// <summary>
        ///     first name search parameter
        /// </summary>
        [QueryStringParameter("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     last name search parameter
        /// </summary>
        [QueryStringParameter("last_name")]
        public string LastName { get; set; }

        /// <summary>
        ///     city of the primary address of people to match
        /// </summary>
        [QueryStringParameter("city")]
        public string City { get; set; }

        /// <summary>
        ///     state of the primary address of people to match
        /// </summary>
        [QueryStringParameter("state")]
        public string State { get; set; }

        /// <summary>
        ///     sex of the people to match (optional, M or F)
        /// </summary>
        [QueryStringParameter("sex")]
        public string Sex { get; set; }

        /// <summary>
        ///     date of birth of the people to match
        /// </summary>
        [QueryStringParameter("birthdate")]
        public DateTime? Birthdate { get; set; }

        /// <summary>
        ///     people updated since the given date
        /// </summary>
        [QueryStringParameter("updated_since")]
        public DateTime? UpdatedSince { get; set; }

        /// <summary>
        ///     only people with mobile phone numbers
        /// </summary>
        [QueryStringParameter("with_mobile")]
        public bool? WithMobile { get; set; }

        /// <summary>
        ///     match custom field values. It takes a nested format, e.g. {"custom_values": {"my_field_slug": "abcd"}}. In the
        ///     query string this parameter would have to be encoded as custom_values%5Bmy_field_slug%5D=abcd.
        /// </summary>
        // This parameter is handled specially
        // [QueryStringParameter("custom_values")]
        public Dictionary<string, string> CustomValues { get; set; }

        /// <summary>
        ///     civicrm_id of the person to match
        /// </summary>
        [QueryStringParameter("civicrm_id")]
        public int? CiviCrmId { get; set; }

        /// <summary>
        ///     countyfileid of the person to match
        /// </summary>
        [QueryStringParameter("county_file_id")]
        public string CountyFileId { get; set; }

        /// <summary>
        ///     statefileid of the person to match
        /// </summary>
        [QueryStringParameter("state_file_id")]
        public string StateFileId { get; set; }

        /// <summary>
        ///     datatrust_id of the person to match
        /// </summary>
        [QueryStringParameter("datatrust_id")]
        public string DataTrustId { get; set; }

        /// <summary>
        ///     dw_id of the person to match
        /// </summary>
        [QueryStringParameter("dw_id")]
        public int? CatalistId { get; set; }

        /// <summary>
        ///     mediamarketid of the person to match
        /// </summary>
        [QueryStringParameter("media_market_id")]
        public string MediaMarketId { get; set; }

        /// <summary>
        ///     membershiplevelid of the person to match
        /// </summary>
        [QueryStringParameter("membership_level_id")]
        public string MembershipLevelId { get; set; }

        /// <summary>
        ///     ngp_id of the person to match
        /// </summary>
        [QueryStringParameter("ngp_id")]
        public string NgpId { get; set; }

        /// <summary>
        ///     pfstratid of the person to match
        /// </summary>
        [QueryStringParameter("pf_strat_id")]
        public long? PoliticalForceId { get; set; }

        /// <summary>
        ///     van_id of the person to match
        /// </summary>
        [QueryStringParameter("van_id")]
        public string VanId { get; set; }

        /// <summary>
        ///     salesforce_id of the person to match
        /// </summary>
        [QueryStringParameter("salesforce_id")]
        public string SalesforceId { get; set; }

        /// <summary>
        ///     rnc_id of the person to match
        /// </summary>
        [QueryStringParameter("rnc_id")]
        public long? RncId { get; set; }

        /// <summary>
        ///     rnc_regid of the person to match
        /// </summary>
        [QueryStringParameter("rnc_regid")]
        public Guid? RncRegistrationId { get; set; }

        /// <summary>
        ///     external_id of the person to match.
        /// </summary>
        [QueryStringParameter("external_id")]
        public string ExternalId { get; set; }
    }
}