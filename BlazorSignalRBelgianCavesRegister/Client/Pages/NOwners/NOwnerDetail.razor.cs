using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.NOwners
{
    public partial class NOwnerDetail
    {
        [Inject]
        #nullable disable
        public HttpClient Client { get; set; }
        public NOwnerModel CurrentNOwner { get; set; }
        [Parameter]
        public int NOwner_Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetNOwner();
        }
        private async Task GetNOwner()
        {
            using (HttpResponseMessage message = await Client.GetAsync("nowner/"+ NOwner_Id))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentNOwner = JsonConvert.DeserializeObject<NOwnerModel>(json);
                }
            }
        }
    }
}
