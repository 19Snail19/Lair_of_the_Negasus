using System.Text.Json;

using Negasus.API.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

var app = builder.Build();

string jsonFile = File.ReadAllText("./Resources/BestRun.json");

var jsonData = JsonSerializer.Deserialize<List<HighScore>>(
    jsonFile,
    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

    app.MapGet("/HighScore", () => jsonData)
    .WithName("GetScore")
    .Produces<List<HighScore>>(StatusCodes.Status200OK);

    app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();