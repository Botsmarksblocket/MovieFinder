using System.Net.Http.Json;
using MovieFinder.Client.Models;

namespace MovieFinder.Client.Services
{
    public class TMDBService
    {
        private HttpClient _httpClient { get; }
        private readonly string _apiKey = "";

        public TMDBService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetTrendingMoviesAsync(string timeWindow = "day")
        {
            var url = $"https://api.themoviedb.org/3/trending/movie/{timeWindow}?api_key={_apiKey}";
            var response = await _httpClient.GetFromJsonAsync<SearchResult>(url);

            return response?.Results ?? new List<Movie>();
        }
    }
}
