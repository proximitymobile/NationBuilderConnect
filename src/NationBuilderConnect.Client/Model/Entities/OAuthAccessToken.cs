using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Entities
{
    /// <summary>
    /// OAuth access token information
    /// </summary>
    public class OAuthAccessToken
    {
        /// <summary>
        /// The token value
        /// </summary>
        [JsonProperty("access_token")]
        public string AccessToken { get; private set; }

        /// <summary>
        /// The token type
        /// </summary>
        [JsonProperty("token_type")]
        public string TokenType { get; private set; }

        /// <summary>
        /// The token scope
        /// </summary>
        [JsonProperty("scope")]
        public string Scope { get; private set; }
    }
}