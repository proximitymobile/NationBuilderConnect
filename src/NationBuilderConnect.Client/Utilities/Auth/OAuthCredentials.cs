namespace NationBuilderConnect.Client.Utilities.Auth
{
    /// <summary>
    ///     OAuth credentials
    /// </summary>
    public class OAuthCredentials : ICredentials
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OAuthCredentials" /> class
        /// </summary>
        /// <param name="token">The oauth token</param>
        public OAuthCredentials(string token)
        {
            Token = token;
        }

        /// <summary>
        ///     The oauth token
        /// </summary>
        public string Token { get; private set; }
    }
}