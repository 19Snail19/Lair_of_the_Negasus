namespace Negasus.Console;

using System;
using Negasus.Console.Tools;
using Negasus.Console.Models;
using System.Text.Json;
using System.Text.Json.Nodes;

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

    public static void UpdateScore()
    {
                string path = @".\Negasus.API\Resources\BestRun.json";
                string json = File.ReadAllText(path);

                var currentScore = JsonSerializer.Deserialize<List<HighScore>>(
                    json,
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

        foreach (var entry in currentScore)
        {
            Text.Typewrite($"\nYour saved Best Run: {entry.Name} defeated {entry.Foes} enemies!");
            Text.Typewrite("\nWould you like to replace it with this run? Y/N");
            Whut:
            string choice = Console.ReadLine().ToUpper();

            if (choice == "Y")
            {
                var newRun = new List<HighScore>
                {
                    new HighScore {Name = Program.currentPlayer.name, Foes = Program.currentPlayer.roomsClear.ToString()}
                };
                
                string updatedScore = JsonSerializer.Serialize(newRun,
                new JsonSerializerOptions {WriteIndented = true});

                File.WriteAllText(path, updatedScore);

                Text.Typewrite(". . . . .", 75);
                Text.Typewrite("\nBest run updated!");
                Text.Typewrite("...");

            }
            else if (choice == "N")
            {
                
            }
            else if ((choice != "Y") && (choice != "N"))
            {
                Console.WriteLine("Whut?");
                goto Whut;
            }
        }
    }
}