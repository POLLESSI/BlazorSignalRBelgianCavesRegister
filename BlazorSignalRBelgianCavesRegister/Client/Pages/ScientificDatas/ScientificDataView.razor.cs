using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.ScientificDatas
{
    public partial class ScientificDataView
    {
    #nullable disable
        [Inject]
        public HttpClient Client { get; set; }
        public HubConnection hubConnection { get; set; }
        public List<ScientificDataModel> ScientificDataList { get; set; }
        public int SelectedScientificId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ScientificDataList = new List<ScientificDataModel>();
            await GetScientificData();

            hubConnection = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7044/scientificdatahub")).Build();
            hubConnection.On("notifynewscientificdata", async () => { 
                await GetScientificData(); 
                StateHasChanged();
            });
        }
        private void ClickInfo(int scientififData_Id)
        {
            SelectedScientificId = scientififData_Id;
        }
        private async Task GetScientificData()
        {
            using (HttpResponseMessage message = await Client.GetAsync("scientificdata"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    ScientificDataList = JsonConvert.DeserializeObject<List<ScientificDataModel>>(json);
                }
            }
        }
        public List<ScientificDataModel> FilterScientificDataBySiteId(int site_Id)
        {
            return ScientificDataList = ScientificDataList.Where(sc => sc.Site_Id == site_Id).ToList();
        }
    }
}
