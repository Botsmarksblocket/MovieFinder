using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;
using MovieFinder.API.Endpoints;
using MovieFinder.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ITMDBService, TMDBService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
    {
        var clientId = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        return RateLimitPartition.GetFixedWindowLimiter(
            partitionKey: clientId,
            factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 30,
                Window = TimeSpan.FromSeconds(30),
                QueueLimit = 2
            });
    });

    options.RejectionStatusCode = 429;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(
                               "https://moviefinderapp.com",
                               "https://www.moviefinderapp.com",
                               "https://localhost:7090")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var movieDbApiKey = Environment.GetEnvironmentVariable("MOVIEDB_API_KEY");
if (!string.IsNullOrWhiteSpace(movieDbApiKey))
{
    builder.Configuration["TMDB:ApiKey"] = movieDbApiKey;
}


// Configure HttpClient for TMDBService
builder.Services.AddHttpClient<ITMDBService, TMDBService>((sp, client) =>
{
    client.BaseAddress = new Uri("https://api.themoviedb.org/3/");
});

var app = builder.Build();

app.UseRateLimiter();
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/ping", () => Results.Ok("pong"))
   .AllowAnonymous();

app.RegisterMovieEndpoints();
app.RegisterActorEndpoints();
app.RegisterGenreEndpoints();

app.UseHttpsRedirection();

app.Run();