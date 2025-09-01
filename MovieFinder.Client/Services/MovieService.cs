using MovieFinder.Shared.Models.Actors;
using MovieFinder.Shared.Models.Common;
using MovieFinder.Shared.Models.Movies;
using MudBlazor;
using System.Net.Http.Json;

namespace MovieFinder.Client.Services
{
    public interface IMovieService
    {
        Task<ServiceResult<MovieDetail>> GetMovieDetailsAsync(int movieId);
        Task<MovieImage?> GetMovieImagesAsync(int movieId);
        Task<List<MovieVideoItem>> GetYoutubeTrailersAsync(int movieId);
        Task<List<Genre>> GetGenresAsync();
        Task<List<Movie>> GetSearchedMoviesAsync(string searchWord);
        Task<SearchResult?> GetSimilarMoviesAsync(int movieId, int page);
        Task<ServiceResult<SearchResult?>> GetFilteredMoviesAsync(FilterParameter parameter);
        Task<Actor?> GetActorsForMovieAsync(int movieId);
        Task<ServiceResult<ActorDetail?>> GetActorDetailsAsync(int actorId);
    }

    public class MovieService : IMovieService
    {

        private readonly HttpClient _httpClient;

        public MovieService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        // Fetches all details about a specific movie
        public async Task<ServiceResult<MovieDetail>> GetMovieDetailsAsync(int movieId)
        {
            try
            {
                var movie = await _httpClient.GetFromJsonAsync<MovieDetail?>($"movies/{movieId}");
                return new ServiceResult<MovieDetail>
                {
                    Success = movie != null,
                    Data = movie
                };
            }

            catch
            {
                return new ServiceResult<MovieDetail> { Success = false };
            }
        }

        // Fetches all images for a movie
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

        // Fetches all YouTube trailers for a movie
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

        // Fetches all genres
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

        // Fetches movies by keywords
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

        // Fetches similar movies
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

        // Fetches filtered movies and wraps the result in a ServiceResult indicating success or failure
        public async Task<ServiceResult<SearchResult?>> GetFilteredMoviesAsync(FilterParameter parameter)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("movies/filter", parameter);

                var result = await response.Content.ReadFromJsonAsync<SearchResult?>();
                return new ServiceResult<SearchResult?>
                {
                    Success = result != null,
                    Data = result
                };
            }
            catch
            {
                return new ServiceResult<SearchResult?>
                {
                    Success = false,
                    Data = null
                };
            }
        }


        // Fetches list of actors in a movie
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

        // Fetches details for a specific actor and wraps the result in a ServiceResult indicating success or failure
        public async Task<ServiceResult<ActorDetail?>> GetActorDetailsAsync(int actorId)
        {
            try
            {
                var data = await _httpClient.GetFromJsonAsync<ActorDetail?>($"actors/{actorId}");
                return new ServiceResult<ActorDetail?>
                {
                    Success = data != null,
                    Data = data
                };
            }
            catch
            {
                return new ServiceResult<ActorDetail?>
                {
                    Success = false,
                    Data = null
                };
            }
        }
    }
}

