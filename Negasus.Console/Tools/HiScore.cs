namespace Negasus.Console;

using System;
using Negasus.Console.Tools;
using Negasus.Console.Models;
using System.Text.Json;

class HiScore
{
    public static async Task GetScore()
    {
        HttpClient client = new();
        client.BaseAddress = new Uri("http://localhost:5116");
        HttpResponseMessage response = await client.GetAsync("/HighScore");

        string jsonResponse = await response.Content.ReadAsStringAsync();

        var score = JsonSerializer.Deserialize<List<HighScore>>(
        jsonResponse,
        new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

        foreach (var entry in score)
        {
            Console.WriteLine($"\nBest Run: {entry.Name} defeated {entry.Foes} enemies!");
        }
    }
}