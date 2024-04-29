using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlazorSignalRBelgianCavesRegister.Client.Models
{
    public class Question
    {
        [Required]
        [MaxLength(256)]
        [DisplayName("Enonce : ")]
        public string? Enonce { get; set; }
        public bool Response { get; set; }
    }
}
