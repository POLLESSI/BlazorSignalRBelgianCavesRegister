namespace BlazorSignalRBelgianCavesRegister.Client.Models
{
    public class BibliographyModel
    {
    #nullable disable
        public int Bibliography_Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }
        public string? DataType { get; set; }
        public int Site_Id { get; set; } 
        public string? Detail { get; set; }
    }
}
