using System.Globalization;
using System.Net.Http.Json;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;
using MovieFinder.Client.Models;
using static System.Net.WebRequestMethods;

namespace MovieFinder.Client.Services
{
    public interface ITMDBService
    {
        Task<List<Movie>> GetTrendingMoviesAsync();
        Task<List<Genre>> GetGenresAsync();
        Task<List<Movie>> GetFilteredMoviesAsync(QueryParameters parameters);
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

        public async Task<List<Movie>> GetFilteredMoviesAsync(QueryParameters parameters)
        {
            var baseUrl = $"https://api.themoviedb.org/3/discover/movie";

            var queryParameters = new Dictionary<string, string>
            {
                ["api_key"] = _apiKey,
            };

            if (parameters.ReleaseYear != 0)
            {
                queryParameters["primary_release_year"] = parameters.ReleaseYear.ToString();
            }

            if (parameters.GenreIds != null && parameters.GenreIds.Count() > 0)
            {
                queryParameters["with_genres"] = string.Join(",", parameters.GenreIds);
            }

            queryParameters["vote_average.gte"] = parameters.MinimumRating.ToString(CultureInfo.InvariantCulture);

            var url = QueryHelpers.AddQueryString(baseUrl, queryParameters);

            var response = await _httpClient.GetFromJsonAsync<SearchResult>(url);

            return response?.Results ?? new List<Movie>();
        }
    }
}
