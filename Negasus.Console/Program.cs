namespace Negasus.Console.Tools;

using System;
using System.Text.Json;
using Negasus.Console.Models;
using Negasus.Console.Tools;

class Program
{
    public static Player currentPlayer = new Player();
    public static bool towerClimb = true;
    public static bool negasusFight = false;

    

    static async Task Main(string[] args)
    {        
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri("http://localhost:5116");
        HttpResponseMessage response = await client.GetAsync("api/HighScore");

        if (response.IsSuccessStatusCode)
        {
            string jsonResponse = await response.Content.ReadAsStringAsync();

            var score = JsonSerializer.Deserialize<List<HighScore>>(
                jsonResponse,
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
            Console.WriteLine(await response.Content.ReadAsStringAsync());
        }
        
        Start.Intro();

        AbilityAssign.InitialAbilities();

        while ((towerClimb == true) && (negasusFight == false))
        {
            SpecialRooms.RoomChoice();

            if ((currentPlayer.health > 0) && (EnemyStats.enemyHealth <= 0))
            {
                Combat.RandVictory();
            }
            else if ((currentPlayer.health <= 0) && (EnemyStats.enemyHealth > 0))
            {
                Combat.RandDefeat();
            }
        }
    }
}