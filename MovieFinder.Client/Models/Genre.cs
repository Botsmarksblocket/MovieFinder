namespace MovieFinder.Client.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class GenreResult
    {
        public List<Genre> Genres { get; set; }
    }
}
