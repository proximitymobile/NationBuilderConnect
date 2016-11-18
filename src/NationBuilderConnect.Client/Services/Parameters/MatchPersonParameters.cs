using NationBuilderConnect.Client.Utilities;

namespace NationBuilderConnect.Client.Services.Parameters
{
    /// <summary>
    ///     The values on which to match a person
    /// </summary>
    public class MatchPersonParameters
    {
        /// <summary>
        ///     The person's first name
        /// </summary>
        [QueryStringParameter("first_name")]
        public string FirstName { get; set; }

        /// <summary>
        ///     The person's last name
        /// </summary>
        [QueryStringParameter("last_name")]
        public string LastName { get; set; }

        /// <summary>
        ///     The person's email address
        /// </summary>
        [QueryStringParameter("email")]
        public string Email { get; set; }

        /// <summary>
        ///     The person's home phone number
        /// </summary>
        [QueryStringParameter("phone")]
        public string HomePhone { get; set; }

        /// <summary>
        ///     The person's mobile phone number
        /// </summary>
        [QueryStringParameter("mobile")]
        public string MobilePhone { get; set; }
    }
}