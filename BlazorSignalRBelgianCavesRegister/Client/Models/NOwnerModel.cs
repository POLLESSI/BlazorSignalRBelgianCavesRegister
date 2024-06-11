namespace BlazorSignalRBelgianCavesRegister.Client.Models
{
    public class NOwnerModel
    {
    # nullable disable
        public int NOwner_Id { get; set; }
        public string? Status { get; set; }
        public string? Agreement { get; set; }

        public int NPerson_Id { get; set; }
        public int Site_Id { get; set; }
    }
}
