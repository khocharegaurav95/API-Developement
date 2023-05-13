namespace DemoAPI.Models.Domain
{
    public class Region
    {
        public Guid Id { get; set;}

        public string RegionName { get; set;}

        public string RegionCode { get; set;}

        public string? RegionImageURL { get; set;}
    }
}
