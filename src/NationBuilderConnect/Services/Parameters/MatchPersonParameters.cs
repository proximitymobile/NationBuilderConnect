using NationBuilderConnect.Utilities;

namespace NationBuilderConnect.Services.Parameters
{
    public class MatchPersonParameters
    {
        [QueryStringParameter("first_name")]
        public string FirstName { get; set; }

        [QueryStringParameter("last_name")]
        public string LastName { get; set; }

        [QueryStringParameter("email")]
        public string Email { get; set; }

        [QueryStringParameter("phone")]
        public string HomePhone { get; set; }

        [QueryStringParameter("mobile")]
        public string MobilePhone { get; set; }
    }
}