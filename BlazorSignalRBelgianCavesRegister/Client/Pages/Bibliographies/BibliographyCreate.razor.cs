using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Bibliographies
{
    public partial class BibliographyCreate
    {
        [Inject]

        public HttpClient Client { get; set; }
        public BibliographyModel bibliographyform { get; set; }

        protected override void OnInitialized()
        {
            bibliographyform = new BibliographyModel();
        }

        public async Task submit()
        {
            string json = JsonConvert.SerializeObject(bibliographyform);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = await Client.PostAsync("bibliography", content))
            {
                if (!message.IsSuccessStatusCode) { Console.WriteLine(message.Content); }
            }
        }
    }
}
