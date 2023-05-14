namespace DemoAPI.Models.RegionDTO
{
    public class RegionsDTO
    {
        public Guid Id { get; set; }

        public string RegionName { get; set; }

        public string RegionCode { get; set; }

        public string? RegionImageURL { get; set; }
    }
}
