using System.Net.Http.Json;
using MovieFinder.Client.Models;
using static System.Net.WebRequestMethods;

namespace MovieFinder.Client.Services
{
    public interface ITMDBService
    {
        Task<List<Movie>> GetTrendingMoviesAsync();
        Task<List<Genre>> GetGenresAsync();
        Task<List<Movie>> GetMovieByGenreAsync(List<int> genreIds);
    }
    public class TMDBService : ITMDBService
    {
        private HttpClient _httpClient { get; }
        private readonly string _apiKey;

        public TMDBService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _apiKey = config["TMDB:ApiKey"];
        }

        //Retrieves all the trending movies
        public async Task<List<Movie>> GetTrendingMoviesAsync()
        {
            var url = $"https://api.themoviedb.org/3/trending/movie/day?api_key={_apiKey}";
            var response = await _httpClient.GetFromJsonAsync<SearchResult>(url);
            return response?.Results ?? new List<Movie>();
        }

        //Retrieves all movie genres
        public async Task<List<Genre>> GetGenresAsync()
        {
            var url = $"https://api.themoviedb.org/3/genre/movie/list?api_key={_apiKey}";
            var response = await _httpClient.GetFromJsonAsync<GenreResult>(url);
            return response?.Genres ?? new List<Genre>();
        }

        //Retrieves all the movies with the selected genres
        public async Task<List<Movie>> GetMovieByGenreAsync(List<int> genreIds)
        {
            var genresParameters = string.Join(",", genreIds);
            var url = $"https://api.themoviedb.org/3/discover/movie?api_key={_apiKey}&with_genres={genresParameters}";
            var response = await _httpClient.GetFromJsonAsync<SearchResult>(url);
            return response?.Results ?? new List<Movie>();
        }
    }
}
