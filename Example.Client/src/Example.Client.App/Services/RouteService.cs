using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Example.Client.App.Model;
using Newtonsoft.Json;

namespace Example.Client.App.Services
{
    public class RouteService
    {
        public HttpClient Client { get; set; }

        public RouteService()
        {
            this.Client = new HttpClient();
        }

        public async Task<dynamic> GetRouteService()
        {
            this.Client.BaseAddress = new Uri("https://maps.googleapis.com/");
            this.Client.DefaultRequestHeaders.Accept.Clear();
            this.Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            dynamic jsonContent = null;
            HttpResponseMessage response = await this.Client.GetAsync("maps/api/directions/json?origin=-3.833779, -38.586326&destination=-3.734774,-38.503043&key=AIzaSyCo8jkp_uRBBBrMZuC9o_6TrzSxD5yv-hA");
            
            if (response.IsSuccessStatusCode)
            {
                jsonContent = await response.Content.ReadAsAsync<dynamic>();
            }

            return jsonContent;
        }

        public async Task RunAsync()
        {
            var test = await GetRouteService();

            Route route = new Route();
            
            route.StartAddress = test.routes[0].legs[0].start_address;
            route.StartLocation = new Location((double)test.routes[0].legs[0].start_location.lat, (double)test.routes[0].legs[0].start_location.lng);
            
            route.EndAddress = test.routes[0].legs[0].end_address;
            route.EndLocation = new Location((double)test.routes[0].legs[0].end_location.lat, (double)test.routes[0].legs[0].end_location.lng);

            route.Distance = new Distance((string)test.routes[0].legs[0].distance.text, (int)test.routes[0].legs[0].distance.value);
            route.Duration = new Duration((string)test.routes[0].legs[0].duration.text, (int)test.routes[0].legs[0].duration.value);

            for(int cont = 0; cont < test.routes[0].legs[0].steps.Count; cont++)
            {
                var distance = new Distance((string)test.routes[0].legs[0].steps[cont].distance.text, (int)test.routes[0].legs[0].steps[cont].distance.value);
                var duration = new Duration((string)test.routes[0].legs[0].steps[cont].duration.text, (int)test.routes[0].legs[0].steps[cont].duration.value);
                var startLocation = new Location((double)test.routes[0].legs[0].steps[cont].start_location.lat, (double)test.routes[0].legs[0].steps[cont].start_location.lng);
                var endLocation = new Location((double)test.routes[0].legs[0].steps[cont].end_location.lat, (double)test.routes[0].legs[0].steps[cont].end_location.lng);

                var step = new Step(distance, duration, startLocation, endLocation, 
                    (string)test.routes[0].legs[0].steps[cont].html_instructions, (string)test.routes[0].legs[0].steps[cont].maneuver, (string)test.routes[0].legs[0].steps[cont].travel_mode);
                
                route.Steps.Add(step);
            }
            
            var json = JsonConvert.SerializeObject(route, Formatting.Indented);
            Console.WriteLine(json);

        }
    }
}