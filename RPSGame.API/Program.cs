using RPSGame.Application.Services;
using RPSGame.Domain.Entities;
using RPSGame.Domain.Interfaces;
using RPSGame.Domain.Rules;
using RPSGame.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5287") // Replace with your Blazor app's URL
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// builder.Services.AddScoped<IPlayer, Player>(sp => new Player("Player")); // Default Player
// builder.Services.AddScoped<IPlayer, Player>(sp => new Player("Computer")); // Default Computer
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddScoped<IMoveEvaluator, DefaultMoveEvaluator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}


app.UseHttpsRedirection();
app.UseCors(); // Add this line to enable CORS
app.UseAuthorization();
app.MapControllers();

app.Run();
