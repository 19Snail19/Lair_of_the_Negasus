namespace Negasus.Console.Tools;

using System;

class Combat
{
    public static void RandEncounter()
    {        
        EnemyStats.enemyName = EnemyNames.EnemyName();

        Text.Typewrite("\nYou come to the top of the stairs, already feeling like you have");
        Text.Typewrite("been in here for an eternity. Emerging into the room, you");
        Text.Typewrite($"are approached by an angry {EnemyStats.enemyName}!");
        Text.Typewrite("...");
        Console.ReadKey(true);        
        

        //Player turn                    

        while ((Program.currentPlayer.health > 0) && (EnemyStats.enemyHealth > 0))
        {
            if (Program.currentPlayer.health > 0)
            {                
                Program.currentPlayer.defense = 12 + (Program.currentPlayer.agility / 2);
                
                Console.WriteLine("\n%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                Console.WriteLine($"{Program.currentPlayer.name}"); 
                Console.WriteLine($"HP: {Program.currentPlayer.health} / {Program.currentPlayer.maxHealth}");
                Console.WriteLine($"Defense: {Program.currentPlayer.defense}");
                Console.WriteLine($"Potions: {Items.potions}");
                Console.WriteLine($"Accessory: {Program.currentPlayer.equipAcc}");
                Console.WriteLine($"Weapon: {Program.currentPlayer.equipWeap}");
                Console.WriteLine($"Artifact: {Program.currentPlayer.equipArt}");
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");

                Console.WriteLine($"{EnemyStats.enemyName}");
                Console.WriteLine($"HP: {EnemyStats.enemyHealth}");
                Console.WriteLine($"Def: {EnemyStats.enemyDef}");
                Console.WriteLine("%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
                
                Console.WriteLine("\nWhat will you do?");
                Console.WriteLine("\n|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
                Console.WriteLine("| A: Attack - Deal damage + strength             |");
                Console.WriteLine("| B: Power Attack - Strong but inaccurate        |");
                Console.WriteLine("| C: Defend - +4 Defense until next turn         |");
                Console.WriteLine("| D: Potion - Restore some health                |");
                Console.WriteLine("| E: Artifact - Use Artifact ability             |");
                Console.WriteLine("|~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~|");
            
                PlayerTurn();
            }
            
            //Enemy turn

            if (EnemyStats.enemyHealth > 0)
            {
                EnemyTurn();
            }
        
        }
    
    }


    //When a random encounter is won.
    public static void RandVictory()
    {
        if (EnemyStats.enemyChoice == 2)
        {
            EnemyStats.enemyChoice = 0;
        }
        
        Program.currentPlayer.roomsClear += 1;
        EnemyStats.enemyHealth = 8 + (Program.currentPlayer.roomsClear * 2);
        EnemyStats.enemyDef = 8 + (Program.currentPlayer.roomsClear / 2);
        
        Text.Typewrite($"\nThe enemy falls to your {Program.currentPlayer.equipWeap}!");
        Text.Typewrite("You have gained an ability point! Where would you like to dump it?");
        Console.WriteLine("\n|~~~~~~~~~~~~~~~~|");
        Console.WriteLine("| A: Strength    |");
        Console.WriteLine("| B: Agility     |");
        Console.WriteLine("| C: Intellect   |");
        Console.WriteLine("|~~~~~~~~~~~~~~~~|");
        Console.WriteLine($"Current abilities:\nSTR: {Program.currentPlayer.strength}\nAGI: {Program.currentPlayer.agility}\nINT: {Program.currentPlayer.intellect}");

        WhutThree:
        string abilityChoice = Console.ReadLine().ToUpper();

            if (abilityChoice == "A")
            {
                Program.currentPlayer.strength += 1;
                Program.currentPlayer.health += 1;
                Program.currentPlayer.maxHealth += 1;
            }
            else if (abilityChoice == "B")
            {
                Program.currentPlayer.agility += 1;
                Program.currentPlayer.defense += (Program.currentPlayer.agility / 2);
            }
            else if (abilityChoice == "C")
            {
                Program.currentPlayer.intellect += 1;
            }
            else if ((abilityChoice != "A") && (abilityChoice != "B") && (abilityChoice != "C"))
            {
                Text.Typewrite("Whut?");
                goto WhutThree;
            }
    
        Items.PotionChance();
    
    }

    //When a random encounter has been lost.
    public static void RandDefeat()
    {
        Program.towerClimb = false;
        Text.Typewrite($"\n{Program.currentPlayer.name} has fallen! The Negasus will continue to");
        Text.Typewrite("terrorize the land!");
        Text.Typewrite($"\nYou managed to defeat {Program.currentPlayer.roomsClear} enemies before");
        Text.Typewrite("your untimely demise.");
        //Remove the below code once high score system has been implemented.
        Text.Typewrite("Once I code in the high score system, that will mean something. Until then,");
        Text.Typewrite("just write it down somewhere or tattoo it on your cheek or something so you");
        Text.Typewrite("can brag about it to people who are giving you a weird (scared?) look.");

        Text.Typewrite("Press any key to quit. But don't be a stranger!");
        Console.ReadKey(true);
    }

    //Player's turn
    public static void PlayerTurn()
    {
                        WhutTwo:
                        Program.currentPlayer.combatChoice = Console.ReadLine().ToUpper();
                
                switch (Program.currentPlayer.combatChoice)
                {
                    case "A":
                        Text.Typewrite($"\n{Program.currentPlayer.name} attacks with their {Program.currentPlayer.equipWeap}!");                    
                        Program.currentPlayer.playerAtkRoll = Rolls.rand.Next(1, 21);
                        Text.Typewrite("...");
                        Console.ReadKey(true);
                            
                        if (Program.currentPlayer.playerAtkRoll == 20)
                        {
                            Text.Typewrite($"{Program.currentPlayer.name} rolls {Program.currentPlayer.playerAtkRoll}!");
                            Rolls.WeaponDamage();
                            Text.Typewrite("\nCRITICAL HIT!!");
                            Program.currentPlayer.damage = (Program.currentPlayer.damage * 2) + (Program.currentPlayer.strength / 2);
                            Items.CowboyHat();
                            Text.Typewrite($"{Program.currentPlayer.name} deals {Program.currentPlayer.damage} damage!");
                            EnemyStats.enemyHealth -= Program.currentPlayer.damage;
                            Text.Typewrite("...");
                            Console.ReadKey(true);
                        }
                        else if (Program.currentPlayer.playerAtkRoll != 20)
                        {
                            Text.Typewrite($"{Program.currentPlayer.name} rolls {Program.currentPlayer.playerAtkRoll} + {Program.currentPlayer.agility / 2}!");
                            Program.currentPlayer.playerAtkRoll += (Program.currentPlayer.agility / 2);
                                if (Program.currentPlayer.playerAtkRoll >= EnemyStats.enemyDef)
                                {                                
                                    Rolls.WeaponDamage();
                                    Program.currentPlayer.damage = Program.currentPlayer.damage + (Program.currentPlayer.strength / 2);
                                    Items.CowboyHat();
                                    Text.Typewrite($"\n{Program.currentPlayer.name} hits for {Program.currentPlayer.damage} damage!");
                                    EnemyStats.enemyHealth -= Program.currentPlayer.damage;
                                    Text.Typewrite("...");
                                    Console.ReadKey(true);                                    
                                }
                                else
                                {
                                    Text.Typewrite($"\n{Program.currentPlayer.name} misses!");
                                    Text.Typewrite("...");
                                    Console.ReadKey(true);                                   
                                }
                        }
                        break;                   
                        
                    case "B":
                        Text.Typewrite($"\n{Program.currentPlayer.name} makes a mighty attack with their {Program.currentPlayer.equipWeap}!");
                        Program.currentPlayer.playerAtkRoll = Rolls.rand.Next(1, 21);
                        Text.Typewrite("...");
                        Console.ReadKey(true);
                            
                        if (Program.currentPlayer.playerAtkRoll == 20)
                        {
                            Text.Typewrite($"{Program.currentPlayer.name} rolls {Program.currentPlayer.playerAtkRoll} + {Program.currentPlayer.agility / 4}!");
                            Rolls.WeaponDamage();
                            Program.currentPlayer.damage = (Program.currentPlayer.damage * 3) + Program.currentPlayer.strength;
                            Items.CowboyHat();
                            Text.Typewrite("\nCRITICAL HIT!!");
                            Text.Typewrite($"{Program.currentPlayer.name} deals {Program.currentPlayer.damage} damage!");
                            EnemyStats.enemyHealth -= Program.currentPlayer.damage;
                            Text.Typewrite("...");
                            Console.ReadKey(true);
                        }
                        else if (Program.currentPlayer.playerAtkRoll != 20)
                        {
                            Text.Typewrite($"{Program.currentPlayer.name} rolls {Program.currentPlayer.playerAtkRoll} + {Program.currentPlayer.agility / 4}!");
                            Program.currentPlayer.playerAtkRoll += (Program.currentPlayer.agility / 4);
                                if (Program.currentPlayer.playerAtkRoll >= EnemyStats.enemyDef)
                                {
                                    Rolls.WeaponDamage();
                                    Program.currentPlayer.damage = (Program.currentPlayer.damage * 2) + Program.currentPlayer.strength;
                                    Items.CowboyHat();
                                    Text.Typewrite($"\n{Program.currentPlayer.name} clobbers {EnemyStats.enemyName} for {Program.currentPlayer.damage} damage!");
                                    EnemyStats.enemyHealth -= Program.currentPlayer.damage;
                                    Text.Typewrite("...");
                                    Console.ReadKey(true);                                    
                                }
                                else
                                {
                                    Text.Typewrite($"{Program.currentPlayer.name} misses spectacularly!");
                                    Text.Typewrite("...");
                                    Console.ReadKey(true);
                                }
                        }
                        break;
                        
                    case "C":
                        Text.Typewrite($"\n{Program.currentPlayer.name} adopts a defensive stance!");
                        Program.currentPlayer.defense += 4;
                        Text.Typewrite($"+4 defense until your next turn! Current defense: {Program.currentPlayer.defense}");
                        Text.Typewrite("...");
                        Console.ReadKey(true);
                        break;

                    case "D": 
                        if (Items.potions > 0)
                        {
                            Text.Typewrite($"\n{Program.currentPlayer.name} gulps down a sweet, sweet potion!");
                            Items.potHeal = Rolls.rand.Next(2, 9) + Program.currentPlayer.strength;
                            Items.Sticker();
                            Text.Typewrite($"You restore {Items.potHeal} health!");
                            Items.potions -= 1;
                            Program.currentPlayer.health += Items.potHeal;
                            if (Program.currentPlayer.health > Program.currentPlayer.maxHealth)
                                {
                                    Program.currentPlayer.health = Program.currentPlayer.maxHealth;
                                }                            
                        }

                        else
                        {
                            Text.Typewrite("\nYou don't have any potions!");
                            goto WhutTwo;
                        }
                        break;

                    case"E":
                        if (Program.currentPlayer.equipArt == "none")
                        {
                            Text.Typewrite("\nYou don't have any artifacts!");
                            goto WhutTwo;
                        }

                        else if (Items.artifactUsed == true)
                        {
                            Text.Typewrite("\nYour artifact needs to recharge!");
                            goto WhutTwo;
                        }

                        else
                        {
                            switch (Program.currentPlayer.equipArt)
                            {
                                case "Wand of Staves":
                                    Items.WandOfStaves();
                                    break;
                                
                                case "Staff of Wands":
                                    Items.StaffofWands();
                                    break;

                                case "Quadforce":
                                    Items.QuadForce();
                                    break;

                                case "Goldfish in a Bag":
                                    Items.Goldfish();
                                    break;

                                default:
                                    Text.Typewrite("\nMy code is broken! This artifact doesn't work!");
                                    goto WhutTwo; 
                            }
                        break;
                        }

                    default:
                        Text.Typewrite("Whut?");
                        goto WhutTwo;                       
                }
    }

    public static void EnemyTurn()
    {
                if (EnemyStats.enemyChoice == 2)
                {
                    EnemyStats.enemyDef -= 4;
                }
                
                
                EnemyStats.enemyChoice = Rolls.rand.Next(0, 3);

                switch (EnemyStats.enemyChoice)
                {
                    case 0:
                        Text.Typewrite($"\n{EnemyStats.enemyName} attacks!");
                        EnemyStats.enemyAtkRoll = Rolls.rand.Next(1, 21);
                        Text.Typewrite("...");
                        Console.ReadKey(true);
                        
                        if (EnemyStats.enemyAtkRoll == 20)
                        {
                            Text.Typewrite($"{EnemyStats.enemyName} rolls {EnemyStats.enemyAtkRoll}!");
                            EnemyStats.plusPower = Rolls.rand.Next(2, 13) + (Program.currentPlayer.roomsClear);
                            Items.Bracers();
                            Text.Typewrite("\nCRITICAL HIT!!");
                            Text.Typewrite($"{EnemyStats.enemyName} deals {EnemyStats.plusPower} damage!");
                            Program.currentPlayer.health -= EnemyStats.plusPower;
                            Text.Typewrite("...");
                            Console.ReadKey(true);
                        }
                        else if (EnemyStats.enemyAtkRoll != 20)
                        {
                            Text.Typewrite($"{EnemyStats.enemyName} rolls {EnemyStats.enemyAtkRoll} + {Program.currentPlayer.roomsClear / 2}!");
                            EnemyStats.enemyAtkRoll += (Program.currentPlayer.roomsClear / 2);
                                if (EnemyStats.enemyAtkRoll >= Program.currentPlayer.defense)
                                {
                                    EnemyStats.power = Rolls.rand.Next(1, 7) + (Program.currentPlayer.roomsClear / 2);
                                    Items.Bracers();
                                    Text.Typewrite($"\n{EnemyStats.enemyName} hits for {EnemyStats.power} damage!");
                                    Program.currentPlayer.health -= EnemyStats.power;
                                    Text.Typewrite("...");
                                    Console.ReadKey(true);                                    
                                }
                                else
                                {
                                    Text.Typewrite($"\n{EnemyStats.enemyName} misses!");
                                    Text.Typewrite("...");
                                    Console.ReadKey(true);                                   
                                }
                        }
                        break;                   
                    
                    case 1:
                        Text.Typewrite($"\n{EnemyStats.enemyName} tries a vicious attack!");
                        EnemyStats.enemyAtkRoll = Rolls.rand.Next(1, 21);
                        Text.Typewrite("...");
                        Console.ReadKey(true);
                        
                        if (EnemyStats.enemyAtkRoll == 20)
                        {
                            Text.Typewrite($"{EnemyStats.enemyName} rolls {EnemyStats.enemyAtkRoll}!");
                            EnemyStats.plusPower = Rolls.rand.Next(3, 19) + Program.currentPlayer.roomsClear;
                            Items.Bracers();
                            Text.Typewrite("\nCRITICAL HIT!!");
                            Text.Typewrite($"{EnemyStats.enemyName} deals {EnemyStats.plusPower} damage!");
                            Program.currentPlayer.health -= EnemyStats.plusPower;
                            Text.Typewrite("...");
                            Console.ReadKey(true);
                        }
                        else if (EnemyStats.enemyAtkRoll != 20)
                        {
                            EnemyStats.enemyAtkRoll += (Program.currentPlayer.roomsClear / 2);
                                if (EnemyStats.enemyAtkRoll >= Program.currentPlayer.defense)
                                {
                                    EnemyStats.plusPower = Rolls.rand.Next(2, 13) + (Program.currentPlayer.roomsClear / 2);
                                    Items.Bracers();
                                    Text.Typewrite($"\n{EnemyStats.enemyName} clobbers {Program.currentPlayer.name} for {EnemyStats.plusPower} damage!");
                                    Program.currentPlayer.health -= EnemyStats.plusPower;
                                    Text.Typewrite("...");
                                    Console.ReadKey(true);                                    
                                }
                                else
                                {
                                    Text.Typewrite($"\n{EnemyStats.enemyName} aimed poorly and missed!");
                                    Text.Typewrite("...");
                                    Console.ReadKey(true);                                   
                                }
                        }
                        break;      
                    
                    case 2:
                        Text.Typewrite($"\n{EnemyStats.enemyName} adopts a defensive stance!");
                        Text.Typewrite("+4 defense until their next turn!");
                        EnemyStats.enemyDef += 4;
                        Text.Typewrite("...");
                        Console.ReadKey(true);
                        break;
                }
        if (Program.currentPlayer.combatChoice == "C")
        {
            Program.currentPlayer.defense -= 4;
        }
    
    }
}
