using NationBuilderConnect.Client.Utilities;

namespace NationBuilderConnect.Client.Model
{
    /// <summary>
    ///     Represents tokens for facilitating paging through results
    /// </summary>
    public class PagingTokens
    {
        public PagingTokens()
        {
        }

        public PagingTokens(string nonce, string token)
        {
            Nonce = nonce;
            Token = token;
        }

        /// <summary>
        ///     The paging nonce
        /// </summary>
        public string Nonce { get; private set; }

        /// <summary>
        ///     The paging token
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        ///     Creates an instance of <see cref="PagingTokens" /> from a URL
        /// </summary>
        /// <param name="url">The URL to parse the values from</param>
        /// <returns>The paging tokens that were parsed</returns>
        public static PagingTokens CreateFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;
            var queryStringValues = HttpUtility.ParseQueryString(HttpUtility.GetQueryString(url));
            return new PagingTokens(queryStringValues["__nonce"], queryStringValues["__token"]);
        }
    }
}