namespace MovieFinder.Client.Models.Movies
{
    public class MovieVideo
    {
        public int Id { get; set; }

        public List<MovieVideoItem> Results { get; set; } = new();

        public class MovieVideoItem
        {
            public string? Site { get; set; }
            public string? Key { get; set; }
            public string? Type { get; set; }
        }
    }
}
