﻿using System;
using Newtonsoft.Json;

namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     The full details for a person
    /// </summary>
    public class Person : JsonReadOnlyDto
    {
        /// <summary>
        ///     the date at which to consider a customer no longer active
        /// </summary>
        [JsonProperty("active_customer_expires_at")]
        public DateTime? ActiveCustomerExpiresAt { get; private set; }

        /// <summary>
        ///     the date from which a customer is considered active
        /// </summary>
        [JsonProperty("active_customer_started_at")]
        public DateTime? ActiveCustomerStartedAt { get; private set; }

        /// <summary>
        ///     an abbreviated person resource representing the person who created this person’s record
        /// </summary>
        [JsonProperty("author")]
        public AbbreviatedPerson Author { get; private set; }

        /// <summary>
        ///     the resource ID of the person who created this person in the nation
        /// </summary>
        [JsonProperty("author_id")]
        public int? AuthorId { get; private set; }

        /// <summary>
        ///     the ID given to a signup when a person is auto imported
        /// </summary>
        [JsonProperty("auto_import_id")]
        public int? AutoImportId { get; private set; }

        /// <summary>
        ///     date and time this person is available (such as for volunteer shifts)
        /// </summary>
        [JsonProperty("availability")]
        public DateTime? Availability { get; private set; }

        /// <summary>
        ///     an array of ballot resources representing votes in elections
        /// </summary>
        [JsonProperty("ballots")]
        public Ballot[] Ballots { get; private set; }

        /// <summary>
        ///     the time and date this person was banned
        /// </summary>
        [JsonProperty("banned_at")]
        public DateTime? BannedAt { get; private set; }

        /// <summary>
        ///     an address resource representing this person’s billing address
        /// </summary>
        [JsonProperty("billing_address")]
        public Address BillingAddress { get; private set; }

        /// <summary>
        ///     the bio information that this person provided on their public profile via the “short bio” field
        /// </summary>
        [JsonProperty("bio")]
        public string Bio { get; private set; }

        /// <summary>
        ///     this person's birth date
        /// </summary>
        [JsonProperty("birthdate")]
        public DateTime? Birthdate { get; private set; }

        /// <summary>
        ///     the ID of the call status associated with this person
        /// </summary>
        [JsonProperty("call_status_id")]
        public int? CallStatusId { get; private set; }

        /// <summary>
        ///     the name of the call status associated with this person
        /// </summary>
        [JsonProperty("call_status_name")]
        public string CallStatusName { get; private set; }

        /// <summary>
        ///     the balance of this person’s political or social capital, in cents
        /// </summary>
        [JsonProperty("capital_amount_in_cents")]
        public int CapitalAmountInCents { get; private set; }

        /// <summary>
        ///     the number of people assigned to this person
        /// </summary>
        [JsonProperty("children_count")]
        public int ChildrenCount { get; private set; }

        /// <summary>
        ///     the church that this person goes to
        /// </summary>
        [JsonProperty("church")]
        public string Church { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("city_district")]
        public string CityDistrict { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("city_sub_district")]
        public string CitySubDistrict { get; private set; }

        /// <summary>
        ///     this person’s ID from CiviCRM
        /// </summary>
        [JsonProperty("civicrm_id")]
        public int? CiviCrmId { get; private set; }

        /// <summary>
        ///     the aggregate amount of all this person’s closed invoices in cents
        /// </summary>
        [JsonProperty("closed_invoices_amount_in_cents")]
        public int? ClosedInvoicesAmountInCents { get; private set; }

        /// <summary>
        ///     the number of closed invoices associated with this person
        /// </summary>
        [JsonProperty("closed_invoices_count")]
        public int? ClosedInvoicesCount { get; private set; }

        /// <summary>
        ///     ID of a contact status associated with this person. Possible values: 1: answered, 2: badinfo, 9: inaccessible, 3:
        ///     leftmessage, 4: meaningfulinteraction, 6: notinterested, 7: noanswer, 8: refused, 5: sendinformation, 0: other
        /// </summary>
        [JsonProperty("contact_status_id")]
        public byte? ContactStatusId { get; private set; }

        /// <summary>
        ///     name of a contact status associated with this person: Possible values: answered, badinfo, inaccessible,
        ///     leftmessage, meaningfulinteraction, notinterested, noanswer, refused, sendinformation, other
        /// </summary>
        [JsonProperty("contact_status_name")]
        public string ContactStatusName { get; private set; }

        /// <summary>
        ///     boolean indicating if this person could vote in an election or not, derived from their election
        /// </summary>
        [JsonProperty("could_vote_status")]
        public bool? CouldVoteStatus { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("county_district")]
        public string CountyDistrict { get; private set; }

        /// <summary>
        ///     this person’s ID from a county voter file
        /// </summary>
        [JsonProperty("county_file_id")]
        public string CountyFileId { get; private set; }

        /// <summary>
        ///     timestamp representing when this person was created in the nation and also a writable attribute for new signups
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        ///     The ID from DataTrust
        /// </summary>
        [JsonProperty("datatrust_id")]
        public string DataTrustId { get; private set; }

        /// <summary>
        ///     Asian, Black, Hispanic, White, Other, Unknown
        /// </summary>
        [JsonProperty("demo")]
        public char? Demographic { get; private set; }

        /// <summary>
        ///     this is a boolean flag that lets us know if this person is on a do not call list
        /// </summary>
        [JsonProperty("do_not_call")]
        public bool DoNotCall { get; private set; }

        /// <summary>
        ///     this is a boolean flag that lets us know if this person is on a do not contact list
        /// </summary>
        [JsonProperty("do_not_contact")]
        public bool DoNotContact { get; private set; }

        /// <summary>
        ///     aggregate amount of all this person’s donations in cents
        /// </summary>
        [JsonProperty("donations_amount_in_cents")]
        public int DonationsAmountInCents { get; private set; }

        /// <summary>
        ///     the aggregate value of the donations this person made this cycle in cents
        /// </summary>
        [JsonProperty("donations_amount_this_cycle_in_cents")]
        public int DonationsAmountThisCycleInCents { get; private set; }

        /// <summary>
        ///     the total number of donations made by this person
        /// </summary>
        [JsonProperty("donations_count")]
        public int DonationsCount { get; private set; }

        /// <summary>
        ///     the number of donations this person made this cycle
        /// </summary>
        [JsonProperty("donations_count_this_cycle")]
        public int DonationsCountThisCycle { get; private set; }

        /// <summary>
        ///     the aggregate amount of the donations pledged by this person in cents
        /// </summary>
        [JsonProperty("donations_pledged_amount_in_cents")]
        public int DonationsPledgedAmountInCents { get; private set; }

        /// <summary>
        ///     the aggregate amount of the donations raised by this person in cents, including their own donations
        /// </summary>
        [JsonProperty("donations_raised_amount_in_cents")]
        public int DonationsRaisedAmountInCents { get; private set; }

        /// <summary>
        ///     the aggregate value of all donations raised this cycle by this person, including their own
        /// </summary>
        [JsonProperty("donations_raised_amount_this_cycle_in_cents")]
        public int DonationsRaisedAmountThisCycleInCents { get; private set; }

        /// <summary>
        ///     the total number of donations raised
        /// </summary>
        [JsonProperty("donations_raised_count")]
        public int DonationsRaisedCount { get; private set; }

        /// <summary>
        ///     the number of donations raised this cycle by this person, including their own
        /// </summary>
        [JsonProperty("donations_raised_count_this_cycle")]
        public int DonationsRaisedCountThisCycle { get; private set; }

        /// <summary>
        ///     the goal amount of donations for this person to raise in cents
        /// </summary>
        [JsonProperty("donations_to_raise_amount_in_cents")]
        public int DonationsToRaiseAmountInCents { get; private set; }

        /// <summary>
        ///     this person’s ID from Catalist
        /// </summary>
        [JsonProperty("dw_id")]
        public int? CatalistId { get; private set; }

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
        public string Email { get; private set; }

        /// <summary>
        ///     KE - Making private since all of this information is available in other fields
        ///     but I don't want this to show up in the custom fields collection.
        /// </summary>
        [JsonProperty("emails")]
        private object Emails { get; set; }

        /// <summary>
        ///     boolean representing whether this person has opted-in to email correspondence
        /// </summary>
        [JsonProperty("email_opt_in")]
        public bool EmailOptIn { get; private set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        [JsonProperty("email1")]
        public string Email1 { get; private set; }

        /// <summary>
        ///     boolean indicating if email1 for this person is bad
        /// </summary>
        [JsonProperty("email1_is_bad")]
        public bool Email1IsBad { get; private set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        [JsonProperty("email2")]
        public string Email2 { get; private set; }

        /// <summary>
        ///     boolean indicating if email2 for this person is bad
        /// </summary>
        [JsonProperty("email2_is_bad")]
        public bool Email2IsBad { get; private set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        [JsonProperty("email3")]
        public string Email3 { get; private set; }

        /// <summary>
        ///     boolean indicating if email3 for this person is bad
        /// </summary>
        [JsonProperty("email3_is_bad")]
        public bool Email3IsBad { get; private set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        [JsonProperty("email4")]
        public string Email4 { get; private set; }

        /// <summary>
        ///     boolean indicating if email4 for this person is bad
        /// </summary>
        [JsonProperty("email4_is_bad")]
        public bool Email4IsBad { get; private set; }

        /// <summary>
        ///     the name of the company for which this person works
        /// </summary>
        [JsonProperty("employer")]
        public string Employer { get; private set; }

        /// <summary>
        ///     the ethnicity of this person as free text
        /// </summary>
        [JsonProperty("ethnicity")]
        public string Ethnicity { get; private set; }

        /// <summary>
        ///     a string representing an external identifier for this person
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; private set; }

        /// <summary>
        ///     this person’s address based on their Facebook profile
        /// </summary>
        [JsonProperty("facebook_address")]
        public string FacebookAddress { get; private set; }

        /// <summary>
        ///     the URL of this person’s Facebook profile
        /// </summary>
        [JsonProperty("facebook_profile_url")]
        public string FacebookProfileUrl { get; private set; }

        /// <summary>
        ///     the date and time this person's Facebook info was last updated
        /// </summary>
        [JsonProperty("facebook_updated_at")]
        public DateTime? FacebookUpdatedAt { get; private set; }

        /// <summary>
        ///     this person's Facebook username
        /// </summary>
        [JsonProperty("facebook_username")]
        public string FacebookUsername { get; private set; }

        /// <summary>
        ///     the fax number associated with this person
        /// </summary>
        [JsonProperty("fax_number")]
        public string FaxNumber { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("federal_district")]
        public string FederalDistrict { get; private set; }

        /// <summary>
        ///     boolean value indicating if this user is on the U.S. Federal Do Not Call list
        /// </summary>
        [JsonProperty("federal_donotcall")]
        public bool FederalDoNotCall { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("fire_district")]
        public string FireDistrict { get; private set; }

        /// <summary>
        ///     date and time of this person's first donation
        /// </summary>
        [JsonProperty("first_donated_at")]
        public DateTime? FirstDonatedAt { get; private set; }

        /// <summary>
        ///     date and time that this person first raised donation
        /// </summary>
        [JsonProperty("first_fundraised_at")]
        public DateTime? FirstFundraisedAt { get; private set; }

        /// <summary>
        ///     date and time of this person's first invoice
        /// </summary>
        [JsonProperty("first_invoice_at")]
        public DateTime? FirstInvoiceAt { get; private set; }

        /// <summary>
        ///     the person's first name and middle names
        /// </summary>
        [JsonProperty("first_name")]
        public string FirstName { get; private set; }

        /// <summary>
        ///     date and time that this user first became a prospect
        /// </summary>
        [JsonProperty("first_prospect_at")]
        public DateTime? FirstProspectAt { get; private set; }

        /// <summary>
        ///     date and time that this user was first recruited
        /// </summary>
        [JsonProperty("first_recruited_at")]
        public DateTime? FirstRecruitedAt { get; private set; }

        /// <summary>
        ///     date and time that this user became a supporter for the first time
        /// </summary>
        [JsonProperty("first_supporter_at")]
        public DateTime? FirstSupporterAt { get; private set; }

        /// <summary>
        ///     date and time that this person first volunteered
        /// </summary>
        [JsonProperty("first_volunteer_at")]
        public DateTime? FirstVolunteerAt { get; private set; }

        /// <summary>
        ///     this person’s full name
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; private set; }

        /// <summary>
        ///     a boolean representing whether this person has Facebook information
        /// </summary>
        [JsonProperty("has_facebook")]
        public bool HasFacebook { get; private set; }

        /// <summary>
        ///     an address resource representing the home address
        /// </summary>
        [JsonProperty("home_address")]
        public Address HomeAddress { get; private set; }

        /// <summary>
        ///     the NationBuilder ID of the person, specific to the authorized nation
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; private set; }

        /// <summary>
        ///     the ID associated with this person when they were imported
        /// </summary>
        [JsonProperty("import_id")]
        public int? ImportId { get; private set; }

        /// <summary>
        ///     the party the person is believed to be associated with
        /// </summary>
        [JsonProperty("inferred_party")]
        public string InferredParty { get; private set; }

        /// <summary>
        ///     a possible support level
        /// </summary>
        [JsonProperty("inferred_support_level")]
        public byte? InferredSupportLevel { get; private set; }

        /// <summary>
        ///     total invoice payment amount (cents)
        /// </summary>
        [JsonProperty("invoice_payments_amount_in_cents")]
        public int? InvoicePaymentsAmountInCents { get; private set; }

        /// <summary>
        ///     the aggregate amount of invoice payments made by recruits of this person (cents)
        /// </summary>
        [JsonProperty("invoice_payments_referred_amount_in_cents")]
        public int? InvoicePaymentsReferredAmountInCents { get; private set; }

        /// <summary>
        ///     the aggregate amount of all of this person’s invoices (cents)
        /// </summary>
        [JsonProperty("invoices_amount_in_cents")]
        public int? InvoicesAmountInCents { get; private set; }

        /// <summary>
        ///     the number of invoices this person has
        /// </summary>
        [JsonProperty("invoices_count")]
        public int? InvoicesCount { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person votes absentee
        /// </summary>
        [JsonProperty("is_absentee_voter")]
        public bool? IsAbsenteeVoter { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person is actively voting
        /// </summary>
        [JsonProperty("is_active_voter")]
        public bool? IsActiveVoter { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person is alive or not
        /// </summary>
        [JsonProperty("is_deceased")]
        public bool IsDeceased { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person has donated
        /// </summary>
        [JsonProperty("is_donor")]
        public bool IsDonor { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person has been dropped from a file (not sure about this)
        /// </summary>
        [JsonProperty("is_dropped_from_file")]
        public bool? IsDroppedFromFile { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person votes early
        /// </summary>
        [JsonProperty("is_early_voter")]
        public bool? IsEarlyVoter { get; private set; }

        /// <summary>
        ///     a boolean value that indicates if this person has previously fundraised
        /// </summary>
        [JsonProperty("is_fundraiser")]
        public bool IsFundraiser { get; private set; }

        /// <summary>
        ///     a boolean that indicates whether this person is not subject to donation limits associated with the nation
        /// </summary>
        [JsonProperty("is_ignore_donation_limits")]
        public bool IsIgnoreDonationLimits { get; private set; }

        /// <summary>
        ///     a boolean that tells if this person is allowed to show up on the leaderboard
        /// </summary>
        [JsonProperty("is_leaderboardable")]
        public bool IsLeaderboardable { get; private set; }

        /// <summary>
        ///     a boolean reflecting whether this person’s cell number is invalid
        /// </summary>
        [JsonProperty("is_mobile_bad")]
        public bool IsMobileBad { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person has registered as a permanent absentee voter
        /// </summary>
        [JsonProperty("is_permanent_absentee_voter")]
        public bool? IsPermanentAbsenteeVoter { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the NationBuilder matching algorithm thinks this person is a match to someone
        ///     else in the nation
        /// </summary>
        [JsonProperty("is_possible_duplicate")]
        public bool IsPossibleDuplicate { get; private set; }

        /// <summary>
        ///     a boolean that tells if this person’s profile is private
        /// </summary>
        [JsonProperty("is_profile_private")]
        public bool IsProfilePrivate { get; private set; }

        /// <summary>
        ///     a boolean that tells if this person’s profile is allowed to show up in search results
        /// </summary>
        [JsonProperty("is_profile_searchable")]
        public bool IsProfileSearchable { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if this person is a prospect
        /// </summary>
        [JsonProperty("is_prospect")]
        public bool IsProspect { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if this person is a supporter
        /// </summary>
        [JsonProperty("is_supporter")]
        public bool IsSupporter { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if this person’s survey responses are private
        /// </summary>
        [JsonProperty("is_survey_question_private")]
        public bool IsSurveyQuestionPrivate { get; private set; }

        /// <summary>
        ///     whether the person is a Twitter follower of one of the nation’s broadcasters
        /// </summary>
        [JsonProperty("is_twitter_follower")]
        public bool IsTwitterFollower { get; private set; }

        /// <summary>
        ///     a boolean field that indicates whether the person has volunteered
        /// </summary>
        [JsonProperty("is_volunteer")]
        public bool IsVolunteer { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("judicial_district")]
        public string JudicialDistrict { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("labour_region")]
        public string LabourRegion { get; private set; }

        /// <summary>
        ///     this person’s primary language
        /// </summary>
        [JsonProperty("language")]
        public string Language { get; private set; }

        /// <summary>
        ///     the id of the last contact to this person
        /// </summary>
        [JsonProperty("last_call_id")]
        public int? LastCallId { get; private set; }

        /// <summary>
        ///     the time and date of the last time this person was contacted
        /// </summary>
        [JsonProperty("last_contacted_at")]
        public DateTime? LastContactedAt { get; private set; }

        /// <summary>
        ///     an abbreviated person resource representing the last user who contacted this person
        /// </summary>
        [JsonProperty("last_contacted_by")]
        public AbbreviatedPerson LastContactedBy { get; private set; }

        /// <summary>
        ///     the time and date of this person’s last donation
        /// </summary>
        [JsonProperty("last_donated_at")]
        public DateTime? LastDonatedAt { get; private set; }

        /// <summary>
        ///     the time and date of the last time this person fundraised
        /// </summary>
        [JsonProperty("last_fundraised_at")]
        public DateTime? LastFundraisedAt { get; private set; }

        /// <summary>
        ///     the time and date of this person’s last invoice
        /// </summary>
        [JsonProperty("last_invoice_at")]
        public DateTime? LastInvoiceAt { get; private set; }

        /// <summary>
        ///     this person's last name
        /// </summary>
        [JsonProperty("last_name")]
        public string LastName { get; private set; }

        /// <summary>
        ///     the time and date of this person’s last rule violation
        /// </summary>
        [JsonProperty("last_rule_violation_at")]
        public DateTime? LastRuleViolationAt { get; private set; }

        /// <summary>
        ///     the full (legal) name of this person
        /// </summary>
        [JsonProperty("legal_name")]
        public string LegalName { get; private set; }

        /// <summary>
        ///     this person’s ID from LinkedIn
        /// </summary>
        [JsonProperty("linkedin_id")]
        public string LinkedinId { get; private set; }

        /// <summary>
        ///     the ISO locale that the user has their administrative account set to (US, ES, FR etc.)
        /// </summary>
        [JsonProperty("locale")]
        public string Locale { get; private set; }

        /// <summary>
        ///     an address resource representing the mailing address
        /// </summary>
        [JsonProperty("mailing_address")]
        public Address MailingAddress { get; private set; }

        /// <summary>
        ///     the person’s marital status
        /// </summary>
        [JsonProperty("marital_status")]
        public string MaritalStatus { get; private set; }

        /// <summary>
        ///     the name of this person’s media market
        /// </summary>
        [JsonProperty("media_market_name")]
        public string MediaMarketName { get; private set; }

        /// <summary>
        ///     an address resource based on this person’s profile in Meetup
        /// </summary>
        [JsonProperty("meetup_address")]
        public Address MeetupAddress { get; private set; }

        /// <summary>
        ///     this person's ID from Meetup
        /// </summary>
        [JsonProperty("meetup_id")]
        public string MeetupId { get; private set; }

        /// <summary>
        ///     the time and date that this user’s membership expires
        /// </summary>
        [JsonProperty("membership_expires_at")]
        public DateTime? MembershipExpiresAt { get; private set; }

        /// <summary>
        ///     the name of the level of this person’s membership
        /// </summary>
        [JsonProperty("membership_level_name")]
        public string MembershipLevelName { get; private set; }

        /// <summary>
        ///     the time and date that this user started a membership
        /// </summary>
        [JsonProperty("membership_started_at")]
        public DateTime? MembershipStartedAt { get; private set; }

        /// <summary>
        ///     this person’s middle name
        /// </summary>
        [JsonProperty("middle_name")]
        public string MiddleName { get; private set; }

        /// <summary>
        ///     this person's cell phone number
        /// </summary>
        [JsonProperty("mobile")]
        public string MobilePhoneNumber { get; private set; }

        /// <summary>
        ///     this person's cell phone number in normalized form
        /// </summary>
        [JsonProperty("mobile_normalized")]
        public string MobilePhoneNumberNormalized { get; private set; }

        /// <summary>
        ///     a boolean representing whether the person has opted-in to mobile correspondence
        /// </summary>
        [JsonProperty("mobile_opt_in")]
        public bool MobileOptIn { get; private set; }

        /// <summary>
        ///     this person’s ID from the NationBuilder Election Center
        /// </summary>
        [JsonProperty("nbec_guid")]
        public Guid? NbElectionCenterGuid { get; private set; }

        /// <summary>
        ///     KE - Making private since not sure what this is and not sure how to test
        ///     The person's precinct from the NationBuilder Election Center
        /// </summary>
        [JsonProperty("nbec_precinct")]
        private string NbElectionCenterPrecinct { get; set; }

        /// <summary>
        ///     the unique identifier assigned to this person in the NationBuilder Election Center
        /// </summary>
        [JsonProperty("nbec_precinct_code")]
        public string NbElectionCenterPrecinctCode { get; private set; }

        /// <summary>
        ///     this person’s ID from NGP
        /// </summary>
        [JsonProperty("ngp_id")]
        public string NgpId { get; private set; }

        /// <summary>
        ///     a note to attach to the person's profile
        /// </summary>
        [JsonProperty("note")]
        public string Note { get; private set; }

        /// <summary>
        ///     the date and time the note attached to this person was updated
        /// </summary>
        [JsonProperty("note_updated_at")]
        public DateTime? NoteUpdatedAt { get; private set; }

        /// <summary>
        ///     the type of work this person does
        /// </summary>
        [JsonProperty("occupation")]
        public string Occupation { get; private set; }

        /// <summary>
        ///     the aggregate value of all this person’s outstanding invoices in cents
        /// </summary>
        [JsonProperty("outstanding_invoices_amount_in_cents")]
        public int? OutstandingInvoicesAmountInCents { get; private set; }

        /// <summary>
        ///     the number of outstanding invoices this person has
        /// </summary>
        [JsonProperty("outstanding_invoices_count")]
        public int? OutstandingInvoicesCount { get; private set; }

        /// <summary>
        ///     the number of overdue invoices this person has
        /// </summary>
        [JsonProperty("overdue_invoices_count")]
        public int? OverdueInvoicesCount { get; private set; }

        /// <summary>
        ///     the page this person first signed up from
        /// </summary>
        [JsonProperty("page_slug")]
        public string PageSlug { get; private set; }

        /// <summary>
        ///     an abbreviated person resource representing this person’s point person
        /// </summary>
        [JsonProperty("parent")]
        public AbbreviatedPerson Parent { get; private set; }

        /// <summary>
        ///     the NationBuilder ID of this person’s point person
        /// </summary>
        [JsonProperty("parent_id")]
        public int? ParentId { get; private set; }

        /// <summary>
        ///     a one-letter code representing provincial parties for nations
        /// </summary>
        [JsonProperty("party")]
        public char? Party { get; private set; }

        /// <summary>
        ///     a boolean that tells if this person is a member of a political party
        /// </summary>
        [JsonProperty("party_member")]
        public bool? PartyMember { get; private set; }

        /// <summary>
        ///     a person’s historical ID from PoliticalForce
        /// </summary>
        [JsonProperty("pf_strat_id")]
        public long? PoliticalForceId { get; private set; }

        /// <summary>
        ///     this person's home phone number
        /// </summary>
        [JsonProperty("phone")]
        public string HomePhoneNumber { get; private set; }

        /// <summary>
        ///     this person's home phone number in normalized form
        /// </summary>
        [JsonProperty("phone_normalized")]
        public string HomePhoneNumberNormalized { get; private set; }

        /// <summary>
        ///     the time that has been selected as the best time to call this person
        /// </summary>
        [JsonProperty("phone_time")]
        public string PhoneTime { get; private set; }

        /// <summary>
        ///     the code of the precinct that this person lives in
        /// </summary>
        [JsonProperty("precinct_code")]
        public string PrecinctCode { get; private set; }

        /// <summary>
        ///     the ID of the precinct associated with this person
        /// </summary>
        [JsonProperty("precinct_id")]
        public int? PrecinctId { get; private set; }

        /// <summary>
        ///     the name of the precinct that this person votes in
        /// </summary>
        [JsonProperty("precinct_name")]
        public string PrecinctName { get; private set; }

        /// <summary>
        ///     the name prefix of this person, i.e. Mr., Mrs.
        /// </summary>
        [JsonProperty("prefix")]
        public string NamePrefix { get; private set; }

        /// <summary>
        ///     the party this person had selected before their current party selection
        /// </summary>
        [JsonProperty("previous_party")]
        public char? PreviousParty { get; private set; }

        /// <summary>
        ///     The primary address for the person
        /// </summary>
        [JsonProperty("primary_address")]
        public Address PrimaryAddress { get; private set; }

        /// <summary>
        ///     the id of the primary email address associated with this person, one of: 1, 2, 3 or 4. This id corresponds to the 4
        ///     email addresses a person can have: email1, email2, email3 and email4.
        /// </summary>
        [JsonProperty("primary_email_id")]
        public byte? PrimaryEmailId { get; private set; }

        /// <summary>
        ///     the priority level associated with this person
        /// </summary>
        [JsonProperty("priority_level")]
        public byte? PriorityLevel { get; private set; }

        /// <summary>
        ///     the date and time that this person’s priority level changed
        /// </summary>
        [JsonProperty("priority_level_changed_at")]
        public DateTime? PriorityLevelChangedAt { get; private set; }

        /// <summary>
        ///     the content for this person’s public profile
        /// </summary>
        [JsonProperty("profile_content")]
        public string ProfileContent { get; private set; }

        /// <summary>
        ///     the profile content for this person’s public profile in HTML
        /// </summary>
        [JsonProperty("profile_content_html")]
        public string ProfileContentHtml { get; private set; }

        /// <summary>
        ///     the headline for this person’s public profile
        /// </summary>
        [JsonProperty("profile_headline")]
        public string ProfileHeadline { get; private set; }

        /// <summary>
        ///     The URL for the person's profile image
        /// </summary>
        [JsonProperty("profile_image_url_ssl")]
        public string ProfileImageUrl { get; private set; }

        /// <summary>
        ///     the aggregate amount of political capital ever received by this person
        /// </summary>
        [JsonProperty("received_capital_amount_in_cents")]
        public int ReceivedCapitalAmountInCents { get; private set; }

        /// <summary>
        ///     an abbreviated person resource representing the person who recruited this person
        /// </summary>
        [JsonProperty("recruiter")]
        public AbbreviatedPerson Recruiter { get; private set; }

        /// <summary>
        ///     the ID of the person who recruited this person
        /// </summary>
        [JsonProperty("recruiter_id")]
        public int? RecruiterId { get; private set; }

        /// <summary>
        ///     the number of people that were recruited by this person
        /// </summary>
        [JsonProperty("recruits_count")]
        public int RecruitsCount { get; private set; }

        /// <summary>
        ///     an address resource representing the registered address
        /// </summary>
        [JsonProperty("registered_address")]
        public Address RegisteredAddress { get; private set; }

        /// <summary>
        ///     the date this person registered to become a voter
        /// </summary>
        [JsonProperty("registered_at")]
        public DateTime? RegisteredAt { get; private set; }

        /// <summary>
        ///     this person’s religion
        /// </summary>
        [JsonProperty("religion")]
        public string Religion { get; private set; }

        /// <summary>
        ///     this person’s ID from the RNC
        /// </summary>
        [JsonProperty("rnc_id")]
        public long? RncId { get; private set; }

        /// <summary>
        ///     this person’s registration ID from the RNC
        /// </summary>
        [JsonProperty("rnc_regid")]
        public Guid? RncRegistrationId { get; private set; }

        /// <summary>
        ///     the number of times this person has violated one of the nation’s rules
        /// </summary>
        [JsonProperty("rule_violations_count")]
        public int RuleViolationsCount { get; private set; }

        /// <summary>
        ///     this person’s ID from Salesforce
        /// </summary>
        [JsonProperty("salesforce_id")]
        public string SalesforceId { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("school_district")]
        public string SchoolDistrict { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("school_sub_district")]
        public string SchoolSubDistrict { get; private set; }

        /// <summary>
        ///     this person's gender (M, F or O)
        /// </summary>
        [JsonProperty("sex")]
        public char? Sex { get; private set; }

        /// <summary>
        ///     KE - Making private because I'm not sure what this is and not sure how to test
        ///     List of signup sources
        /// </summary>
        [JsonProperty("signup_sources")]
        private object SignupSources { get; set; }

        /// <summary>
        ///     '0' for person, '1' for organization
        /// </summary>
        [JsonProperty("signup_type")]
        public byte SignUpType { get; private set; }

        /// <summary>
        ///     the aggregate amount of capital ever spent by this person (in cents)
        /// </summary>
        [JsonProperty("spent_capital_amount_in_cents")]
        public int SpentCapitalAmountInCents { get; private set; }

        /// <summary>
        ///     this person’s ID from a state voter file
        /// </summary>
        [JsonProperty("state_file_id")]
        public string StateFileId { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("state_lower_district")]
        public string StateLowerDistrict { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("state_upper_district")]
        public string StateUpperDistrict { get; private set; }

        /// <summary>
        ///     the address this person submitted
        /// </summary>
        [JsonProperty("submitted_address")]
        public string SubmittedAddress { get; private set; }

        /// <summary>
        ///     an array of subnations that this person belongs to
        /// </summary>
        [JsonProperty("subnations")]
        public string[] Subnations { get; private set; }

        /// <summary>
        ///     the suffix this person uses w/their name, i.e. Jr., Sr. or III
        /// </summary>
        [JsonProperty("suffix")]
        public string NameSuffix { get; private set; }

        /// <summary>
        ///     the level of support this person has for your nation, expressed as a number between 1 and 5, 1 being Strong
        ///     support, 5 meaning strong opposition, and 3 meaning undecided.
        /// </summary>
        [JsonProperty("support_level")]
        public byte? SupportLevel { get; private set; }

        /// <summary>
        ///     the time and date that this person’s support level changed
        /// </summary>
        [JsonProperty("support_level_changed_at")]
        public DateTime? SupportLevelChangedAt { get; private set; }

        /// <summary>
        ///     the likelihood that this person will support you at election time
        /// </summary>
        [JsonProperty("support_probability_score")]
        public byte? SupportProbabilityScore { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        [JsonProperty("supranational_district")]
        public string SupranationalDistrict { get; private set; }

        /// <summary>
        ///     the tags assigned to this person, as an array of strings
        /// </summary>
        [JsonProperty("tags")]
        public string[] Tags { get; private set; }

        /// <summary>
        ///     The township to which this person belongs
        /// </summary>
        [JsonProperty("township")]
        public string Township { get; private set; }

        /// <summary>
        ///     the probability that this person will turn out to vote
        /// </summary>
        [JsonProperty("turnout_probability_score")]
        public byte? TurnoutProbabilityScore { get; private set; }

        /// <summary>
        ///     an address resource representing this person’s address based on Twitter’s location data
        /// </summary>
        [JsonProperty("twitter_address")]
        public Address TwitterAddress { get; private set; }

        /// <summary>
        ///     the description that this person provided in their Twitter profile
        /// </summary>
        [JsonProperty("twitter_description")]
        public string TwitterDescription { get; private set; }

        /// <summary>
        ///     the number of followers this person has on Twitter
        /// </summary>
        [JsonProperty("twitter_followers_count")]
        public int? TwitterFollowersCount { get; private set; }

        /// <summary>
        ///     the number of friends this person has on Twitter
        /// </summary>
        [JsonProperty("twitter_friends_count")]
        public int? TwitterFriendsCount { get; private set; }

        /// <summary>
        ///     this person’s ID from Twitter
        /// </summary>
        [JsonProperty("twitter_id")]
        public long? TwitterId { get; private set; }

        /// <summary>
        ///     this person’s location based on their Twitter profile
        /// </summary>
        [JsonProperty("twitter_location")]
        public string TwitterLocation { get; private set; }

        /// <summary>
        ///     this person’s Twitter login name
        /// </summary>
        [JsonProperty("twitter_login")]
        public string TwitterLogin { get; private set; }

        /// <summary>
        ///     this person’s Twitter handle, e.g. FoobarSoftwares
        /// </summary>
        [JsonProperty("twitter_name")]
        public string TwitterName { get; private set; }

        /// <summary>
        ///     the last time this person’s Twitter record was updated
        /// </summary>
        [JsonProperty("twitter_updated_at")]
        public DateTime? TwitterUpdatedAt { get; private set; }

        /// <summary>
        ///     the URL of the website that this person included in their Twitter profile
        /// </summary>
        [JsonProperty("twitter_website")]
        public string TwitterWebsite { get; private set; }

        /// <summary>
        ///     the date/time that this person unsubscribed from emails
        /// </summary>
        [JsonProperty("unsubscribed_at")]
        public DateTime? UnsubscribedFromEmailsAt { get; private set; }

        /// <summary>
        ///     the timestamp representing when this person was last updated
        /// </summary>
        [JsonProperty("updated_at")]
        public DateTime? UpdatedAt { get; private set; }

        /// <summary>
        ///     an address resource representing the address this person submitted
        /// </summary>
        [JsonProperty("user_submitted_address")]
        public Address UserSubmittedAddress { get; private set; }

        /// <summary>
        ///     this person’s NationBuilder username
        /// </summary>
        [JsonProperty("username")]
        public string Username { get; private set; }

        /// <summary>
        ///     this person’s ID from VAN
        /// </summary>
        [JsonProperty("van_id")]
        public string VanId { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        [JsonProperty("village_district")]
        public string VillageDistrict { get; private set; }

        /// <summary>
        ///     the last time voter data was gathered for this person
        /// </summary>
        [JsonProperty("voter_updated_at")]
        public DateTime? VoterUpdatedAt { get; private set; }

        /// <summary>
        ///     The ward to which this person belongs
        /// </summary>
        [JsonProperty("ward")]
        public string Ward { get; private set; }

        /// <summary>
        ///     the number of warnings this person has received
        /// </summary>
        [JsonProperty("warnings_count")]
        public int WarningsCount { get; private set; }

        /// <summary>
        ///     the URL of this person’s website
        /// </summary>
        [JsonProperty("website")]
        public string Website { get; private set; }

        /// <summary>
        ///     an address resource representing this person’s work address
        /// </summary>
        [JsonProperty("work_address")]
        public Address WorkAddress { get; private set; }

        /// <summary>
        ///     a work phone number for this person
        /// </summary>
        [JsonProperty("work_phone_number")]
        public string WorkPhoneNumber { get; private set; }
    }
}