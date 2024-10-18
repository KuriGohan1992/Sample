namespace Sample.Models.Entities
{
    public class Movie
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public float Rating { get; set; }
        public int YearReleased { get; set; }
        public required string Director { get; set; }
    }
}
