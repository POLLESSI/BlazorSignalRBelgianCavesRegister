using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.LambdaDatas
{
    public partial class LambdaDataView
    {
    #nullable disable
        [Inject]
        public HttpClient Client { get; set; }
        public HubConnection hubConnection { get; set; }
        public List<LambdaDataModel> LambdaDataList { get; set; }
        public List<LambdaDataModel> FilteredLambdaDataList { get; set; }
        public int SelectedLambdaId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            LambdaDataList = new List<LambdaDataModel>();
            FilteredLambdaDataList = new List<LambdaDataModel>();
            await GetLambdaData();

            hubConnection = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7044/lambdadatahub")).Build();
            hubConnection.On("notifynewlambdadata", async () => { 
                await GetLambdaData();
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }
        private void ClickInfo(int donneesLambda_Id)
        {
            SelectedLambdaId = donneesLambda_Id;
        }
        public async Task GetLambdaData()
        {
            using (HttpResponseMessage message = await Client.GetAsync("lambdadata"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    LambdaDataList = JsonConvert.DeserializeObject<List<LambdaDataModel>>(json);
                }
            }
        }
        public List<LambdaDataModel> FilterLambdaDataBySiteId(int site_Id)
        {
            return LambdaDataList = LambdaDataList.Where(la => la.Site_Id == site_Id).ToList();
        }
    }
}
