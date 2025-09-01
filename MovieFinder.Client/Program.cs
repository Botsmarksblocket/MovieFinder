using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MovieFinder.Client;
using MovieFinder.Client.Services;
using MudBlazor;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMudServices();

var backendUrl = Environment.GetEnvironmentVariable("API_BASE_URL") ?? "https://localhost:7282/api/v1/"; 

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(backendUrl)
});

builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;
    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
    config.SnackbarConfiguration.VisibleStateDuration = 10000;
});

builder.Services.AddScoped<IMovieService, MovieService>();

await builder.Build().RunAsync();
