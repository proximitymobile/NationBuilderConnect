using System.Collections.Generic;

namespace NationBuilderConnect.Client.Tools.Export
{
    public class ExportedHousehold : CsvRecord
    {
        public string Name { get; set; }
        public short NumberOfResidents { get; set; }
        public string SignupIdsRaw { get; set; }
        public string HouseholdAddress1 { get; set; }
        public string HouseholdAddress2 { get; set; }
        public string HouseholdCity { get; set; }
        public string HouseholdState { get; set; }
        public string HouseholdZip { get; set; }
        public string HouseholdCountry { get; set; }
        public string MailingAddress1 { get; set; }
        public string MailingAddress2 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZip { get; set; }
        public string MailingCountry { get; set; }

        public IEnumerable<int> GetSignupIds()
        {
            if (!string.IsNullOrWhiteSpace(SignupIdsRaw))
            {
                var split = SignupIdsRaw.Split(',');
                foreach (var item in split)
                    yield return int.Parse(item);
            }
        }
    }
}