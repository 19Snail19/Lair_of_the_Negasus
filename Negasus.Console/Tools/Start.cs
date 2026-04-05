namespace Negasus.Console.Tools;

using System;
using Negasus.Console.Models;

public class Start
{
    
    public static void Intro()
    {        
        string titleArt = @"()\ )                 
(()/(     )  (   (    
 /(_)) ( /(  )\  )(   
(_))   )(_))((_)(()\  
| |   ((_)_  (_) ((_) 
| |__ / _` | | || '_| 
|____|\__,_| |_||_|   
         __   _   _          
        / _| | | | |         
   ___ | |_  | |_| |__   ___ 
  / _ \|  _| | __| '_ \ / _ \
 | (_) | |   | |_| | | |  __/
  \___/|_|    \__|_| |_|\___|                            
 _        _______  _______  _______  _______           _______ 
( (    /|(  ____ \(  ____ \(  ___  )(  ____ \|\     /|(  ____ \
|  \  ( || (    \/| (    \/| (   ) || (    \/| )   ( || (    \/
|   \ | || (__    | |      | (___) || (_____ | |   | || (_____ 
| (\ \) ||  __)   | | ____ |  ___  |(_____  )| |   | |(_____  )
| | \   || (      | | \_  )| (   ) |      ) || |   | |      ) |
| )  \  || (____/\| (___) || )   ( |/\____) || (___) |/\____) |
|/    )_)(_______/(_______)|/     \|\_______)(_______)\_______)";
        
        Console.WriteLine(titleArt);

        HiScore.GetScore();
        Thread.Sleep(1500);

        Text.Typewrite("\nPlease enter your name.");
        EnterName:
        Program.currentPlayer.name = Console.ReadLine();
            
            if (Program.currentPlayer.name == "")
            {
                Text.Typewrite("\nCome on, don't be shy. What is your name?");
                goto EnterName;
            }
            
            else if (Program.currentPlayer.name.Length > 15)
            {
                Text.Typewrite("\nHoo boy! Let's try to keep it below 15 characters, if you don't mind.");
                Text.Typewrite("Just to make sure things don't break for any reason, you dig?");
            goto EnterName;
            }
            
            else
            {
                Text.Typewrite($"\nWell met {Program.currentPlayer.name}!");
                Text.Typewrite("Whenever you see an ellipsis just press any key to continue!");
                Text.Typewrite("...");
                Console.ReadKey(true);
            }

        Text.Typewrite("\nNow, it's time for some LORE!");
        Text.Typewrite("Would you like to hear it, or are you gonna break my heart?");
        Console.WriteLine("\n|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
        Console.WriteLine("| A: Stay a while and listen  |");
        Console.WriteLine("| B: Break the DM's heart     |");
        Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
        Lore:
        string choiceTwo = Console.ReadLine().ToUpper();

            if (choiceTwo == "A")
            {
                Text.Typewrite("\nHokay, strap in friend. It's story time.");
                Text.Typewrite("Long ago, a powerful, angry, and INCREDIBLY insane wizard began to");
                Text.Typewrite("dabble in the forbidden art of slapping critter parts together");
                Text.Typewrite("in order to make even worse critters.");
                Text.Typewrite("...");
                Console.ReadKey(true); 

                Text.Typewrite("\nThis nonsense continued for a few decades, giving rise to many");
                Text.Typewrite("of the creatures we know and loathe today. You know the owlbear?");
                Text.Typewrite("Blame the wizard.");
                Text.Typewrite("...");
                Console.ReadKey(true);

                Text.Typewrite("\nFast forward a few MORE decades. The wizard finally completed his magnum opus.");
                Text.Typewrite("Slapping the tail and bitey bits of a crocodile onto the body of a pegasus,");
                Text.Typewrite("the wizard had created a truly monsterous beast...");
                Text.Typewrite("THE NEGASUS!");
                Text.Typewrite("...");
                Console.ReadKey(true);

                Text.Typewrite("\nBlessed with unnatural intelligence... for some reason... and a deep");
                Text.Typewrite("hatred of player characters, the Negasus decided that, for the sake of a");
                Text.Typewrite("text adventure game, it would slay the wizard and turn his tower");
                Text.Typewrite("into its evil lair.");
                Text.Typewrite("...");
                Console.ReadKey(true);

                Text.Typewrite("\nFrom this warren of suckitude, the Negasus recruited some lackeys and began");
                Text.Typewrite("to terrorize the land. Fields were salted. Homes were burned. Cows were tipped.");
                Text.Typewrite("In order to bring peace to the land again, the king... wait. Where are you going?");
                Text.Typewrite("Don't go in there. That's LITERALLY where the Negasus lives. Are you even");
                Text.Typewrite("listening to me!? We didn't even get to the part about ability points!");
                Text.Typewrite("...");
                Console.ReadKey(true);

            }
            else if (choiceTwo == "B")
            {
                Text.Typewrite("\n*Sad DM noises*");
                Text.Typewrite("....but I didn't even get to give my speech about allocating ability points.");
                Text.Typewrite("\nToo late! With utter disregard for the poor DM, you sprint into the tower");
                Text.Typewrite("like a fool. A foolish fool.");
                Text.Typewrite("...");
                Console.ReadKey(true);
            }
            else
            {
                Text.Typewrite("Whut?");
                goto Lore;
            }

    }
}