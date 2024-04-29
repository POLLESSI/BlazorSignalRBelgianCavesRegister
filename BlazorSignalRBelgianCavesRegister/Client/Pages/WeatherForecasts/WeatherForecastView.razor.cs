using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.WeatherForecasts
{
    public partial class WeatherForecastView
    {
        [Inject]
        public HttpClient Client { get; set; }
        public HubConnection hubConnection { get; set; }
        public List<WeatherForecastModel> weatherForecastList { get; set; }
        public int SelectedWeatherForecastId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            weatherForecastList = new List<WeatherForecastModel>();
            await GetWeatherForecast();
            hubConnection = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7044/weatherforecasthub")).Build();
            hubConnection.On("notifynewweatherforecast", async () =>
            {
                await GetWeatherForecast();
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }
        private void ClickInfo(int weatherForecast_Id)
        {
            SelectedWeatherForecastId = weatherForecast_Id;
        }
        private async Task GetWeatherForecast()
        {
            using (HttpResponseMessage message = await Client.GetAsync("weatherforecast"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    weatherForecastList = JsonConvert.DeserializeObject<List<WeatherForecastModel>>(json);
                }
            }
        }
    }
}
