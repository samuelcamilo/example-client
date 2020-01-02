namespace Example.Client.App.Model
{
    public class Location
    {
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public Location(double latitude, double longitude) 
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }
    }
}