namespace MovieFinder.Client.Models
{
    public class QueryParameters
    {
        public List<int> SelectedGenreIds { get; set; }
        public double MinimumRating { get; set; } = 5;
    }
}
