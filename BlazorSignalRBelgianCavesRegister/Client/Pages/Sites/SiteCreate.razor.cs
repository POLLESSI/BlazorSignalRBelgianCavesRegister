using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Sites
{
    public partial class SiteCreate
    {
        [Inject]
        public HttpClient Client { get; set; }
        public SiteModel siteform { get; set; }
        protected override void OnInitialized()
        {
            siteform = new SiteModel();
        }
        public async Task submit()
        {
            string json = JsonConvert.SerializeObject(siteform);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = await Client.PostAsync("site", content))
            {
                if (message.IsSuccessStatusCode) { Console.WriteLine(message.Content); }
            }
        }
    }
}
