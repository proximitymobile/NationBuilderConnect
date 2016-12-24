using NationBuilderConnect.Client.Utilities.Auth;

namespace NationBuilderConnect.Client.Samples
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ConnectClient.Initialize(cfg =>
            {
                cfg.WithDefaultNationSlug("YOUR_TEST_NATION_SLUG");
                cfg.WithDefaultCredentials(new SimpleApiTokenCredentials("YOUR_API_TOKEN"));
                // OR
                //cfg.WithDefaultCredentials(new OAuthCredentials("YOUR_OAUTH_TOKEN"));
            });

            var listSamples = new ListServiceSamples();
            var peopleSamples = new PeopleServiceSamples();
            var exportToolsSamples = new ExportToolsSamples();

            // WARNING - Do not run these on a production nation.
            // These samples will modify data
            //listSamples.Run();
            //peopleSamples.Run();
            //exportToolsSamples.ExportListAsHouseholds(21);
            //exportToolsSamples.ExportListAsPeople(21);

        }
    }
}