using System.Net.Http.Json;
using MovieFinder.Client.Models;

namespace MovieFinder.Client.Services
{
    public interface ITMDBService
    {
        Task<List<Movie>> GetTrendingMoviesAsync();
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

        public async Task<List<Movie>> GetTrendingMoviesAsync()
        {
            var url = $"https://api.themoviedb.org/3/trending/movie/day?api_key={_apiKey}";
            var response = await _httpClient.GetFromJsonAsync<SearchResult>(url);

            return response?.Results ?? new List<Movie>();
        }
    }
}
