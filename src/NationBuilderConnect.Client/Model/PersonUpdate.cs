using System;
using NationBuilderConnect.Client.Utilities;
using NationBuilderConnect.Model;
using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model
{
    /// <summary>
    ///     Represents changes to a person, either for creating a person or updating one
    /// </summary>
    public class PersonUpdate : DataTransferObject, ITracksChanges
    {
        /// <summary>
        ///     date and time this person is available (such as for volunteer shifts)
        /// </summary>
        [JsonProperty("availability")]
        public DateTime? Availability { get; set; }

        /// <summary>
        ///     an address resource representing this person’s billing address
        /// </summary>
        [JsonProperty("billing_address")]
        public AddressUpdate BillingAddress { get; set; }

        /// <summary>
        ///     the bio information that this person provided on their public profile via the “short bio” field
        /// </summary>
        [JsonProperty("bio")]
        public string Bio { get; set; }

        /// <summary>
        ///     this person's birth date
        /// </summary>
        [JsonProperty("birthdate")]
        public DateTime? Birthdate { get; set; }

        /// <summary>
        ///     the church that this person goes to
        /// </summary>
        [JsonProperty("church")]
        public string Church { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("city_district")]
        public string CityDistrict { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("city_sub_district")]
        public string CitySubDistrict { get; set; }

        /// <summary>
        ///     this person’s ID from CiviCRM
        /// </summary>
        [JsonProperty("civicrm_id")]
        public int? CiviCrmId { get; set; }

        /// <summary>
        ///     boolean indicating if this person could vote in an election or not, derived from their election
        /// </summary>
        [JsonProperty("could_vote_status")]
        public bool? CouldVoteStatus { get; set; }

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
        ///     Asian, Black, Hispanic, White, Other, Unknown (note: Single letter)
        /// </summary>
        [JsonProperty("demo")]
        public char? Demographic { get; set; }

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
        ///     an email address for this person
        /// </summary>
        [JsonProperty("email1")]
        public string Email1 { get; set; }

        /// <summary>
        ///     boolean indicating if email1 for this person is bad
        /// </summary>
        [JsonProperty("email1_is_bad")]
        public bool Email1IsBad { get; set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        [JsonProperty("email2")]
        public string Email2 { get; set; }

        /// <summary>
        ///     boolean indicating if email2 for this person is bad
        /// </summary>
        [JsonProperty("email2_is_bad")]
        public bool Email2IsBad { get; set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        [JsonProperty("email3")]
        public string Email3 { get; set; }

        /// <summary>
        ///     boolean indicating if email3 for this person is bad
        /// </summary>
        [JsonProperty("email3_is_bad")]
        public bool Email3IsBad { get; set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        [JsonProperty("email4")]
        public string Email4 { get; set; }

        /// <summary>
        ///     boolean indicating if email4 for this person is bad
        /// </summary>
        [JsonProperty("email4_is_bad")]
        public bool Email4IsBad { get; set; }

        /// <summary>
        ///     the name of the company for which this person works
        /// </summary>
        [JsonProperty("employer")]
        public string Employer { get; set; }

        /// <summary>
        ///     the ethnicity of this person as free text
        /// </summary>
        [JsonProperty("ethnicity")]
        public string Ethnicity { get; set; }

        /// <summary>
        ///     a string representing an external identifier for this person
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        ///     this person's Facebook username
        /// </summary>
        [JsonProperty("facebook_username")]
        public string FacebookUsername { get; set; }

        /// <summary>
        ///     the fax number associated with this person
        /// </summary>
        [JsonProperty("fax_number")]
        public string FaxNumber { get; set; }

        /// <summary>
        ///     boolean value indicating if this user is on the U.S. Federal Do Not Call list
        /// </summary>
        [JsonProperty("federal_donotcall")]
        public bool FederalDoNotCall { get; set; }

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
        ///     an address resource representing the home address
        /// </summary>
        [JsonProperty("home_address")]
        public AddressUpdate HomeAddress { get; set; }

        /// <summary>
        ///     the party the person is believed to be associated with
        /// </summary>
        [JsonProperty("inferred_party")]
        public char? InferredParty { get; set; }

        /// <summary>
        ///     a possible support level
        /// </summary>
        [JsonProperty("inferred_support_level")]
        public byte? InferredSupportLevel { get; set; }

        /// <summary>
        ///     a boolean field that indicates if the person votes absentee
        /// </summary>
        [JsonProperty("is_absentee_voter")]
        public bool? IsAbsenteeVoter { get; set; }

        /// <summary>
        ///     a boolean field that indicates if the person is actively voting
        /// </summary>
        [JsonProperty("is_active_voter")]
        public bool? IsActiveVoter { get; set; }

        /// <summary>
        ///     a boolean field that indicates if the person is alive or not
        /// </summary>
        [JsonProperty("is_deceased")]
        public bool? IsDeceased { get; set; }

        /// <summary>
        ///     a boolean field that indicates if the person votes early
        /// </summary>
        [JsonProperty("is_early_voter")]
        public bool? IsEarlyVoter { get; set; }

        /// <summary>
        ///     a boolean value that indicates if this person has previously fundraised
        /// </summary>
        [JsonProperty("is_fundraiser")]
        public bool? IsFundraiser { get; set; }

        /// <summary>
        ///     a boolean that indicates whether this person is not subject to donation limits associated with the nation
        /// </summary>
        [JsonProperty("is_ignore_donation_limits")]
        public bool? IsIgnoreDonationLimits { get; set; }

        /// <summary>
        ///     a boolean that tells if this person is allowed to show up on the leaderboard
        /// </summary>
        [JsonProperty("is_leaderboardable")]
        public bool? IsLeaderboardable { get; set; }

        /// <summary>
        ///     a boolean reflecting whether this person’s cell number is invalid
        /// </summary>
        [JsonProperty("is_mobile_bad")]
        public bool? IsMobileBad { get; set; }

        /// <summary>
        ///     a boolean field that indicates if the person has registered as a permanent absentee voter
        /// </summary>
        [JsonProperty("is_permanent_absentee_voter")]
        public bool? IsPermanentAbsenteeVoter { get; set; }

        /// <summary>
        ///     a boolean that tells if this person’s profile is private
        /// </summary>
        [JsonProperty("is_profile_private")]
        public bool? IsProfilePrivate { get; set; }

        /// <summary>
        ///     a boolean that tells if this person’s profile is allowed to show up in search results
        /// </summary>
        [JsonProperty("is_profile_searchable")]
        public bool? IsProfileSearchable { get; set; }

        /// <summary>
        ///     a boolean field that indicates if this person is a supporter
        /// </summary>
        [JsonProperty("is_supporter")]
        public bool? IsSupporter { get; set; }

        /// <summary>
        ///     a boolean field that indicates if this person’s survey responses are private
        /// </summary>
        [JsonProperty("is_survey_question_private")]
        public bool? IsSurveyQuestionPrivate { get; set; }

        /// <summary>
        ///     a boolean field that indicates whether the person has volunteered
        /// </summary>
        [JsonProperty("is_volunteer")]
        public bool? IsVolunteer { get; set; }

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
        ///     this person’s primary language
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; set; }

        /// <summary>
        ///     this person's last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; set; }

        /// <summary>
        ///     the full (legal) name of this person
        /// </summary>
        [JsonProperty("legal_name")]
        public string LegalName { get; set; }

        /// <summary>
        ///     this person’s ID from LinkedIn
        /// </summary>
        [JsonProperty("linkedin_id")]
        public string LinkedinId { get; set; }

        /// <summary>
        ///     the ISO locale that the user has their administrative account set to (US, ES, FR etc.)
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; set; }

        /// <summary>
        ///     an address resource representing the mailing address
        /// </summary>
        [JsonProperty("mailing_address")]
        public AddressUpdate MailingAddress { get; set; }

        /// <summary>
        ///     the person’s marital status
        /// </summary>
        [JsonProperty("marital_status")]
        public char? MaritalStatus { get; set; }

        /// <summary>
        ///     the name of this person’s media market
        /// </summary>
        [JsonProperty("media_market_name")]
        public string MediaMarketName { get; set; }

        /// <summary>
        ///     an address resource based on this person’s profile in Meetup
        /// </summary>
        [JsonProperty("meetup_address")]
        public AddressUpdate MeetupAddress { get; set; }

        /// <summary>
        ///     this person's ID from Meetup
        /// </summary>
        [JsonProperty("meetup_id")]
        public string MeetupId { get; set; }

        /// <summary>
        ///     the time and date that this user’s membership expires
        /// </summary>
        [JsonProperty("membership_expires_at")]
        public DateTime? MembershipExpiresAt { get; set; }

        /// <summary>
        ///     the name of the level of this person’s membership
        /// </summary>
        [JsonProperty("membership_level_name")]
        public string MembershipLevelName { get; set; }

        /// <summary>
        ///     the time and date that this user started a membership
        /// </summary>
        [JsonProperty("membership_started_at")]
        public DateTime? MembershipStartedAt { get; set; }

        /// <summary>
        ///     this person’s middle name
        /// </summary>
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }

        /// <summary>
        ///     this person's cell phone number
        /// </summary>
        [JsonProperty("mobile")]
        public string Mobile { get; set; }

        /// <summary>
        ///     this person’s ID from the NationBuilder Election Center
        /// </summary>
        [JsonProperty("nbec_guid")]
        public Guid? NbElectionCenterGuid { get; set; }

        /// <summary>
        ///     the unique identifier assigned to this person in the NationBuilder Election Center
        /// </summary>
        [JsonProperty("nbec_precinct_code")]
        public string NbElectionCenterPrecinctCode { get; set; }

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
        ///     a boolean that tells if this person is a member of a political party
        /// </summary>
        [JsonProperty("party_member")]
        public bool? PartyMember { get; set; }

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
        ///     the time that has been selected as the best time to call this person
        /// </summary>
        [JsonProperty("phone_time")]
        public string PhoneTime { get; set; }

        /// <summary>
        ///     the code of the precinct that this person lives in
        /// </summary>
        [JsonProperty("precinct_code")]
        public string PrecinctCode { get; set; }

        /// <summary>
        ///     the ID of the precinct associated with this person
        /// </summary>
        [JsonProperty("precinct_id")]
        public int? PrecinctId { get; set; }

        /// <summary>
        ///     the name of the precinct that this person votes in
        /// </summary>
        [JsonProperty("precinct_name")]
        public string PrecinctName { get; set; }

        /// <summary>
        ///     the name prefix of this person, i.e. Mr., Mrs.
        /// </summary>
        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        /// <summary>
        ///     the party this person had selected before their current party selection
        /// </summary>
        [JsonProperty("previous_party")]
        public char? PreviousParty { get; set; }

        /// <summary>
        ///     the id of the primary email address associated with this person, one of: 1, 2, 3 or 4. This id corresponds to the 4
        ///     email addresses a person can have: email1, email2, email3 and email4.
        /// </summary>
        [JsonProperty("primary_email_id")]
        public byte? PrimaryEmailId { get; set; }

        /// <summary>
        ///     the priority level associated with this person
        /// </summary>
        [JsonProperty("priority_level")]
        public byte? PriorityLevel { get; set; }

        /// <summary>
        ///     the content for this person’s public profile
        /// </summary>
        [JsonProperty("profile_content")]
        public string ProfileContent { get; set; }

        /// <summary>
        ///     the headline for this person’s public profile
        /// </summary>
        [JsonProperty("profile_headline")]
        public string ProfileHeadline { get; set; }

        /// <summary>
        ///     this person’s religion
        /// </summary>
        [JsonProperty("religion")]
        public string Religion { get; set; }

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
        public Sex? Sex { get; set; }

        /// <summary>
        ///     '0' for person, '1' for organization
        /// </summary>
        [JsonProperty("signup_type")]
        public SignUpType? SignUpType { get; set; }

        /// <summary>
        ///     this person’s ID from a state voter file
        /// </summary>
        [JsonProperty("state_file_id")]
        public string StateFileId { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        /// <summary>
        ///     a district field
        /// </summary>
        /// <summary>
        ///     the address this person submitted
        /// </summary>
        [JsonProperty("submitted_address")]
        public string SubmittedAddress { get; set; }

        /// <summary>
        ///     an array of subnations that this person belongs to
        /// </summary>
        /// <summary>
        ///     the suffix this person uses w/their name, i.e. Jr., Sr. or III
        /// </summary>
        [JsonProperty("suffix")]
        public string Suffix { get; set; }

        /// <summary>
        ///     the level of support this person has for your nation, expressed as a number between 1 and 5, 1 being Strong
        ///     support, 5 meaning strong opposition, and 3 meaning undecided.
        /// </summary>
        [JsonProperty("support_level")]
        public SupportLevel? SupportLevel { get; set; }

        /// <summary>
        ///     the likelihood that this person will support you at election time
        /// </summary>
        [JsonProperty("support_probability_score")]
        public byte? SupportProbabilityScore { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("supranational_district")]
        public string SupranationalDistrict { get; set; }

        /// <summary>
        ///     the probability that this person will turn out to vote
        /// </summary>
        [JsonProperty("turnout_probability_score")]
        public byte? TurnoutProbabilityScore { get; set; }

        /// <summary>
        ///     this person’s ID from Twitter
        /// </summary>
        [JsonProperty("twitter_id")]
        public long? TwitterId { get; set; }

        /// <summary>
        ///     this person’s Twitter login name
        /// </summary>
        [JsonProperty("twitter_login")]
        public string TwitterLogin { get; set; }

        /// <summary>
        ///     this person’s NationBuilder username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; set; }

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

        /// <summary>
        ///     the last time voter data was gathered for this person
        /// </summary>
        [JsonProperty("voter_updated_at")]
        public DateTime? VoterUpdatedAt { get; set; }

        /// <summary>
        ///     the URL of this person’s website
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; set; }

        /// <summary>
        ///     an address resource representing this person’s work address
        /// </summary>
        [JsonProperty("work_address")]
        public AddressUpdate WorkAddress { get; set; }

        /// <summary>
        ///     a work phone number for this person
        /// </summary>
        [JsonProperty("work_phone_number")]
        public string WorkPhoneNumber { get; set; }
    }
}