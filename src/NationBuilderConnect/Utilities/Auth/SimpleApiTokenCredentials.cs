namespace NationBuilderConnect.Utilities.Auth
{
    public class SimpleApiTokenCredentials : ICredentials
    {
        public SimpleApiTokenCredentials(string token)
        {
            Token = token;
        }

        public string Token { get; private set; }
    }
}