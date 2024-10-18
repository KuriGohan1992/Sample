namespace SampleModels
{
    public class MovieModel
    {
        public class Movie
        {
            public int Id { get; set; }
            public required string Title { get; set; }
            public double Rating { get; set; }
            public int YearReleased { get; set; }
            public required string Director { get; set; }

        }
    }
    
}
