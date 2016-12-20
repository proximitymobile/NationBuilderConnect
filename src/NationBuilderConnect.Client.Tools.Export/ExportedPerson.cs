using System;

namespace NationBuilderConnect.Client.Tools.Export
{
    public class ExportedPerson : CsvRecord
    {
        /// <summary>
        ///     the date at which to consider a customer no longer active
        /// </summary>
        public DateTime? ActiveCustomerExpiresAt { get; private set; }

        /// <summary>
        ///     the date from which a customer is considered active
        /// </summary>
        public DateTime? ActiveCustomerStartedAt { get; private set; }

        public string AddressAddress1 { get; private set; }
        public string AddressAddress2 { get; private set; }
        public string AddressAddress3 { get; private set; }
        public string AddressCity { get; private set; }
        public string AddressCountry { get; private set; }
        public string AddressCountryCode { get; private set; }
        public string AddressCounty { get; private set; }
        public string AddressFips { get; private set; }
        public byte? AddressGeocodeAccuracy { get; private set; }
        public string AddressState { get; private set; }
        public string AddressSubmittedAddress { get; private set; }
        public string AddressZip { get; private set; }
        public DateTime? Availability { get; private set; }
        public DateTime? BornAt { get; private set; }
        public string CapitalAmount { get; private set; }
        public int CapitalAmountInCents { get; private set; }

        /// <summary>
        ///     the church that this person goes to
        /// </summary>
        public string Church { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string CityDistrict { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string CitySubDistrict { get; private set; }

        /// <summary>
        ///     this person’s ID from CiviCRM
        /// </summary>
        public int? CiviCrmId { get; private set; }

        public string ClosedInvoicesAmount { get; private set; }

        /// <summary>
        ///     the aggregate amount of all this person’s closed invoices in cents
        /// </summary>
        public int ClosedInvoicesAmountInCents { get; private set; }

        /// <summary>
        ///     the number of closed invoices associated with this person
        /// </summary>
        public int ClosedInvoicesCount { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string CountyDistrict { get; private set; }

        /// <summary>
        ///     this person’s ID from a county voter file
        /// </summary>
        public string CountyFileId { get; private set; }

        /// <summary>
        ///     timestamp representing when this person was created in the nation and also a writable attribute for new signups
        /// </summary>
        public DateTime? CreatedAt { get; private set; }

        /// <summary>
        ///     The ID from DataTrust
        /// </summary>
        public string DataTrustId { get; private set; }

        /// <summary>
        ///     Asian, Black, Hispanic, White, Other, Unknown
        /// </summary>
        public string Demographic { get; private set; }

        /// <summary>
        ///     this is a boolean flag that lets us know if this person is on a do not call list
        /// </summary>
        public bool DoNotCall { get; private set; }

        /// <summary>
        ///     this is a boolean flag that lets us know if this person is on a do not contact list
        /// </summary>
        public bool DoNotContact { get; private set; }

        public string DonationsAmount { get; private set; }

        /// <summary>
        ///     aggregate amount of all this person’s donations in cents
        /// </summary>
        public int DonationsAmountInCents { get; private set; }

        public string DonationsAmountThisCycle { get; private set; }

        /// <summary>
        ///     the aggregate value of the donations this person made this cycle in cents
        /// </summary>
        public int DonationsAmountThisCycleInCents { get; private set; }

        /// <summary>
        ///     the total number of donations made by this person
        /// </summary>
        public int DonationsCount { get; private set; }

        /// <summary>
        ///     the number of donations this person made this cycle
        /// </summary>
        public int DonationsCountThisCycle { get; private set; }

        public string DonationsPledgedAmountIn { get; private set; }

        /// <summary>
        ///     the aggregate amount of the donations pledged by this person in cents
        /// </summary>
        public int DonationsPledgedAmountInCents { get; private set; }

        public string DonationsRaisedAmount { get; private set; }

        /// <summary>
        ///     the aggregate amount of the donations raised by this person in cents, including their own donations
        /// </summary>
        public int DonationsRaisedAmountInCents { get; private set; }

        public string DonationsRaisedAmountThisCycle { get; private set; }

        /// <summary>
        ///     the aggregate value of all donations raised this cycle by this person, including their own
        /// </summary>
        public int DonationsRaisedAmountThisCycleInCents { get; private set; }

        /// <summary>
        ///     the total number of donations raised
        /// </summary>
        public int DonationsRaisedCount { get; private set; }

        /// <summary>
        ///     the number of donations raised this cycle by this person, including their own
        /// </summary>
        public int DonationsRaisedCountThisCycle { get; private set; }

        /// <summary>
        ///     this person’s ID from Catalist
        /// </summary>
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
        public string Email { get; private set; }

        /// <summary>
        ///     boolean representing whether this person has opted-in to email correspondence
        /// </summary>
        public bool EmailOptIn { get; private set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        public string Email1 { get; private set; }

        /// <summary>
        ///     boolean indicating if email1 for this person is bad
        /// </summary>
        public bool Email1IsBad { get; private set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        public string Email2 { get; private set; }

        /// <summary>
        ///     boolean indicating if email2 for this person is bad
        /// </summary>
        public bool Email2IsBad { get; private set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        public string Email3 { get; private set; }

        /// <summary>
        ///     boolean indicating if email3 for this person is bad
        /// </summary>
        public bool Email3IsBad { get; private set; }

        /// <summary>
        ///     an email address for this person
        /// </summary>
        public string Email4 { get; private set; }

        /// <summary>
        ///     boolean indicating if email4 for this person is bad
        /// </summary>
        public bool Email4IsBad { get; private set; }

        /// <summary>
        ///     the name of the company for which this person works
        /// </summary>
        public string Employer { get; private set; }

        /// <summary>
        ///     the ethnicity of this person as free text
        /// </summary>
        public string Ethnicity { get; private set; }

        /// <summary>
        ///     a string representing an external identifier for this person
        /// </summary>
        public string ExternalId { get; private set; }

        /// <summary>
        ///     this person’s address based on their Facebook profile
        /// </summary>
        public string FacebookAddress { get; private set; }

        /// <summary>
        ///     the fax number associated with this person
        /// </summary>
        public string FaxNumber { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string FederalDistrict { get; private set; }

        /// <summary>
        ///     boolean value indicating if this user is on the U.S. Federal Do Not Call list
        /// </summary>
        public bool FederalDoNotCall { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string FireDistrict { get; private set; }

        /// <summary>
        ///     date and time of this person's first donation
        /// </summary>
        public DateTime? FirstDonatedAt { get; private set; }

        /// <summary>
        ///     date and time of this person's first invoice
        /// </summary>
        public DateTime? FirstInvoiceAt { get; private set; }

        /// <summary>
        ///     the person's first name and middle names
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        ///     this person’s full name
        /// </summary>
        public string FullName { get; private set; }

        /// <summary>
        ///     the party the person is believed to be associated with
        /// </summary>
        public char? InferredParty { get; private set; }

        /// <summary>
        ///     a possible support level
        /// </summary>
        public byte? InferredSupportLevel { get; private set; }

        public string InvoicePaymentsAmount { get; private set; }

        /// <summary>
        ///     total invoice payment amount (cents)
        /// </summary>
        public int InvoicePaymentsAmountInCents { get; private set; }

        /// <summary>
        ///     the aggregate amount of invoice payments made by recruits of this person (cents)
        /// </summary>
        public int InvoicePaymentsReferredAmountInCents { get; private set; }

        public string InvoicesAmount { get; private set; }

        /// <summary>
        ///     the aggregate amount of all of this person’s invoices (cents)
        /// </summary>
        public int InvoicesAmountInCents { get; private set; }

        /// <summary>
        ///     the number of invoices this person has
        /// </summary>
        public int InvoicesCount { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person is alive or not
        /// </summary>
        public bool IsCustomer { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person is alive or not
        /// </summary>
        public bool IsDeceased { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if the person has donated
        /// </summary>
        public bool IsDonor { get; private set; }

        /// <summary>
        ///     a boolean value that indicates if this person has previously fundraised
        /// </summary>
        public bool IsFundraiser { get; private set; }

        /// <summary>
        ///     a boolean that indicates whether this person is not subject to donation limits associated with the nation
        /// </summary>
        public bool IsIgnoreDonationLimits { get; private set; }

        /// <summary>
        ///     a boolean reflecting whether this person’s cell number is invalid
        /// </summary>
        public bool IsMobileBad { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if this person is a prospect
        /// </summary>
        public bool IsProspect { get; private set; }

        /// <summary>
        ///     a boolean field that indicates if this person is a supporter
        /// </summary>
        public bool IsSupporter { get; private set; }

        /// <summary>
        ///     a boolean field that indicates whether the person has volunteered
        /// </summary>
        public bool IsVolunteer { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string JudicialDistrict { get; private set; }

        /// <summary>
        ///     this person’s primary language
        /// </summary>
        public string Language { get; private set; }

        /// <summary>
        ///     the time and date of this person’s last donation
        /// </summary>
        public DateTime? LastDonatedAt { get; private set; }

        /// <summary>
        ///     the time and date of this person’s last invoice
        /// </summary>
        public DateTime? LastInvoiceAt { get; private set; }

        /// <summary>
        ///     this person's last name
        /// </summary>
        public string LastName { get; private set; }

        /// <summary>
        ///     the full (legal) name of this person
        /// </summary>
        public string LegalName { get; private set; }

        /// <summary>
        ///     first address line
        /// </summary>
        public string MailingAddress1 { get; private set; }

        /// <summary>
        ///     second address line
        /// </summary>
        public string MailingAddress2 { get; private set; }

        /// <summary>
        ///     third address line
        /// </summary>
        public string MailingAddress3 { get; private set; }

        public string MailingCarrierRoute { get; private set; }
        public string MailingCity { get; private set; }
        public string MailingCountry { get; private set; }
        public string MailingCountryCode { get; private set; }
        public string MailingCounty { get; private set; }
        public string MailingDeliveryPoint { get; private set; }
        public string MailingFips { get; private set; }
        public byte? MailingGeocodeAccuracy { get; private set; }
        public string MailingLot { get; private set; }
        public string MailingSortSequence { get; private set; }
        public string MailingState { get; private set; }
        public string MailingStreetName { get; private set; }
        public string MailingStreetNumber { get; private set; }
        public string MailingStreetPrefix { get; private set; }
        public string MailingStreetSuffix { get; private set; }
        public string MailingStreetType { get; private set; }
        public string MailingSubmittedAddress { get; private set; }
        public string MailingUnitNumber { get; private set; }
        public string MailingZip { get; private set; }
        public string MailingZip4 { get; private set; }
        public string MailingZip5 { get; private set; }

        /// <summary>
        ///     the person’s marital status
        /// </summary>
        public char? MaritalStatus { get; private set; }

        public string MaximumDonationPossibleThisCycle { get; private set; }
        public int MaximumDonationPossibleThisCycleInCents { get; private set; }

        /// <summary>
        ///     the name of this person’s media market
        /// </summary>
        public string MediaMarketName { get; private set; }

        /// <summary>
        ///     an address resource based on this person’s profile in Meetup
        /// </summary>
        public string MeetupAddress { get; private set; }

        public string[] MembershipNames { get; private set; }

        /// <summary>
        ///     this person’s middle name
        /// </summary>
        public string MiddleName { get; private set; }

        /// <summary>
        ///     this person's cell phone number
        /// </summary>
        public string MobileNumber { get; private set; }

        /// <summary>
        ///     a boolean representing whether the person has opted-in to mobile correspondence
        /// </summary>
        public bool MobileOptIn { get; private set; }

        /// <summary>
        ///     The person's NationBuilder ID
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        ///     this person’s ID from the NationBuilder Election Center
        /// </summary>
        public Guid? NbElectionCenterGuid { get; private set; }

        /// <summary>
        ///     this person’s ID from NGP
        /// </summary>
        public string NgpId { get; private set; }

        /// <summary>
        ///     a note to attach to the person's profile
        /// </summary>
        public string Note { get; private set; }

        /// <summary>
        ///     the type of work this person does
        /// </summary>
        public string Occupation { get; private set; }

        public string OutstandingInvoicesAmount { get; private set; }

        /// <summary>
        ///     the aggregate value of all this person’s outstanding invoices in cents
        /// </summary>
        public int OutstandingInvoicesAmountInCents { get; private set; }

        /// <summary>
        ///     the number of outstanding invoices this person has
        /// </summary>
        public int OutstandingInvoicesCount { get; private set; }

        /// <summary>
        ///     the NationBuilder ID of this person’s point person
        /// </summary>
        public int? ParentId { get; private set; }

        /// <summary>
        ///     a one-letter code representing provincial parties for nations
        /// </summary>
        public char? Party { get; private set; }

        /// <summary>
        ///     a boolean that tells if this person is a member of a political party
        /// </summary>
        public bool? PartyMember { get; private set; }

        /// <summary>
        ///     a person’s historical ID from PoliticalForce
        /// </summary>
        public long? PoliticalForceId { get; private set; }

        /// <summary>
        ///     this person's home phone number
        /// </summary>
        public string PhoneNumber { get; private set; }

        public string PointPersonNameOrEmail { get; private set; }

        /// <summary>
        ///     the code of the precinct that this person lives in
        /// </summary>
        public string PrecinctCode { get; private set; }

        /// <summary>
        ///     the name of the precinct that this person votes in
        /// </summary>
        public string PrecinctName { get; private set; }

        /// <summary>
        ///     the name prefix of this person, i.e. Mr., Mrs.
        /// </summary>
        public string Prefix { get; private set; }

        /// <summary>
        ///     the party this person had selected before their current party selection
        /// </summary>
        public char? PreviousParty { get; private set; }

        public string PrimaryAddressAddress1 { get; private set; }
        public string PrimaryAddressAddress2 { get; private set; }
        public string PrimaryAddressAddress3 { get; private set; }
        public string PrimaryAddressCity { get; private set; }
        public string PrimaryAddressCountry { get; private set; }
        public string PrimaryAddressCountry_code { get; private set; }
        public string PrimaryAddressCounty { get; private set; }
        public string PrimaryAddressFips { get; private set; }
        public byte? PrimaryAddressGeocodeAccuracy { get; private set; }
        public string PrimaryAddressState { get; private set; }
        public string PrimaryAddressSubmittedAddress { get; private set; }
        public string PrimaryAddressZip { get; private set; }

        /// <summary>
        ///     the priority level associated with this person
        /// </summary>
        public byte? PriorityLevel { get; private set; }

        public string ReceivedCapitalAmount { get; private set; }

        /// <summary>
        ///     the aggregate amount of political capital ever received by this person
        /// </summary>
        public int ReceivedCapitalAmountInCents { get; private set; }

        /// <summary>
        ///     the ID of the person who recruited this person
        /// </summary>
        public int? RecruiterId { get; private set; }

        public string RecruiterNameOrEmail { get; private set; }
        public string RegisteredAddressAddress1 { get; private set; }
        public string RegisteredAddressAddress2 { get; private set; }
        public string RegisteredAddressAddress3 { get; private set; }
        public string RegisteredAddressCarrierRoute { get; private set; }
        public string RegisteredAddressCity { get; private set; }
        public string RegisteredAddressCountry { get; private set; }
        public string RegisteredAddressCountry_code { get; private set; }
        public string RegisteredAddressCounty { get; private set; }
        public string RegisteredAddressDeliveryPoint { get; private set; }
        public string RegisteredAddressFips { get; private set; }
        public byte? RegisteredAddressGeocodeAccuracy { get; private set; }
        public string RegisteredAddressLot { get; private set; }
        public string RegisteredAddressSortSequence { get; private set; }
        public string RegisteredAddressState { get; private set; }
        public string RegisteredAddressStreetName { get; private set; }
        public string RegisteredAddressStreetNumber { get; private set; }
        public string RegisteredAddressStreetPrefix { get; private set; }
        public string RegisteredAddressStreetSuffix { get; private set; }
        public string RegisteredAddressStreetType { get; private set; }
        public string RegisteredAddressSubmittedAddress { get; private set; }
        public string RegisteredAddressUnitNumber { get; private set; }
        public string RegisteredAddressZip { get; private set; }
        public string RegisteredAddressZip4 { get; private set; }
        public string RegisteredAddressZip5 { get; private set; }

        /// <summary>
        ///     this person’s religion
        /// </summary>
        public string Religion { get; private set; }

        /// <summary>
        ///     this person’s ID from the RNC
        /// </summary>
        public long? RncId { get; private set; }

        /// <summary>
        ///     this person’s registration ID from the RNC
        /// </summary>
        public Guid? RncRegistractionId { get; private set; }

        /// <summary>
        ///     this person’s ID from Salesforce
        /// </summary>
        public string SalesforceId { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string SchoolDistrict { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string SchoolSubDistrict { get; private set; }

        /// <summary>
        ///     this person's gender (M, F or O)
        /// </summary>
        public char? Sex { get; private set; }

        /// <summary>
        ///     '0' for person, '1' for organization
        /// </summary>
        public byte SignupType { get; private set; }

        public string SpentCapitalAmount { get; private set; }

        /// <summary>
        ///     the aggregate amount of capital ever spent by this person (in cents)
        /// </summary>
        public int SpentCapitalAmountInCents { get; private set; }

        /// <summary>
        ///     this person’s ID from a state voter file
        /// </summary>
        public string StateFileId { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string StateLowerDistrict { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string StateUpperDistrict { get; private set; }

        /// <summary>
        ///     the suffix this person uses w/their name, i.e. Jr., Sr. or III
        /// </summary>
        public string NameSuffix { get; private set; }

        /// <summary>
        ///     the level of support this person has for your nation, expressed as a number between 1 and 5, 1 being Strong
        ///     support, 5 meaning strong opposition, and 3 meaning undecided.
        /// </summary>
        public byte? SupportLevel { get; private set; }

        /// <summary>
        ///     the likelihood that this person will support you at election time
        /// </summary>
        public byte? SupportProbabilityScore { get; private set; }

        /// <summary>
        ///     district field
        /// </summary>
        public string SupranationalDistrict { get; private set; }

        public string[] TagList { get; private set; }

        /// <summary>
        ///     the probability that this person will turn out to vote
        /// </summary>
        public byte? TurnoutProbabilityScore { get; private set; }

        /// <summary>
        ///     this person’s ID from Twitter
        /// </summary>
        public long? TwitterId { get; private set; }

        /// <summary>
        ///     this person’s Twitter login name
        /// </summary>
        public string TwitterLogin { get; private set; }

        /// <summary>
        ///     the date/time that this person unsubscribed from emails
        /// </summary>
        public DateTime? UnsubscribedFromEmailsAt { get; private set; }

        public string UserSubmittedAddressAddress1 { get; private set; }
        public string UserSubmittedAddressAddress2 { get; private set; }
        public string UserSubmittedAddressAddress3 { get; private set; }
        public string UserSubmittedAddressCity { get; private set; }
        public string UserSubmittedAddressCountry { get; private set; }
        public string UserSubmittedAddressCountry_code { get; private set; }
        public string UserSubmittedAddressCounty { get; private set; }
        public string UserSubmittedAddressFips { get; private set; }
        public byte? UserSubmittedAddressGeocodeAccuracy { get; private set; }
        public string UserSubmittedAddressState { get; private set; }
        public string UserSubmittedAddressSubmittedAddress { get; private set; }
        public string UserSubmittedAddressZip { get; private set; }

        /// <summary>
        ///     this person’s ID from VAN
        /// </summary>
        public string VanId { get; private set; }

        /// <summary>
        ///     a district field
        /// </summary>
        public string VillageDistrict { get; private set; }

        /// <summary>
        ///     the URL of this person’s website
        /// </summary>
        public string Website { get; private set; }

        public string WorkAddressAddress1 { get; private set; }
        public string WorkAddressAddress2 { get; private set; }
        public string WorkAddressAddress3 { get; private set; }
        public string WorkAddressCity { get; private set; }
        public string WorkAddressCountry { get; private set; }
        public string WorkAddressCountry_code { get; private set; }
        public string WorkAddressCounty { get; private set; }
        public string WorkAddressFips { get; private set; }
        public byte? WorkAddressGeocodeAccuracy { get; private set; }

        /// <summary>
        ///     a work phone number for this person
        /// </summary>
        public string WorkPhoneNumber { get; private set; }

        public string WorkAddressState { get; private set; }
        public string WorkAddressSubmittedAddress { get; private set; }
        public string WorkAddressZip { get; private set; }
    }
}