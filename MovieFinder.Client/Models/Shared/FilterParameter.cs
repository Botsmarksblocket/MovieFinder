namespace MovieFinder.Client.Models.Shared
{
    public class FilterParameter
    {
        public List<int> GenreIds { get; set; }
        public double MinimumRating { get; set; } = 0;
        public int ReleaseYear { get; set; }
        public string SortBy { get; set; } = "None";
        public int Page { get; set; } 
    }
}
