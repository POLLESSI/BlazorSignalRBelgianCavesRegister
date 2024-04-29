using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.NUsers
{
    public partial class NUserDetail
    {
        [Inject]
        public HttpClient Client { get; set; }
        public NUserModel CurrentNUser { get; set; }
        [Parameter]
        public int NUser_Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetNUser();
        }
        private async Task GetNUser()
        {
            using (HttpResponseMessage message = await Client.GetAsync("nuser/"+ NUser_Id))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentNUser = JsonConvert.DeserializeObject<NUserModel>(json);
                }
            }
        }
    }
}
