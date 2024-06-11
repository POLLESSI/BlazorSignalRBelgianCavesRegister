using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.NOwners
{
    public partial class NOwnerCreate
    {
    #nullable disable
        [Inject]
        public HttpClient Client { get; set; }
        public NOwnerModel nownerform { get; set; }
        protected override void OnInitialized()
        {
            nownerform = new NOwnerModel();
        }
        public async Task submit()
        {
            string json = JsonConvert.SerializeObject(nownerform);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = await Client.PostAsync("nowner", content))
            {
                if (message.IsSuccessStatusCode) { Console.WriteLine(message.Content); }
            }
        }
    }
}
