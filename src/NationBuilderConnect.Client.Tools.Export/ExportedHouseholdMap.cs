using CsvHelper.Configuration;

namespace NationBuilderConnect.Client.Tools.Export
{
    internal sealed class ExportedHouseholdMap : CsvClassMap<ExportedHousehold>
    {
        public ExportedHouseholdMap()
        {
            Map(m => m.Name).Name("name");
            Map(m => m.NumberOfResidents).Name("number_of_residents");
            Map(m => m.SignupIdsRaw).Name("signup_ids");
            Map(m => m.HouseholdAddress1).Name("household_address1");
            Map(m => m.HouseholdAddress2).Name("household_address2");
            Map(m => m.HouseholdCity).Name("household_city");
            Map(m => m.HouseholdState).Name("household_state");
            Map(m => m.HouseholdZip).Name("household_zip");
            Map(m => m.HouseholdCountry).Name("household_country");
            Map(m => m.MailingAddress1).Name("mailing_address1");
            Map(m => m.MailingAddress2).Name("mailing_address2");
            Map(m => m.MailingCity).Name("mailing_city");
            Map(m => m.MailingState).Name("mailing_state");
            Map(m => m.MailingZip).Name("mailing_zip");
            Map(m => m.MailingCountry).Name("mailing_country");
        }
    }
}