namespace NationBuilderConnect.Client.Utilities.Auth
{
    /// <summary>
    ///     Simple API token auth
    /// </summary>
    public class SimpleApiTokenCredentials : ICredentials
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SimpleApiTokenCredentials" /> class
        /// </summary>
        /// <param name="token">The auth token</param>
        public SimpleApiTokenCredentials(string token)
        {
            Token = token;
        }

        /// <summary>
        ///     The auth token
        /// </summary>
        public string Token { get; private set; }
    }
}