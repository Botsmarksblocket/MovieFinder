using MovieFinder.Shared.Models.Common;
using MovieFinder.API.Services;

namespace MovieFinder.API.Endpoints
{
    public static class MovieEndpoints
    {
        public static void RegisterMovieEndpoints(this IEndpointRouteBuilder routes)
        {
            var movies = routes.MapGroup("/api/v1/movies");

            movies.MapGet("/{id:int}", async (int id, ITMDBService tmdb) =>
                await tmdb.GetMovieDetailsAsync(id));

            movies.MapGet("/{id:int}/images", async (int id, ITMDBService tmdb) =>
                await tmdb.GetMovieImagesAsync(id));

            movies.MapGet("/{id:int}/trailers", async (int id, ITMDBService tmdb) =>
                await tmdb.GetYoutubeTrailersAsync(id));

            movies.MapGet("/search", async (string query, ITMDBService tmdb) =>
                await tmdb.GetSearchedMoviesAsync(query));

            movies.MapGet("/{id:int}/similar", async (int id, int page, ITMDBService tmdb) =>
                await tmdb.GetSimilarMoviesAsync(id, page));

            movies.MapPost("/filter", async (FilterParameter filter, ITMDBService tmdb) =>
                await tmdb.GetFilteredMoviesAsync(filter));
        }
    }
}
