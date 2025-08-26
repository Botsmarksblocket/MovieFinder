using MovieFinder.API.Services;

namespace MovieFinder.API.Endpoints
{
    public static class GenresEndpoints
    {
        public static void RegisterGenreEndpoints(this IEndpointRouteBuilder routes)
        {
            var genres = routes.MapGroup("/api/v1/genres");

            genres.MapGet("/", async (ITMDBService tmdb) =>
                await tmdb.GetGenresAsync());
        }
    }
}