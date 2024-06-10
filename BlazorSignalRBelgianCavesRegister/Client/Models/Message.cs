using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorSignalRBelgianCavesRegister.Client.Models
{
    public class Message
    {
        public int Chat_Id { get; set; }
        [Required]
        [DisplayName("Message : ")]
        public string? Content { get; set; }
        [Required]
        [DisplayName("Author : ")]
        public string? Author { get; set; }
        [Required]
        [DisplayName("Site Id : ")]
        public int Site_Id { get; set; }
    }
}
