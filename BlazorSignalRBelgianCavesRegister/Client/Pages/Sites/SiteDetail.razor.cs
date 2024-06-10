using BlazorSignalRBelgianCavesRegister.Client.Models;
using BlazorSignalRBelgianCavesRegister.Client.Pages.LambdaDatas;
using BlazorSignalRBelgianCavesRegister.Client.Pages.NOwners;
using BlazorSignalRBelgianCavesRegister.Client.Pages.ScientificDatas;
using BlazorSignalRBelgianCavesRegister.Client.Pages.Bibliographies;
using BlazorSignalRBelgianCavesRegister.Client.Pages.Chats;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorSignalRBelgianCavesRegister.Client.Pages.WeatherForecasts;

namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Sites
{
    public partial class SiteDetail
    {
    #nullable disable
        [Inject]
        public HttpClient Client { get; set; }
        public LambdaDataView LambdaDataView { get; set; }
        public ChatView ChatView { get; set; }
        public NOwnerView NowerView { get; set; }
        public ScientificDataView ScientificDataView { get; set; }
        public BibliographyView BibliographyView { get; set; }
        public WeatherForecastView WeatherForecastView { get; set; }
        public SiteModel CurrentSite { get; set; }
        public List<LambdaDataModel> FilteredLambdaDataList { get; set; } = new List<LambdaDataModel>();
        public List<NOwnerModel> FilteredNOwnerList { get; set; } = new List<NOwnerModel>();
        public List<ScientificDataModel> FilteredScientificDataList { get; set; } = new List<ScientificDataModel>();
        public List<BibliographyModel> FilteredBibliographyList { get; set; } = new List<BibliographyModel>();
        public List<Message> FilteredChatList { get; set; } = new List<Message>();
        [Parameter]
        public int Site_Id { get; set; }
        protected override async Task OnParametersSetAsync()
        {
            await GetSite();
        }
        private  void LambdaDataInfo()
        {
            if (CurrentSite is not null)
            {
                FilteredLambdaDataList = LambdaDataView.FilterLambdaDataBySiteId(CurrentSite.Site_Id);
            }
        }
        private void ScientificDataInfo()
        {
            if (CurrentSite is not null)
            {
                FilteredScientificDataList = ScientificDataView.FilterScientificDataBySiteId(CurrentSite.Site_Id);
            }
        }
        private void NOwnerInfo()
        {
            if (CurrentSite is not null)
            {
                FilteredNOwnerList = NowerView.FilterNOwnerBySiteId(CurrentSite.Site_Id);
            }
        }
        private void BibliographyInfo()
        {
            if (CurrentSite is not null)
            {
                FilteredBibliographyList = BibliographyView.FilterBibliographyBySiteId(CurrentSite.Site_Id);
            }
        }
        private void ChatInfo()
        {
            if (CurrentSite is not null)
            {
                //FilteredChatList = FilterChatDataBySiteId(CurrentSite.Site_Id);
            }
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
