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

    

    static void Main(string[] args)
    {                
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