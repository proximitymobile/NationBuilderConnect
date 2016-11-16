using System.Threading.Tasks;
using NationBuilderConnect.Resources.Entities;
using NationBuilderConnect.Resources.Requests;
using NationBuilderConnect.Utilities;

namespace NationBuilderConnect.Services
{
    public class OAuthService : NationBuilderService
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OAuthService" /> class
        /// </summary>
        /// <param name="options">
        ///     Options to use for each request issued from this instance of the service. Overrides default
        ///     values provided while initializing the client.
        /// </param>
        public OAuthService(RequestOptions options = null) : base(options)
        {
        }

        /// <summary>
        /// Gets an OAuth access token
        /// </summary>
        /// <param name="clientId">The client ID</param>
        /// <param name="clientSecret">The client secret</param>
        /// <param name="redirectUri">The uri to redirect the results to</param>
        /// <param name="authorizationCode">The authorization code</param>
        /// <returns>The OAuth access token</returns>
        public async Task<OAuthAccessToken> GetAccessTokenAsync(string clientId, string clientSecret,
            string redirectUri, string authorizationCode)
        {
            var url = Connect.UrlProvider.GetOAuthTokenUrl();

            var content = new OAuthAccessTokenRequest(
                clientId, clientSecret, redirectUri, authorizationCode,
                "authorization_code");

            return (await PostJsonAsync<OAuthAccessToken>(url, content)).Payload;
        }
    }
}