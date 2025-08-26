using MovieFinder.API.Services;

namespace MovieFinder.API.Endpoints
{
    public static class ActorsEndpoints
    {
        public static void RegisterActorEndpoints(this IEndpointRouteBuilder routes)
        {
            var actors = routes.MapGroup("/api/v1/actors");

            actors.MapGet("/{id:int}", async (int id, ITMDBService tmdb) =>
                await tmdb.GetActorDetailsAsync(id));

            // Nested under movies for clarity
            routes.MapGet("/movies/{id:int}/actors", async (int id, ITMDBService tmdb) =>
                await tmdb.GetActorsForMovieAsync(id));
        }
    }
}