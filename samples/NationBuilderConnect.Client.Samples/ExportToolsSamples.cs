using NationBuilderConnect.Client.Tools.Export;

namespace NationBuilderConnect.Client.Samples
{
    public class ExportToolsSamples
    {
        public void ExportListAsHouseholds(int listId)
        {
            using (var exporter = new ExportReader())
            {
                var households = exporter.ExportAndGetHouseholdsFromList(listId);

                foreach (var household in households)
                {
                }
            }
        }

        public void ExportListAsPeople(int listId)
        {
            using (var exporter = new ExportReader())
            {
                var people = exporter.ExportAndGetPeopleFromList(listId);

                foreach (var person in people)
                {
                }
            }
        }
    }
}