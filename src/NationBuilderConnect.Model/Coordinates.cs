namespace NationBuilderConnect.Model
{
    /// <summary>
    ///     Coordinates as defined by decimal latitude and longitude
    /// </summary>
    public class Coordinates
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Coordinates" /> class
        /// </summary>
        /// <param name="latitude">The latitude</param>
        /// <param name="longitude">The longitude</param>
        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        /// <summary>
        ///     The latitude
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        ///     The longitude
        /// </summary>
        public double Longitude { get; private set; }

        /// <inheritDoc />
        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
        }
    }
}