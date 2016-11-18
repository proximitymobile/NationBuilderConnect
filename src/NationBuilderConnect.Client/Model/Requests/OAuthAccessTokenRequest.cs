using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    /// <summary>
    ///     Request sent to the API to request an oauth token
    /// </summary>
    public class OAuthAccessTokenRequest
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OAuthAccessTokenRequest" /> class
        /// </summary>
        /// <param name="clientId">The client ID</param>
        /// <param name="clientSecret">The client secret</param>
        /// <param name="redirectUri">The redirect URI</param>
        /// <param name="code">The code</param>
        /// <param name="grantType">The grant type</param>
        public OAuthAccessTokenRequest(string clientId, string clientSecret, string redirectUri, string code,
            string grantType)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
            Code = code;
            GrantType = grantType;
        }

        /// <summary>
        ///     The client ID
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; private set; }

        /// <summary>
        ///     The client secret
        /// </summary>
        [JsonProperty("client_secret")]
        public string ClientSecret { get; private set; }

        /// <summary>
        ///     The redirect URI
        /// </summary>
        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; private set; }

        /// <summary>
        ///     The grant type
        /// </summary>
        [JsonProperty("grant_type")]
        public string GrantType { get; private set; }

        /// <summary>
        ///     The code
        /// </summary>
        [JsonProperty("code")]
        public string Code { get; private set; }
    }
}