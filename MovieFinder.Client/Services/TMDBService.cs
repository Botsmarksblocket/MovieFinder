using System.Net.Http.Json;
using MovieFinder.Shared.Models.Movies;
using MovieFinder.Shared.Models.Actors;
using MovieFinder.Shared.Models.Common;

namespace MovieFinder.Client.Services
{
    public interface ITMDBService
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

    public class TMDBService : ITMDBService
    {

        private readonly HttpClient _httpClient;

        public TMDBService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Get details about a specific movie
        public async Task<MovieDetail?> GetMovieDetailsAsync(int movieId) =>
            await _httpClient.GetFromJsonAsync<MovieDetail>($"movies/{movieId}");

        // Get all images for a movie
        public async Task<MovieImage?> GetMovieImagesAsync(int movieId) =>
            await _httpClient.GetFromJsonAsync<MovieImage>($"movies/{movieId}/images");

        // Get all YouTube trailers for a movie
        public async Task<List<MovieVideoItem>> GetYoutubeTrailersAsync(int movieId) =>
            await _httpClient.GetFromJsonAsync<List<MovieVideoItem>>($"movies/{movieId}/trailers")
            ?? new List<MovieVideoItem>();

        // Get all genres
        public async Task<List<Genre>> GetGenresAsync() =>
            await _httpClient.GetFromJsonAsync<List<Genre>>("genres")
            ?? new List<Genre>();

        // Search for movies by keyword
        public async Task<List<Movie>> GetSearchedMoviesAsync(string searchWord) =>
            await _httpClient.GetFromJsonAsync<List<Movie>>($"movies/search/{searchWord}")
            ?? new List<Movie>();

        // Get similar movies
        public async Task<SearchResult?> GetSimilarMoviesAsync(int movieId, int page) =>
            await _httpClient.GetFromJsonAsync<SearchResult>($"movies/{movieId}/similar?page={page}");

        // Get filtered movies (POST request)
        public async Task<SearchResult?> GetFilteredMoviesAsync(FilterParameter parameter)
        {
            var response = await _httpClient.PostAsJsonAsync("movies/filter", parameter);
            return await response.Content.ReadFromJsonAsync<SearchResult>();
        }

        // Get list of actors in a movie
        public async Task<Actor?> GetActorsForMovieAsync(int movieId) =>
            await _httpClient.GetFromJsonAsync<Actor>($"actors/movie/{movieId}");

        // Get details about a specific actor
        public async Task<ActorDetail?> GetActorDetailsAsync(int actorId) =>
            await _httpClient.GetFromJsonAsync<ActorDetail>($"actors/{actorId}");
    }
}

