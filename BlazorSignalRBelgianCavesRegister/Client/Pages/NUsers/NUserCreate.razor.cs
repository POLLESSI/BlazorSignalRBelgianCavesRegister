using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.NUsers
{
    public partial class NUserCreate
    {
        [Inject]
        public HttpClient Client { get; set; }
        public NUserModel nuserform { get; set; }
        protected override void OnInitialized()
        {
            nuserform = new NUserModel();
        }
        public async Task submit()
        {
            string json = JsonConvert.SerializeObject(nuserform);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = await Client.PostAsync("nuser", content))
            {
                if (message.IsSuccessStatusCode) { Console.WriteLine(message.Content); }
            }
        }
    }
}
