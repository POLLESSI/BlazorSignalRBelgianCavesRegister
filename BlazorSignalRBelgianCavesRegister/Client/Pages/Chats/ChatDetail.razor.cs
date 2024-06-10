using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Chats
{
    public partial class ChatDetail
    {
        [Inject]
        public HttpClient Client { get; set; }
        public Message CurrentChat { get; set; }
        [Parameter]
        public int Chat_Id { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            await GetChat();
        }
        private async Task GetChat()
        {
            using (HttpResponseMessage message = await Client.GetAsync("chat/" + Chat_Id))
            {
                if (message.IsSuccessStatusCode) 
                {
                    string json = await message.Content.ReadAsStringAsync();
                    CurrentChat = JsonConvert.DeserializeObject<Message>(json);
                }
            }
        }
    }
}
