namespace MovieFinder.Client.Models.Movies
{
    public class MovieVideo
    {
        public int Id { get; set; }

        public List<MovieVideos> Results { get; set; } = new();

        public class MovieVideos
        {
            public string? Site { get; set; }
            public string? Key { get; set; }
            public string? Type { get; set; }
        }
    }
}
