using System;
using Example.Client.App.Services;

namespace Example.Client.App
{
    class Program
    {
        static void Main(string[] args)
        {
            RouteService service = new RouteService();

            service.RunAsync().GetAwaiter().GetResult();
        }
    }
}
