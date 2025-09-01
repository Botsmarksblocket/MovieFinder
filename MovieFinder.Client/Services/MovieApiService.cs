using System.Net.Http.Json;
using MovieFinder.Shared.Models.Movies;
using MovieFinder.Shared.Models.Actors;
using MovieFinder.Shared.Models.Common;

namespace MovieFinder.Client.Services
{
    public interface IMovieApiService
    {
        Task<MovieDetail?> GetMovieDetailsAsync(int movieId);
        Task<MovieImage?> GetMovieImagesAsync(int movieId);
        Task<List<MovieVideoItem>> GetYoutubeTrailersAsync(int movieId);
        Task<List<Genre>> GetGenresAsync();
        Task<List<Movie>> GetSearchedMoviesAsync(string searchWord);
        Task<SearchResult?> GetSimilarMoviesAsync(int movieId, int page);
        Task<SearchResult?> GetFilteredMoviesAsync(FilterParameter parameter);
        Task<Actor?> GetActorsForMovieAsync(int movieId);
        Task<ActorDetail?> GetActorDetailsAsync(int actorId);
    }

    public class MovieApiService : IMovieApiService
    {

        private readonly HttpClient _httpClient;

        public MovieApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // Get details about a specific movie
        public async Task<MovieDetail?> GetMovieDetailsAsync(int movieId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<MovieDetail?>($"movies/{movieId}");
            }
            catch
            {
                return null;
            }
        }

        // Get all images for a movie
        public async Task<MovieImage?> GetMovieImagesAsync(int movieId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<MovieImage?>($"movies/{movieId}/images");
            }
            catch
            {
                return null;
            }
        }

        // Get all YouTube trailers for a movie
        public async Task<List<MovieVideoItem>> GetYoutubeTrailersAsync(int movieId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<MovieVideoItem>>($"movies/{movieId}/trailers")
                       ?? new List<MovieVideoItem>();
            }
            catch
            {
                return new List<MovieVideoItem>();
            }
        }

        // Get all genres
        public async Task<List<Genre>> GetGenresAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Genre>>("genres")
                       ?? new List<Genre>();
            }
            catch
            {
                return new List<Genre>();
            }
        }

        // Search for movies by keyword
        public async Task<List<Movie>> GetSearchedMoviesAsync(string searchWord)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<List<Movie>>($"movies/search/?query={searchWord}")
                       ?? new List<Movie>();
            }
            catch
            {
                return new List<Movie>();
            }
        }

        // Get similar movies
        public async Task<SearchResult?> GetSimilarMoviesAsync(int movieId, int page)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<SearchResult?>($"movies/{movieId}/similar?page={page}");
            }
            catch
            {
                return null;
            }
        }

        // Get filtered movies (POST request)
        public async Task<SearchResult?> GetFilteredMoviesAsync(FilterParameter parameter)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("movies/filter", parameter);
                return await response.Content.ReadFromJsonAsync<SearchResult?>();
            }
            catch
            {
                return null;
            }
        }

        // Get list of actors in a movie
        public async Task<Actor?> GetActorsForMovieAsync(int movieId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<Actor?>($"actors/movie/{movieId}");
            }
            catch
            {
                return null;
            }
        }

        // Get details about a specific actor
        public async Task<ActorDetail?> GetActorDetailsAsync(int actorId)
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<ActorDetail?>($"actors/{actorId}");
            }
            catch
            {
                return null;
            }
        }
    }
}

