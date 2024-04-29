using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Microsoft.AspNetCore.SignalR.Client;
using System.Text.Json.Serialization;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.NPersons
{
    public partial class NPersonView
    {
        [Inject]
        public HttpClient Client { get; set; }
        public HubConnection hubConnection { get; set; }
        public List<NPersonModel> NPersonList { get; set; }
        public int SelectedNPersonId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            NPersonList = new List<NPersonModel>();
            await GetNPerson();
            hubConnection = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7044/npersonhub")).Build();
            hubConnection.On("notifynewnperson", async () =>
            {
                await GetNPerson();
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }
        private void ClickInfo(int nPerson_Id)
        {
            SelectedNPersonId = nPerson_Id;
        }
        private async Task GetNPerson()
        {
            using (HttpResponseMessage message = await Client.GetAsync("nPerson"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    NPersonList = JsonConvert.DeserializeObject<List<NPersonModel>>(json);
                }
            }
        }
    }
}
