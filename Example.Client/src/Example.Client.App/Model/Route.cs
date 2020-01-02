using System.Collections.Generic;

namespace Example.Client.App.Model
{
    public class Route
    {
        public int RouteId { get; set; }
        public string StartAddress { get; set; }
        public Location StartLocation { get; set; }
        public string EndAddress { get; set; }
        public Location EndLocation { get; set; }
        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
        public IList<Step> Steps { get; set; }

        public Route()
        {
            this.Steps = new List<Step>();
        }
    }
}