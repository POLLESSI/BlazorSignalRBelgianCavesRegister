using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.NPersons
{
    public partial class NPersonCreate
    {
        [Inject]
        public HttpClient Client { get; set; }
        public NPersonModel npersonform { get; set; }
        protected override void OnInitialized()
        {
            npersonform = new NPersonModel();
        }
        public async Task submit()
        {
            string json = JsonConvert.SerializeObject(npersonform);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = await Client.PostAsync("nperson", content))
            {
                if (message.IsSuccessStatusCode) { Console.WriteLine(message.Content); }
            }
        }
    }
}
