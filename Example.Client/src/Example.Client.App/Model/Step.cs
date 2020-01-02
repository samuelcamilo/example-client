namespace Example.Client.App.Model
{
    public class Step
    {
        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        public string Instruction { get; set; }
        public string Maneuver { get; set; }
        public string TravelMode { get; set; }

        public Step(Distance distance, Duration duration, Location startLocation, 
            Location endLocation, string instruc, string maneuver, string travelMode) 
        {
            this.Distance = distance;
            this.Duration = duration;
            this.StartLocation = startLocation;
            this.EndLocation = endLocation;
            this.Instruction = instruc;
            this.Maneuver = maneuver;
            this.TravelMode = travelMode;
        }
    }
}