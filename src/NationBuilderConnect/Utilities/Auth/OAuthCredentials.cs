namespace NationBuilderConnect.Utilities.Auth
{
    public class OAuthCredentials : ICredentials
    {
        public OAuthCredentials(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}