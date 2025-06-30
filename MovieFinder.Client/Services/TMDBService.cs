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
        private readonly string _apiKey = "d5d8dd2a24bb984ea8c1b1f884b38f44";

        public TMDBService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetTrendingMoviesAsync()
        {
            var url = $"https://api.themoviedb.org/3/trending/movie/day?api_key={_apiKey}";
            var response = await _httpClient.GetFromJsonAsync<SearchResult>(url);

            return response?.Results ?? new List<Movie>();
        }
    }
}
