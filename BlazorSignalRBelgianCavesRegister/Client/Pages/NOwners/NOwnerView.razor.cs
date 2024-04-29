using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.NOwners
{
    public partial class NOwnerView
    {
        [Inject]
        public HttpClient Client { get; set; }
        public HubConnection hubConnection { get; set; }
        public List<NOwnerModel> NOwnerList { get; set; }
        public int SelectedOwnerId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            NOwnerList = new List<NOwnerModel>();
            await GetNOwner();
            hubConnection = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7044/nownerhub")).Build();
            hubConnection.On("notifynewnowner", async () =>
            {
                await GetNOwner();
                StateHasChanged();
            });
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
    }
}
