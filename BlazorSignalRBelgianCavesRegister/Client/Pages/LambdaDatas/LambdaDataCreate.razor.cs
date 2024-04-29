using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.LambdaDatas
{
    public partial class LambdaDataCreate
    {
        [Inject]
        public HttpClient Client { get; set; }
        public LambdaDataModel lambdaDataform { get; set; }
        protected override void OnInitialized()
        {
            lambdaDataform = new LambdaDataModel();
        }
        public async Task submit()
        {
            string json = JsonConvert.SerializeObject(lambdaDataform);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = await Client.PostAsync("lambdadata", content))
            {
                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine(message.Content);
                }
            }
        }
    }
}
