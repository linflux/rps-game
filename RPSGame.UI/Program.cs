using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RPSGame.Application.Services;
using RPSGame.Domain.Interfaces;
using RPSGame.Domain.Entities;

using RPSGame.Infrastructure.Services;
using RPSGame.UI;
using RPSGame.UI.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IMoveEvaluator, DefaultMoveEvaluator>();
builder.Services.AddScoped<IGameService, GameService>();

// Configure HttpClient for the Web API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5231/api/") });

builder.Services.AddScoped<GameApiService>();

await builder.Build().RunAsync();
