namespace BlazorSignalRBelgianCavesRegister.Client.Models
{
    public class SiteModel
    {
        public int Site_Id { get; set; }
        public string? Site_Name { get; set; }
        public string? Site_Description { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Length { get; set; }
        public string? Depth { get; set; }
        public string? AccessRequirement { get; set; }
        public string? PracticalInformation { get; set; }
        public int DonneesLambda_Id { get; set; }
        public int NOwner_Id { get; set; }
        public int ScientificData_Id { get; set; }
        public int Bibliography_Id { get; set; }
    }
}
