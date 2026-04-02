namespace Negasus.Console.Tools;

using System;

class AbilityAssign
{
    public static void InitialAbilities()
    {
        Text.Typewrite("\n'Maybe the DM is right,' you think to yourself as you trudge up the first");
        Text.Typewrite("stairwell of the Negasus's... Negasususus.... the tower.");
        Text.Typewrite("'Assigning some stat points is probably a good call.'");
        Text.Typewrite("...");
        Console.ReadKey(true);

        Text.Typewrite("\nYou are absolutely correct. Assigning stat points is a GREAT call.");
        Text.Typewrite("Since I am lazy and coding is hard, you only have three abilities");
        Text.Typewrite("in this game: Strength, Agility, and Intellect.");
        Text.Typewrite("...");
        Console.ReadKey(true);
        
        Text.Typewrite("\nSTRENGTH represents how swole you are. Higher strength means your attacks deal");
        Text.Typewrite("more damage and you have more max health.");
        Text.Typewrite("...");
        Console.ReadKey(true);

        Text.Typewrite("\nAGILITY represents the gotta go fast mentality. Higher agility makes you harder");
        Text.Typewrite("to hit and more likely to hit in combat.");
        Text.Typewrite("...");
        Console.ReadKey(true);

        Text.Typewrite("\nINTELLECT represents how big brain you are. With high intellect you are more");
        Text.Typewrite("observant and cunning. You can more easily detect traps.");
        Text.Typewrite("...");
        Console.ReadKey(true);        
        
        Text.Typewrite("\n\nSince I am such a kind and gracious DM, I will give you 5 ability points");
        Text.Typewrite("to do with as you please. Don't spend them all in one place! Or do. I don't care.");

        Program.currentPlayer.maxHealth += 1;

        AbilityReset:
        Program.currentPlayer.abilityPoints = 5;
        Text.Typewrite("\nHow would you like to spend your points? Each selection will increase the");
        Text.Typewrite("selected ability by 1.");

        while (Program.currentPlayer.abilityPoints > 0)
        {   
        Text.Typewrite($"\nYou have {Program.currentPlayer.abilityPoints} points remaining.");
        Console.WriteLine("\n|~~~~~~~~~~~~~~~~|");
        Console.WriteLine("| A: Strength    |");
        Console.WriteLine("| B: Agility     |");
        Console.WriteLine("| C: Intellect   |");
        Console.WriteLine("|~~~~~~~~~~~~~~~~|");
        Console.WriteLine($"Current abilities:\nSTR: {Program.currentPlayer.strength}\nAGI: {Program.currentPlayer.agility}\nINT: {Program.currentPlayer.intellect}");
        WrongAbility:
        string abilityChoice = Console.ReadLine().ToUpper();
        
            if ((abilityChoice == "A") && (Program.currentPlayer.abilityPoints > 0))
            {
                Program.currentPlayer.abilityPoints -= 1;
                Program.currentPlayer.strength += 1;
                Program.currentPlayer.health += 1;
                Program.currentPlayer.maxHealth += 1;
            }
            else if ((abilityChoice == "B") && (Program.currentPlayer.abilityPoints > 0))
            {
                Program.currentPlayer.abilityPoints -= 1;
                Program.currentPlayer.agility += 1;
            }
            else if ((abilityChoice == "C") && (Program.currentPlayer.abilityPoints > 0))
            {
                Program.currentPlayer.abilityPoints -= 1;
                Program.currentPlayer.intellect += 1;
            }
            else if ((abilityChoice != "A") && (abilityChoice != "B") && (abilityChoice != "C"))
            {
                Text.Typewrite("Whut?");
                goto WrongAbility;
            }        
        }

        Text.Typewrite($"\nCurrent abilities:\nSTR: {Program.currentPlayer.strength}\nAGI: {Program.currentPlayer.agility}\nINT: {Program.currentPlayer.intellect}");
        WhutOne:
        Text.Typewrite("Would you like to keep these abilities?\nY/N");
        string tempChoice = Console.ReadLine().ToUpper();

        if (tempChoice == "Y")
        {
            Text.Typewrite("\nVery well! Upward to adventure!");
            Text.Typewrite("...");
            Console.ReadKey(true);
        }
        else if (tempChoice == "N")
        {
            Text.Typewrite("Let's start over then, shall we?");
            Program.currentPlayer.abilityPoints = 5;
            Program.currentPlayer.strength = 1;
            Program.currentPlayer.agility = 1;
            Program.currentPlayer.intellect = 1;
            goto AbilityReset;
        }
        else
        {
            Text.Typewrite("Whut?");
            goto WhutOne;
        }
    }

}