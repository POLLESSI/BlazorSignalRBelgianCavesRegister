using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.WeatherForecasts
{
    public partial class WeatherForecastDetail
    {
        [Inject]
        public HttpClient Client { get; set; }
        public WeatherForecastModel CurrentWeatherForecast { get; set; }

        [Parameter]
        public int WeatherForecast_Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await GetWeatherForecast();
        }
        private async Task GetWeatherForecast()
        {
            using (HttpResponseMessage message = await Client.GetAsync("weatherforecast/"+ WeatherForecast_Id))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentWeatherForecast = JsonConvert.DeserializeObject<WeatherForecastModel>(json);
                }
            }
        }
    }
}
