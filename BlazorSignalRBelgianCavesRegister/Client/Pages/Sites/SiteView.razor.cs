using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Sites
{
    public partial class SiteView
    {
        [Inject]
        public HttpClient Client { get; set; }
        public HubConnection hubConnection { get; set; }
        public List<SiteModel> SiteList { get; set; }
        public int SelectedSiteId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            SiteList = new List<SiteModel>();
            await GetSite();

            hubConnection = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7044/sitehub")).Build();
            hubConnection.On("notifynewsite", async () =>
            {
                await GetSite();
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }
        private void ClickInfo(int site_Id)
        {
            SelectedSiteId = site_Id;
        }
        private async Task GetSite()
        {
            using (HttpResponseMessage message = await Client.GetAsync("site"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    SiteList = JsonConvert.DeserializeObject<List<SiteModel>>(json);
                }
            }
        }
    }
}
