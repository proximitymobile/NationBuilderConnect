namespace NationBuilderConnect.Resources.Entities
{
    public class Coordinates
    {
        public Coordinates(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public override string ToString()
        {
            return $"{Latitude},{Longitude}";
        }
    }
}