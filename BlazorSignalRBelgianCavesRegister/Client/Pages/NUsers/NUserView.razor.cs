using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.NUsers
{
    public partial class NUserView
    {
        [Inject]
        public HttpClient Client { get; set; }
        public HubConnection hubConnection { get; set; }
        public List<NUserModel> NUserList { get; set; }
        public int SelectedNUserId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            NUserList = new List<NUserModel>();
            await GetNUser();

            hubConnection = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7044/nuserhub")).Build();
            hubConnection.On("notifynewnuser", async () =>
            {
                await GetNUser();
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }

        private void ClickInfo(int nUser_Id)
        {
            SelectedNUserId = nUser_Id;
        }
        private async Task GetNUser()
        {
            using (HttpResponseMessage message = await Client.GetAsync("nuser"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    NUserList = JsonConvert.DeserializeObject<List<NUserModel>>(json);
                }
            }
        }
    }
}
