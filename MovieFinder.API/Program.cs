using MovieFinder.API.Services;
using MovieFinder.API.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<ITMDBService, TMDBService>();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:7090")
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var app = builder.Build();

app.UseCors(MyAllowSpecificOrigins);

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


