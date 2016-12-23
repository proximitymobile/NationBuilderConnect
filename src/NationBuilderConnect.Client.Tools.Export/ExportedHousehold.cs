using System.Collections.Generic;

namespace NationBuilderConnect.Client.Tools.Export
{
    public class ExportedHousehold : CsvRecord
    {
        public string Name { get; private set; }
        public short NumberOfResidents { get; private set; }
        public string SignupIdsRaw { get; private set; }
        public string HouseholdAddress1 { get; private set; }
        public string HouseholdAddress2 { get; private set; }
        public string HouseholdCity { get; private set; }
        public string HouseholdState { get; private set; }
        public string HouseholdZip { get; private set; }
        public string HouseholdCountry { get; private set; }
        public string MailingAddress1 { get; private set; }
        public string MailingAddress2 { get; private set; }
        public string MailingCity { get; private set; }
        public string MailingState { get; private set; }
        public string MailingZip { get; private set; }
        public string MailingCountry { get; private set; }

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