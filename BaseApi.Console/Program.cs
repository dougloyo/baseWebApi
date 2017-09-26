using System.Net.Http;
using System.Diagnostics;
using Microsoft.Owin.Hosting;

namespace BaseApi.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseAddress = "http://localhost:9000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpCient and make a request to api/values 
                var client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/test").Result;

                System.Console.WriteLine(response);
                System.Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                // Open the default browser and load the 
                Process.Start(baseAddress);

                System.Console.WriteLine(response);
                System.Console.ReadLine();
            }
        }
    }
}
