using Microsoft.AspNetCore.Components;
using BlazorSignalRBelgianCavesRegister.Client.Models;
namespace BlazorSignalRBelgianCavesRegister.Client.Pages.Shared
{
    public partial class QuestionComponent
    {
        [Parameter]
        public string? UserName { get; set; }
        [Parameter]
        public int QuestionNbr { get; set; }
        [Parameter]
        public Question Question { get; set; }
        [Parameter]
        public EventCallback<bool> ResponseEvent { get; set; }
        void Response(bool respone)
        {
            ResponseEvent.InvokeAsync(respone == Question.Response);
        }
    }
}
