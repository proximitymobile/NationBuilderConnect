using System;
using Newtonsoft.Json;

namespace NationBuilderConnect.Resources.Entities
{
    public class AbbreviatedPerson
    {
        /// <summary>
        ///     this person's birth date
        /// </summary>
        [JsonProperty("birthdate")]
        public DateTime? Birthdate { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("city_district")]
        public string CityDistrict { get; set; }

        /// <summary>
        ///     this person’s ID from CiviCRM
        /// </summary>
        [JsonProperty("civicrm_id")]
        public int? CiviCrmId { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("county_district")]
        public string CountyDistrict { get; set; }

        /// <summary>
        ///     this person’s ID from a county voter file
        /// </summary>
        [JsonProperty("county_file_id")]
        public string CountyFileId { get; set; }

        /// <summary>
        ///     timestamp representing when this person was created in the nation and also a writable attribute for new signups
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        ///     this is a boolean flag that lets us know if this person is on a do not call list
        /// </summary>
        [JsonProperty("do_not_call")]
        public bool DoNotCall { get; set; }

        /// <summary>
        ///     this is a boolean flag that lets us know if this person is on a do not contact list
        /// </summary>
        [JsonProperty("do_not_contact")]
        public bool DoNotContact { get; set; }


        /// <summary>
        ///     this person’s ID from Catalist
        /// </summary>
        [JsonProperty("dw_id")]
        public int? CatalistId { get; set; }

        /// <summary>
        ///     when reading this field clients can expect the person's best email address to be returned. A person can have up to
        ///     4 email addresses: email1, email2, email3 and email4. The best email address is the one that is not marked as bad
        ///     and is also marked as primary, that is, it is referenced by the primary_email_id field. When writing this field,
        ///     its value will be assigned to one of email1, email2, email3 and email4 and it will be marked as primary. If all 4
        ///     email fields are already populated then the first one marked as bad will be overwritten. If none of the 4 email
        ///     fields are marked as bad then the value of email will be dropped. In this case one of the 4 email fields and the
        ///     primary_email_id have to be directly updated.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        ///     boolean representing whether this person has opted-in to email correspondence
        /// </summary>
        [JsonProperty("email_opt_in")]
        public bool EmailOptIn { get; set; }

        /// <summary>
        ///     the name of the company for which this person works
        /// </summary>
        [JsonProperty("employer")]
        public string Employer { get; set; }

        /// <summary>
        ///     a string representing an external identifier for this person
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("federal_district")]
        public string FederalDistrict { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("fire_district")]
        public string FireDistrict { get; set; }

        /// <summary>
        ///     the person's first name and middle names
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     a boolean representing whether this person has Facebook information
        /// </summary>
        [JsonProperty("has_facebook")]
        public bool HasFacebook { get; set; }

        /// <summary>
        ///     the NationBuilder ID of the person, specific to the authorized nation
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        ///     whether the person is a Twitter follower of one of the nation’s broadcasters
        /// </summary>
        [JsonProperty("is_twitter_follower")]
        public bool IsTwitterFollower { get; set; }

        /// <summary>
        ///     a boolean field that indicates whether the person has volunteered
        /// </summary>
        [JsonProperty("is_volunteer")]
        public bool IsVolunteer { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("judicial_district")]
        public string JudicialDistrict { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("labour_region")]
        public string LabourRegion { get; set; }

        /// <summary>
        ///     this person's last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        ///     this person’s ID from LinkedIn
        /// </summary>
        [JsonProperty("linkedin_id")]
        public string LinkedinId { get; set; }

        /// <summary>
        ///     this person's cell phone number
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        ///     a boolean representing whether the person has opted-in to mobile correspondence
        /// </summary>
        [JsonProperty("mobile_opt_in")]
        public bool MobileOptIn { get; set; }

        /// <summary>
        ///     this person’s ID from the NationBuilder Election Center
        /// </summary>
        [JsonProperty("nbec_guid")]
        public Guid? NbElectionCenterGuid { get; set; }

        /// <summary>
        ///     this person’s ID from NGP
        /// </summary>
        [JsonProperty("ngp_id")]
        public string NgpId { get; set; }

        /// <summary>
        ///     a note to attach to the person's profile
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; set; }

        /// <summary>
        ///     the type of work this person does
        /// </summary>
        [JsonProperty("occupation")]
        public string Occupation { get; set; }

        /// <summary>
        ///     a one-letter code representing provincial parties for nations
        /// </summary>
        [JsonProperty("party")]
        public char? Party { get; set; }

        /// <summary>
        ///     a person’s historical ID from PoliticalForce
        /// </summary>
        [JsonProperty("pf_strat_id")]
        public long? PoliticalForceId { get; set; }

        /// <summary>
        ///     this person's home phone number
        /// </summary>
        [JsonProperty("phone")]
        public string Phone { get; set; }

        /// <summary>
        ///     the ID of the precinct associated with this person
        /// </summary>
        [JsonProperty("precinct_id")]
        public int? PrecinctId { get; set; }

        /// <summary>
        ///     an address resource representing the primary address
        /// </summary>
        [JsonProperty("primary_address")]
        public PersonAddress PrimaryAddress { get; set; }

        /// <summary>
        ///     the ID of the person who recruited this person
        /// </summary>
        [JsonProperty("recruiter_id")]
        public int? RecruiterId { get; set; }

        /// <summary>
        ///     this person’s ID from the RNC
        /// </summary>
        [JsonProperty("rnc_id")]
        public long? RncId { get; set; }

        /// <summary>
        ///     this person’s registration ID from the RNC
        /// </summary>
        [JsonProperty("rnc_regid")]
        public Guid? RncRegistrationId { get; set; }

        /// <summary>
        ///     this person’s ID from Salesforce
        /// </summary>
        [JsonProperty("salesforce_id")]
        public string SalesforceId { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("school_district")]
        public string SchoolDistrict { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("school_sub_district")]
        public string SchoolSubDistrict { get; set; }

        /// <summary>
        ///     this person's gender (M, F or O)
        /// </summary>
        [JsonProperty("sex")]
        public char? Sex { get; set; }

        /// <summary>
        ///     this person’s ID from a state voter file
        /// </summary>
        [JsonProperty("state_file_id")]
        public string StateFileId { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("state_lower_district")]
        public string StateLowerDistrict { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("state_upper_district")]
        public string StateUpperDistrict { get; set; }

        /// <summary>
        ///     the level of support this person has for your nation, expressed as a number between 1 and 5, 1 being Strong
        ///     support, 5 meaning strong opposition, and 3 meaning undecided.
        /// </summary>
        [JsonProperty("support_level")]
        public byte? SupportLevel { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("supranational_district")]
        public string SupranationalDistrict { get; set; }

        /// <summary>
        ///     the tags assigned to this person, as an array of strings
        /// </summary>
        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        /// <summary>
        ///     this person’s ID from Twitter
        /// </summary>
        [JsonProperty("twitter_id")]
        public long? TwitterId { get; set; }

        /// <summary>
        ///     this person’s Twitter handle, e.g. FoobarSoftwares
        /// </summary>
        [JsonProperty("twitter_name")]
        public string TwitterName { get; set; }

        /// <summary>
        ///     the timestamp representing when this person was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        ///     this person’s ID from VAN
        /// </summary>
        [JsonProperty("van_id")]
        public string VanId { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("village_district")]
        public string VillageDistrict { get; set; }
    }
}