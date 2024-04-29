using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.WeatherForecasts
{
    public partial class WeatherForecastCreate
    {
        [Inject]
        public HttpClient Client { get; set; }
        public WeatherForecastModel weatherforecastform {  get; set; }

        protected async Task submit()
        {
            string json = JsonConvert.SerializeObject(weatherforecastform);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = await Client.PostAsync("weatherforecast", content))
            {
                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine(message.Content);
                }
            }
        }
    }
}
