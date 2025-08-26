using MovieFinder.API.Services;
using MovieFinder.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ITMDBService, TMDBService>();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{    
    app.MapOpenApi();
    app.UseSwagger();          
    app.UseSwaggerUI();        
}

app.RegisterMovieEndpoints();
app.RegisterActorEndpoints();
app.RegisterGenreEndpoints();

app.UseHttpsRedirection();

app.Run();


