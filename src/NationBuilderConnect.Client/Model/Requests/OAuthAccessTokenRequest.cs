using Newtonsoft.Json;

namespace NationBuilderConnect.Client.Model.Requests
{
    public class OAuthAccessTokenRequest
    {
        public OAuthAccessTokenRequest(string clientId, string clientSecret, string redirectUri, string code, string grantType)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            RedirectUri = redirectUri;
            Code = code;
            GrantType = grantType;
        }

        [JsonProperty("client_id")]
        public string ClientId { get; private set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; private set; }

        [JsonProperty("redirect_uri")]
        public string RedirectUri { get; private set; }

        [JsonProperty("grant_type")]
        public string GrantType { get; private set; }

        [JsonProperty("code")]
        public string Code { get; private set; }
    }
}