using System.Globalization;
using System.Net.Http.Json;
using System.Web;
using Microsoft.AspNetCore.WebUtilities;
using MovieFinder.Client.Models;
using static System.Net.WebRequestMethods;

namespace MovieFinder.Client.Services
{
    //Service which calls TMDB API to retrieve movie genres, list of filtered movies and specific movies

    public interface ITMDBService
    {
        Task<MovieDetail> GetMovieDetailsAsync(int movieId);
        Task<List<Genre>> GetGenresAsync();
        Task<List<Movie>> GetSearchedMoviesAsync(string searchWord);
        Task<SearchResult> GetFilteredMoviesAsync(FilterParameter parameters);
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

        //Returns details about a specific movie
        public async Task <MovieDetail> GetMovieDetailsAsync(int movieId)
        {
            var baseUrl = $"https://api.themoviedb.org/3/movie/{movieId}";

            var queryParameters = new Dictionary<string, string>
            {
                ["api_key"] = _apiKey,
            };

            var url = QueryHelpers.AddQueryString(baseUrl, queryParameters);
            var response = await _httpClient.GetFromJsonAsync<MovieDetail>(url);
            return response;
        }

        //Retrieves all movie genres
        public async Task<List<Genre>> GetGenresAsync()
        {
            var url = $"https://api.themoviedb.org/3/genre/movie/list?api_key={_apiKey}";
            var response = await _httpClient.GetFromJsonAsync<GenreResult>(url);
            return response?.Genres ?? new List<Genre>();
        }

        //Retrieves specific movie which user searched for
        public async Task<List<Movie>> GetSearchedMoviesAsync(string searchWord)
        {
            var baseUrl = $"https://api.themoviedb.org/3/search/movie";

            var queryParameters = new Dictionary<string, string>
            {
                ["api_key"] = _apiKey,
                ["query"] = searchWord,
            };

            var url = QueryHelpers.AddQueryString(baseUrl, queryParameters);
            var response = await _httpClient.GetFromJsonAsync<SearchResult>(url);

            return response?.Results ?? new List<Movie>();
        }

        //Retrieves list of movies from TMDB based on provided filter parameters.
        public async Task<SearchResult> GetFilteredMoviesAsync(FilterParameter parameter)
        {
            var baseUrl = $"https://api.themoviedb.org/3/discover/movie";

            var queryParameters = new Dictionary<string, string>
            {
                ["api_key"] = _apiKey,
                ["vote_count.gte"] = "10",
                ["page"] = parameter.Page.ToString()
            };

            if (parameter.ReleaseYear != 0)
            {
                queryParameters["primary_release_year"] = parameter.ReleaseYear.ToString();
            }

            if (parameter.GenreIds != null && parameter.GenreIds.Count() > 0)
            {
                queryParameters["with_genres"] = string.Join(",", parameter.GenreIds);
            }

            if (!String.IsNullOrEmpty(parameter.SortBy))
            {
                queryParameters["sort_by"] = parameter.SortBy;
            }

            queryParameters["vote_average.gte"] = parameter.MinimumRating.ToString(CultureInfo.InvariantCulture);

            var url = QueryHelpers.AddQueryString(baseUrl, queryParameters);

            return await _httpClient.GetFromJsonAsync<SearchResult>(url)
                    ?? new SearchResult { Results = new List<Movie>() };
        }
    }
}
