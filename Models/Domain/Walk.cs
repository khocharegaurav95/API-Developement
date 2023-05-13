namespace DemoAPI.Models.Domain
{
    public class Walk
    {
        public Guid Id { get; set; }
        public double LengthInKM { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Guid RegionID { get; set; }
        public Guid DifficultyID { get; set; }
        public string? WalkImageURL { get; set; }












        


    }
}
