using NationBuilderConnect.Client.Utilities;

namespace NationBuilderConnect.Client.Model.Entities
{
    public class PagingTokens
    {
        public string Nonce { get; private set; }
        public string Token { get; private set; }

        public static PagingTokens CreateFromUrl(string url)
        {
            if (string.IsNullOrWhiteSpace(url)) return null;
            var queryStringValues = HttpUtility.ParseQueryString(HttpUtility.GetQueryString(url));
            return new PagingTokens
            {
                Nonce = queryStringValues["__nonce"],
                Token = queryStringValues["__token"]
            };
        }
    }
}