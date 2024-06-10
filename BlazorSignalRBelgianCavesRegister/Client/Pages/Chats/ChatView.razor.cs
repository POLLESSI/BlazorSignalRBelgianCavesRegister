using BlazorSignalRBelgianCavesRegister.Client.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Chats
{
    public partial class ChatView
    {
    #nullable disable
        [Inject]
        public HttpClient Client { get; set; }
        public HubConnection hubConnection { get; set; }
        public List<Message> ChatList { get; set; }
        public List<Message> FilteredChatList { get; set; }
        public int SelectedChatId { get; set; }
        protected override async Task OnInitializedAsync()
        {
            ChatList = new List<Message>();
            FilteredChatList = new List<Message>();
            await GetChat();

            hubConnection = new HubConnectionBuilder().WithUrl(new Uri("https://localhost:7044/chathub")).Build();
            hubConnection.On("notifynewchat", async () =>
            {
                await GetChat();
                StateHasChanged();
            });
            await hubConnection.StartAsync();
        }
        private void ClickInfo(int chat_Id)
        {
            SelectedChatId = chat_Id;
        }
        public async Task GetChat()
        {
            using (HttpResponseMessage message = await Client.GetAsync("chat"))
            {
                if (message.IsSuccessStatusCode)
                {
                    string json = await message.Content.ReadAsStringAsync();
                    ChatList = JsonConvert.DeserializeObject<List<Message>>(json);
                }
            }
        }
        public List<Message> FilterChatDataBySiteId(int site_Id)
        {
            return ChatList = ChatList.Where(ch => ch.Site_Id == site_Id).ToList();
        }
    }
}
