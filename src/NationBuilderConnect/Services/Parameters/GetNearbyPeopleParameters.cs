using NationBuilderConnect.Resources.Entities;
using NationBuilderConnect.Utilities;

namespace NationBuilderConnect.Services.Parameters
{
    public class GetNearbyPeopleParameters
    {
        public GetNearbyPeopleParameters(Coordinates location, int distance)
        {
            Location = location;
            Distance = distance;
        }

        [QueryStringParameter("location")]
        public Coordinates Location { get; private set; }

        [QueryStringParameter("distance")]
        public int Distance { get; private set; }
    }
}