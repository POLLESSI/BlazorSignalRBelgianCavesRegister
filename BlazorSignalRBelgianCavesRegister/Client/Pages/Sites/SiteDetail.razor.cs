using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Sites
{
    public partial class SiteDetail
    {
        [Inject]
        public HttpClient Client { get; set; }
        public SiteModel CurrentSite { get; set; }
        [Parameter]
        public int Site_Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetSite();
        }
        private async Task GetSite()
        {
            using (HttpResponseMessage message = await Client.GetAsync("site/"+ Site_Id))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentSite = JsonConvert.DeserializeObject<SiteModel>(json);
                }
            }
        }
    }
}
