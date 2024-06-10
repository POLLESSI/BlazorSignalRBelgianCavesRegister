using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Text;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Chats
{
    public partial class ChatCreate
    {
        [Inject]
        #nullable disable
        public HttpClient Client { get; set; }
        public Message chatForm { get; set; }
        protected override void OnInitialized()
        {
            chatForm = new Message();
        }
        public async Task submit()
        {
            string json = JsonConvert.SerializeObject(chatForm);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            using (HttpResponseMessage message = await Client.PostAsync("chat", content))
            {
                {
                    if (!message.IsSuccessStatusCode) { Console.WriteLine(message.Content); }
                }
            }
        }
    }
}
