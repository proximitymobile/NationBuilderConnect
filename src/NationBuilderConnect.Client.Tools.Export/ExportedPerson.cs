using System;

namespace NationBuilderConnect.Client.Tools.Export
{
    public class ExportedPerson : CsvRecord
    {
        /// <summary>
        ///     the date at which to consider a customer no longer active
        /// </summary>
        public DateTime? ActiveCustomerExpiresAt { get; set; }

        /// <summary>
        ///     the date from which a customer is considered active
        /// </summary>
        public DateTime? ActiveCustomerStartedAt { get; set; }

        public string AddressAddress1 { get; set; }
        public string AddressAddress2 { get; set; }
        public string AddressAddress3 { get; set; }
        public string AddressCity { get; set; }
        public string AddressCountry { get; set; }
        public string AddressCountryCode { get; set; }
        public string AddressCounty { get; set; }
        public string AddressFips { get; set; }
        public byte? AddressGeocodeAccuracy { get; set; }
        public string AddressState { get; set; }
        public string AddressSubmittedAddress { get; set; }
        public string AddressZip { get; set; }
        public DateTime? Availability { get; set; }
        public DateTime? BornAt { get; set; }
        public string CapitalAmount { get; set; }
        public int? CapitalAmountInCents { get; set; }

        /// <summary>
        ///     the church that this person goes to
        /// </summary>
        public string Church { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string CityDistrict { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string CitySubDistrict { get; set; }

        /// <summary>
        ///     this person’s ID from CiviCRM
        /// </summary>
        public int? CiviCrmId { get; set; }

        public string ClosedInvoicesAmount { get; set; }

        /// <summary>
        ///     the aggregate amount of all this person’s closed invoices in cents
        /// </summary>
        public int? ClosedInvoicesAmountInCents { get; set; }

        /// <summary>
        ///     the number of closed invoices associated with this person
        /// </summary>
        public int? ClosedInvoicesCount { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string CountyDistrict { get; set; }

        /// <summary>
        ///     this person’s ID from a county voter file
        /// </summary>
        public string CountyFileId { get; set; }

        /// <summary>
        ///     timestamp representing when this person was created in the nation and also a writable attribute for new signups
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        ///     The ID from DataTrust
        /// </summary>
        public string DataTrustId { get; set; }

        /// <summary>
        ///     Asian, Black, Hispanic, White, Other, Unknown
        /// </summary>
        public string Demographic { get; set; }

        /// <summary>
        ///     this is a boolean flag that lets us know if this person is on a do not call list
        /// </summary>
        public bool DoNotCall { get; set; }

        /// <summary>
        ///     this is a boolean flag that lets us know if this person is on a do not contact list
        /// </summary>
        public bool DoNotContact { get; set; }

        public string DonationsAmount { get; set; }

        /// <summary>
        ///     aggregate amount of all this person’s donations in cents
        /// </summary>
        public int? DonationsAmountInCents { get; set; }

        public string DonationsAmountThisCycle { get; set; }

        /// <summary>
        ///     the aggregate value of the donations this person made this cycle in cents
        /// </summary>
        public int? DonationsAmountThisCycleInCents { get; set; }

        /// <summary>
        ///     the total number of donations made by this person
        /// </summary>
        public int? DonationsCount { get; set; }

        /// <summary>
        ///     the number of donations this person made this cycle
        /// </summary>
        public int? DonationsCountThisCycle { get; set; }

        public string DonationsPledgedAmountIn { get; set; }

        /// <summary>
        ///     the aggregate amount of the donations pledged by this person in cents
        /// </summary>
        public int? DonationsPledgedAmountInCents { get; set; }

        public string DonationsRaisedAmount { get; set; }

        /// <summary>
        ///     the aggregate amount of the donations raised by this person in cents, including their own donations
        /// </summary>
        public int? DonationsRaisedAmountInCents { get; set; }

        public string DonationsRaisedAmountThisCycle { get; set; }

        /// <summary>
        ///     the aggregate value of all donations raised this cycle by this person, including their own
        /// </summary>
        public int? DonationsRaisedAmountThisCycleInCents { get; set; }

        /// <summary>
        ///     the total number of donations raised
        /// </summary>
        public int? DonationsRaisedCount { get; set; }

        /// <summary>
        ///     the number of donations raised this cycle by this person, including their own
        /// </summary>
        public int? DonationsRaisedCountThisCycle { get; set; }

        /// <summary>
        ///     this person’s ID from Catalist
        /// </summary>
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
        public string Email { get; set; }

        /// <summary>
        ///     boolean representing whether this person has opted-in to email correspondence
        /// </summary>
        public bool EmailOptIn { get; set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        public string Email1 { get; set; }

        /// <summary>
        ///     boolean indicating if email1 for this person is bad
        /// </summary>
        public bool Email1IsBad { get; set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        public string Email2 { get; set; }

        /// <summary>
        ///     boolean indicating if email2 for this person is bad
        /// </summary>
        public bool Email2IsBad { get; set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        public string Email3 { get; set; }

        /// <summary>
        ///     boolean indicating if email3 for this person is bad
        /// </summary>
        public bool Email3IsBad { get; set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        public string Email4 { get; set; }

        /// <summary>
        ///     boolean indicating if email4 for this person is bad
        /// </summary>
        public bool Email4IsBad { get; set; }

        /// <summary>
        ///     the name of the company for which this person works
        /// </summary>
        public string Employer { get; set; }

        /// <summary>
        ///     the ethnicity of this person as free text
        /// </summary>
        public string Ethnicity { get; set; }

        /// <summary>
        ///     a string representing an external identifier for this person
        /// </summary>
        public string ExternalId { get; set; }

        /// <summary>
        ///     this person’s address based on their Facebook profile
        /// </summary>
        public string FacebookAddress { get; set; }

        /// <summary>
        ///     the fax number associated with this person
        /// </summary>
        public string FaxNumber { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string FederalDistrict { get; set; }

        /// <summary>
        ///     boolean value indicating if this user is on the U.S. Federal Do Not Call list
        /// </summary>
        public bool FederalDoNotCall { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string FireDistrict { get; set; }

        /// <summary>
        ///     date and time of this person's first donation
        /// </summary>
        public DateTime? FirstDonatedAt { get; set; }

        /// <summary>
        ///     date and time of this person's first invoice
        /// </summary>
        public DateTime? FirstInvoiceAt { get; set; }

        /// <summary>
        ///     the person's first name and middle names
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        ///     this person’s full name
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        ///     the party the person is believed to be associated with
        /// </summary>
        public char? InferredParty { get; set; }

        /// <summary>
        ///     a possible support level
        /// </summary>
        public byte? InferredSupportLevel { get; set; }

        public string InvoicePaymentsAmount { get; set; }

        /// <summary>
        ///     total invoice payment amount (cents)
        /// </summary>
        public int? InvoicePaymentsAmountInCents { get; set; }

        /// <summary>
        ///     the aggregate amount of invoice payments made by recruits of this person (cents)
        /// </summary>
        public int? InvoicePaymentsReferredAmountInCents { get; set; }

        public string InvoicesAmount { get; set; }

        /// <summary>
        ///     the aggregate amount of all of this person’s invoices (cents)
        /// </summary>
        public int? InvoicesAmountInCents { get; set; }

        /// <summary>
        ///     the number of invoices this person has
        /// </summary>
        public int? InvoicesCount { get; set; }

        /// <summary>
        ///     a boolean field that indicates if the person is alive or not
        /// </summary>
        public bool IsCustomer { get; set; }

        /// <summary>
        ///     a boolean field that indicates if the person is alive or not
        /// </summary>
        public bool IsDeceased { get; set; }

        /// <summary>
        ///     a boolean field that indicates if the person has donated
        /// </summary>
        public bool IsDonor { get; set; }

        /// <summary>
        ///     a boolean value that indicates if this person has previously fundraised
        /// </summary>
        public bool IsFundraiser { get; set; }

        /// <summary>
        ///     a boolean that indicates whether this person is not subject to donation limits associated with the nation
        /// </summary>
        public bool IsIgnoreDonationLimits { get; set; }

        /// <summary>
        ///     a boolean reflecting whether this person’s cell number is invalid
        /// </summary>
        public bool IsMobileBad { get; set; }

        /// <summary>
        ///     a boolean field that indicates if this person is a prospect
        /// </summary>
        public bool IsProspect { get; set; }

        /// <summary>
        ///     a boolean field that indicates if this person is a supporter
        /// </summary>
        public bool IsSupporter { get; set; }

        /// <summary>
        ///     a boolean field that indicates whether the person has volunteered
        /// </summary>
        public bool IsVolunteer { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string JudicialDistrict { get; set; }

        /// <summary>
        ///     this person’s primary language
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        ///     the time and date of this person’s last donation
        /// </summary>
        public DateTime? LastDonatedAt { get; set; }

        /// <summary>
        ///     the time and date of this person’s last invoice
        /// </summary>
        public DateTime? LastInvoiceAt { get; set; }

        /// <summary>
        ///     this person's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        ///     the full (legal) name of this person
        /// </summary>
        public string LegalName { get; set; }

        /// <summary>
        ///     first address line
        /// </summary>
        public string MailingAddress1 { get; set; }

        /// <summary>
        ///     second address line
        /// </summary>
        public string MailingAddress2 { get; set; }

        /// <summary>
        ///     third address line
        /// </summary>
        public string MailingAddress3 { get; set; }

        public string MailingCarrierRoute { get; set; }
        public string MailingCity { get; set; }
        public string MailingCountry { get; set; }
        public string MailingCountryCode { get; set; }
        public string MailingCounty { get; set; }
        public string MailingDeliveryPoint { get; set; }
        public string MailingFips { get; set; }
        public byte? MailingGeocodeAccuracy { get; set; }
        public string MailingLot { get; set; }
        public string MailingSortSequence { get; set; }
        public string MailingState { get; set; }
        public string MailingStreetName { get; set; }
        public string MailingStreetNumber { get; set; }
        public string MailingStreetPrefix { get; set; }
        public string MailingStreetSuffix { get; set; }
        public string MailingStreetType { get; set; }
        public string MailingSubmittedAddress { get; set; }
        public string MailingUnitNumber { get; set; }
        public string MailingZip { get; set; }
        public string MailingZip4 { get; set; }
        public string MailingZip5 { get; set; }

        /// <summary>
        ///     the person’s marital status
        /// </summary>
        public char? MaritalStatus { get; set; }

        public string MaximumDonationPossibleThisCycle { get; set; }
        public int? MaximumDonationPossibleThisCycleInCents { get; set; }

        /// <summary>
        ///     the name of this person’s media market
        /// </summary>
        public string MediaMarketName { get; set; }

        /// <summary>
        ///     an address resource based on this person’s profile in Meetup
        /// </summary>
        public string MeetupAddress { get; set; }

        /// <summary>
        /// Should be a list of strings
        /// </summary>
        public string MembershipNames { get; set; }

        /// <summary>
        ///     this person’s middle name
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        ///     this person's cell phone number
        /// </summary>
        public string MobileNumber { get; set; }

        /// <summary>
        ///     a boolean representing whether the person has opted-in to mobile correspondence
        /// </summary>
        public bool MobileOptIn { get; set; }

        /// <summary>
        ///     The person's NationBuilder ID
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        ///     this person’s ID from the NationBuilder Election Center
        /// </summary>
        public Guid? NbElectionCenterGuid { get; set; }

        /// <summary>
        ///     this person’s ID from NGP
        /// </summary>
        public string NgpId { get; set; }

        /// <summary>
        ///     a note to attach to the person's profile
        /// </summary>
        public string Note { get; set; }

        /// <summary>
        ///     the type of work this person does
        /// </summary>
        public string Occupation { get; set; }

        public string OutstandingInvoicesAmount { get; set; }

        /// <summary>
        ///     the aggregate value of all this person’s outstanding invoices in cents
        /// </summary>
        public int? OutstandingInvoicesAmountInCents { get; set; }

        /// <summary>
        ///     the number of outstanding invoices this person has
        /// </summary>
        public int? OutstandingInvoicesCount { get; set; }

        /// <summary>
        ///     the NationBuilder ID of this person’s point person
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        ///     a one-letter code representing provincial parties for nations
        /// </summary>
        public char? Party { get; set; }

        /// <summary>
        ///     a boolean that tells if this person is a member of a political party
        /// </summary>
        public bool? PartyMember { get; set; }

        /// <summary>
        ///     a person’s historical ID from PoliticalForce
        /// </summary>
        public long? PoliticalForceId { get; set; }

        /// <summary>
        ///     this person's home phone number
        /// </summary>
        public string PhoneNumber { get; set; }

        public string PointPersonNameOrEmail { get; set; }

        /// <summary>
        ///     the code of the precinct that this person lives in
        /// </summary>
        public string PrecinctCode { get; set; }

        /// <summary>
        ///     the name of the precinct that this person votes in
        /// </summary>
        public string PrecinctName { get; set; }

        /// <summary>
        ///     the name prefix of this person, i.e. Mr., Mrs.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        ///     the party this person had selected before their current party selection
        /// </summary>
        public char? PreviousParty { get; set; }

        public string PrimaryAddressAddress1 { get; set; }
        public string PrimaryAddressAddress2 { get; set; }
        public string PrimaryAddressAddress3 { get; set; }
        public string PrimaryAddressCity { get; set; }
        public string PrimaryAddressCountry { get; set; }
        public string PrimaryAddressCountry_code { get; set; }
        public string PrimaryAddressCounty { get; set; }
        public string PrimaryAddressFips { get; set; }
        public byte? PrimaryAddressGeocodeAccuracy { get; set; }
        public string PrimaryAddressState { get; set; }
        public string PrimaryAddressSubmittedAddress { get; set; }
        public string PrimaryAddressZip { get; set; }

        /// <summary>
        ///     the priority level associated with this person
        /// </summary>
        public byte? PriorityLevel { get; set; }

        public string ReceivedCapitalAmount { get; set; }

        /// <summary>
        ///     the aggregate amount of political capital ever received by this person
        /// </summary>
        public int? ReceivedCapitalAmountInCents { get; set; }

        /// <summary>
        ///     the ID of the person who recruited this person
        /// </summary>
        public int? RecruiterId { get; set; }

        public string RecruiterNameOrEmail { get; set; }
        public string RegisteredAddressAddress1 { get; set; }
        public string RegisteredAddressAddress2 { get; set; }
        public string RegisteredAddressAddress3 { get; set; }
        public string RegisteredAddressCarrierRoute { get; set; }
        public string RegisteredAddressCity { get; set; }
        public string RegisteredAddressCountry { get; set; }
        public string RegisteredAddressCountry_code { get; set; }
        public string RegisteredAddressCounty { get; set; }
        public string RegisteredAddressDeliveryPoint { get; set; }
        public string RegisteredAddressFips { get; set; }
        public byte? RegisteredAddressGeocodeAccuracy { get; set; }
        public string RegisteredAddressLot { get; set; }
        public string RegisteredAddressSortSequence { get; set; }
        public string RegisteredAddressState { get; set; }
        public string RegisteredAddressStreetName { get; set; }
        public string RegisteredAddressStreetNumber { get; set; }
        public string RegisteredAddressStreetPrefix { get; set; }
        public string RegisteredAddressStreetSuffix { get; set; }
        public string RegisteredAddressStreetType { get; set; }
        public string RegisteredAddressSubmittedAddress { get; set; }
        public string RegisteredAddressUnitNumber { get; set; }
        public string RegisteredAddressZip { get; set; }
        public string RegisteredAddressZip4 { get; set; }
        public string RegisteredAddressZip5 { get; set; }

        /// <summary>
        ///     this person’s religion
        /// </summary>
        public string Religion { get; set; }

        /// <summary>
        ///     this person’s ID from the RNC
        /// </summary>
        public long? RncId { get; set; }

        /// <summary>
        ///     this person’s registration ID from the RNC
        /// </summary>
        public Guid? RncRegistractionId { get; set; }

        /// <summary>
        ///     this person’s ID from Salesforce
        /// </summary>
        public string SalesforceId { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string SchoolDistrict { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string SchoolSubDistrict { get; set; }

        /// <summary>
        ///     this person's gender (M, F or O)
        /// </summary>
        public char? Sex { get; set; }

        /// <summary>
        ///     '0' for person, '1' for organization
        /// </summary>
        public byte SignupType { get; set; }

        public string SpentCapitalAmount { get; set; }

        /// <summary>
        ///     the aggregate amount of capital ever spent by this person (in cents)
        /// </summary>
        public int? SpentCapitalAmountInCents { get; set; }

        /// <summary>
        ///     this person’s ID from a state voter file
        /// </summary>
        public string StateFileId { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string StateLowerDistrict { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string StateUpperDistrict { get; set; }

        /// <summary>
        ///     the suffix this person uses w/their name, i.e. Jr., Sr. or III
        /// </summary>
        public string NameSuffix { get; set; }

        /// <summary>
        ///     the level of support this person has for your nation, expressed as a number between 1 and 5, 1 being Strong
        ///     support, 5 meaning strong opposition, and 3 meaning undecided.
        /// </summary>
        public byte? SupportLevel { get; set; }

        /// <summary>
        ///     the likelihood that this person will support you at election time
        /// </summary>
        public byte? SupportProbabilityScore { get; set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string SupranationalDistrict { get; set; }

        /// <summary>
        /// Should be a list
        /// </summary>
        public string TagList { get; set; }

        /// <summary>
        ///     the probability that this person will turn out to vote
        /// </summary>
        public byte? TurnoutProbabilityScore { get; set; }

        /// <summary>
        ///     this person’s ID from Twitter
        /// </summary>
        public long? TwitterId { get; set; }

        /// <summary>
        ///     this person’s Twitter login name
        /// </summary>
        public string TwitterLogin { get; set; }

        /// <summary>
        ///     the date/time that this person unsubscribed from emails
        /// </summary>
        public DateTime? UnsubscribedFromEmailsAt { get; set; }

        public string UserSubmittedAddressAddress1 { get; set; }
        public string UserSubmittedAddressAddress2 { get; set; }
        public string UserSubmittedAddressAddress3 { get; set; }
        public string UserSubmittedAddressCity { get; set; }
        public string UserSubmittedAddressCountry { get; set; }
        public string UserSubmittedAddressCountry_code { get; set; }
        public string UserSubmittedAddressCounty { get; set; }
        public string UserSubmittedAddressFips { get; set; }
        public byte? UserSubmittedAddressGeocodeAccuracy { get; set; }
        public string UserSubmittedAddressState { get; set; }
        public string UserSubmittedAddressSubmittedAddress { get; set; }
        public string UserSubmittedAddressZip { get; set; }

        /// <summary>
        ///     this person’s ID from VAN
        /// </summary>
        public string VanId { get; set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string VillageDistrict { get; set; }

        /// <summary>
        ///     the URL of this person’s website
        /// </summary>
        public string Website { get; set; }

        public string WorkAddressAddress1 { get; set; }
        public string WorkAddressAddress2 { get; set; }
        public string WorkAddressAddress3 { get; set; }
        public string WorkAddressCity { get; set; }
        public string WorkAddressCountry { get; set; }
        public string WorkAddressCountry_code { get; set; }
        public string WorkAddressCounty { get; set; }
        public string WorkAddressFips { get; set; }
        public byte? WorkAddressGeocodeAccuracy { get; set; }

        /// <summary>
        ///     a work phone number for this person
        /// </summary>
        public string WorkPhoneNumber { get; set; }

        public string WorkAddressState { get; set; }
        public string WorkAddressSubmittedAddress { get; set; }
        public string WorkAddressZip { get; set; }
    }
}