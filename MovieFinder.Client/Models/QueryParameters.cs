namespace MovieFinder.Client.Models
{
    public class QueryParameters
    {
        public List<int> GenreIds { get; set; }
        public double MinimumRating { get; set; } = 5;
        public int ReleaseYear { get; set; }
    }
}
