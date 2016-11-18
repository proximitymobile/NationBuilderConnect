using NationBuilderConnect.Client.Utilities;
using NationBuilderConnect.Model;

namespace NationBuilderConnect.Client.Services.Parameters
{
    /// <summary>
    ///     The values used to search for people near a certain location
    /// </summary>
    public class GetNearbyPeopleParameters
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GetNearbyPeopleParameters" /> class
        /// </summary>
        /// <param name="location">The location to search</param>
        /// <param name="distance">The distance to search around the location in miles</param>
        public GetNearbyPeopleParameters(Coordinates location, int distance)
        {
            Location = location;
            Distance = distance;
        }

        /// <summary>
        ///     The location to search
        /// </summary>
        [QueryStringParameter("location")]
        public Coordinates Location { get; private set; }

        /// <summary>
        ///     The distance to search around the location in miles
        /// </summary>
        [QueryStringParameter("distance")]
        public int Distance { get; private set; }
    }
}