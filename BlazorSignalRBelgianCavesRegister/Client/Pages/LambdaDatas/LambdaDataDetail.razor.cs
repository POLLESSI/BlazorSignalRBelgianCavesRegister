using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.LambdaDatas
{
    public partial class LambdaDataDetail
    {
    #nullable disable
        [Inject]
        public HttpClient Client { get; set; }
        public LambdaDataModel CurrentLambdaData { get; set; }
        [Parameter]
        public int DonneesLambda_Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetLambdaData();
        }
        

        private async Task GetLambdaData()
        {
            using (HttpResponseMessage message = await Client.GetAsync("lambdadata/"+ DonneesLambda_Id))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentLambdaData = JsonConvert.DeserializeObject<LambdaDataModel>(json);
                }
            }
        }
    }
}
