using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.NOwners
{
    public partial class NOwnerView
    {
    #nullable disable
        [Inject]
        public HttpClient Client { get; set; }
        public HubConnection hubConnection { get; set; }
        public List<NOwnerModel> NOwnerList { get; set; }
        public List<NOwnerModel> FilteredNOwnerList { get; set; }
        public int SelectedOwnerId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            NOwnerList = new List<NOwnerModel>();
            FilteredNOwnerList = new List<NOwnerModel>();
            await GetNOwner();

            hubConnection = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7044/nownerhub")).Build();
            hubConnection.On("notifynewnowner", async () =>
            {
                await GetNOwner();
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }
        private void ClickInfo(int nOwner_Id)
        {
            SelectedOwnerId = nOwner_Id;
        }
        private async Task GetNOwner()
        {
            using (HttpResponseMessage message = await Client.GetAsync("nowner"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    NOwnerList = JsonConvert.DeserializeObject<List<NOwnerModel>>(json);
                }
            }
        }
        public List<NOwnerModel>FilterNOwnerBySiteId(int site_Id)
        {
            return NOwnerList.Where(no => no.Site_Id == site_Id).ToList();
        }
    }
}
