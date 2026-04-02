namespace Negasus.Console.Tools;

using System;
using System.Text.Json;
using Negasus.Console.Models;
        
public class Menu
{
    public static async Task MainMenu()
    {
        Text.Typewrite("\n\nWelcome to the Lair of the Negasus!");
        Again:
        Text.Typewrite("Please make a selection from the following menu.");

        Console.WriteLine("\n|~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
        Console.WriteLine("| A: Start Game              |");
        Console.WriteLine("| B: Best Run                |");
        Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
        string choiceOne = Console.ReadLine().ToUpper();

        if (choiceOne == "A")
            {
                Text.Typewrite("");
            }
        else if (choiceOne == "B")
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:5116");
                HttpResponseMessage response = await client.GetAsync("/HighScore");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();

                    var score = JsonSerializer.Deserialize<List<HighScore>>(
                        jsonResponse,
                        new JsonSerializerOptions {PropertyNameCaseInsensitive = true});

                    foreach (var entry in score)
                {
                    Text.Typewrite($"\n{entry.Name} climbed {entry.Foes} floors!");
                    Text.Typewrite("\nPress any key to continue.");
                    Console.ReadKey(true);
                    goto Again;
                }
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode}");
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }

                Console.ReadKey(true);
            }
    }
}