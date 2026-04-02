namespace Negasus.Console.Tools;

using System;

class Items
{
    public static bool artifactUsed = false;
    public static int potions = 1;
    public static int potHeal = 0;
    public static int index;
    public static int weapResult;
    public static string[] accessory = ["cowboy hat", "bracers", "keychain", "smiley sticker"];
    public static string[] artifact = ["Wand of Staves", "Quadforce", "Staff of Wands", "Goldfish in a Bag"];
    public static string [] weapons = ["pointy twig, broomstick, dagger, whip, broadsword, RPG"];

    public static void WeapLoot()
    {

        if (weapons[index] == Program.currentPlayer.equipWeap)
        {
            NoLoot();
        }        
        
        else
        {
            int weapRoll = Rolls.rand.Next(1, 101);

            if (weapRoll <= 30)
            {
                weapResult = 0;
            }

            else if ((weapRoll > 30) && (weapRoll <= 55))
            {
                weapResult = 1;
            }

            else if ((weapRoll >55) && (weapRoll <= 70))
            {
                weapResult = 2;
            }

            else if ((weapRoll > 70) && (weapRoll <= 85))
            {
                weapResult = 3;
            }

            else if ((weapRoll > 85) && (weapRoll <= 95))
            {
                weapResult = 4;
            }

            else if (weapRoll > 95)
            {
                weapResult = 5;
            }

            index = weapResult;
            
            Text.Typewrite($"\nInside the box you find the... {weapons[index]}!");
            Text.Typewrite($"Will you equip it? Current weapon: {Program.currentPlayer.equipWeap}");
            Text.Typewrite("Y/N");

            WhutWeap:
            string weapUse = Console.ReadLine().ToUpper();
            
                if ((weapUse != "Y") && (weapUse != "N"))
                {
                    Text.Typewrite("Whut?");
                    goto WhutWeap;
                }
                
                else if (weapUse == "Y")
                {
                    Program.currentPlayer.equipWeap = weapons[index];
                    Text.Typewrite("\nYou take the weapon in your hands, testing the balance and weight.");
                    Text.Typewrite("Filled with the confidence that only a new weapon can bring, you continue");
                    Text.Typewrite("up the tower.");
                    Text.Typewrite("...");
                    Console.ReadKey(true);            
                }

                else if (weapUse == "N")
                {
                    Text.Typewrite("\nDeciding that you are pleased with your current weapon, you close the box");
                    Text.Typewrite("and continue onward up the tower.");
                    Text.Typewrite("...");
                    Console.ReadKey(true);
                }
        }
    }

    public static void AccLoot()
    {
        Items.index = Rolls.rand.Next(accessory.Length);
        
        if (accessory[index] == Program.currentPlayer.equipAcc)
        {
            NoLoot();
        }
        
        else
        {
            Text.Typewrite($"\nInside the box you find... the {accessory[index]}!");
            Text.Typewrite($"Will you equip it? Current accessory: {Program.currentPlayer.equipAcc}");
            Text.Typewrite("Y/N");

            WhutAcc:
            string accUse = Console.ReadLine().ToUpper();

            if (accUse == "Y")
            {
                Program.currentPlayer.equipAcc = accessory[index];
                Text.Typewrite("\nFeeling extra stylish, you proceed up the stairs.");
                Text.Typewrite("...");
                Console.ReadKey(true);
            }

            else if (accUse == "N")
            {
                Text.Typewrite("\nYou scoff at the accessory in the box, knowing full well that you are");
                Text.Typewrite("already as stylish as humanly possible. You close the box and continue");
                Text.Typewrite("up the stairs.");
            }

            else
            {
                Text.Typewrite("Whut?");
                goto WhutAcc;
            }
        }
    }

    public static void ArtLoot()
    {
        Items.index = Rolls.rand.Next(artifact.Length);

        if (artifact[index] == Program.currentPlayer.equipArt)
        {
            NoLoot();
        }

        else
        {
            Text.Typewrite("\nAs you lift the lid light begins to spill forth from within. Slowly and");
            Text.Typewrite($"dramatically, you open the box and reveal... the {artifact[index]}!!");
            Text.Typewrite($"What an amazing find! Will you equip it? Current artifact: {Program.currentPlayer.equipArt}");
            Text.Typewrite("Y/N");

            WhutArt:
            string artUse = Console.ReadLine().ToUpper();

            if (artUse == "Y")
            {
                Program.currentPlayer.equipArt = artifact[index];
                Text.Typewrite("\nFeeling a surge of semi-divine power, you practically skip up the stairs.");
                Text.Typewrite("...");
                Console.ReadKey(true);
            }

            else if (artUse == "N")
            {
                Text.Typewrite("Feeling quite content with your current (or lack of) artifact, you close the");
                Text.Typewrite("box and continue up the stairs.");
                Text.Typewrite("...");
                Console.ReadKey(true);
            }

            else
            {
                Text.Typewrite("Whut?");
                goto WhutArt;
            }
        }
    }

    public static void NoLoot()
    {
        Text.Typewrite("\nWith a gleam in your eye that looks suspiciously like money bags, you throw off the");
        Text.Typewrite("the lid only to find... nothing! Not even a cobweb! Heartbroken, you trudge across the");
        Text.Typewrite("room of unending sadness and up the stairs.");
        Text.Typewrite("...");
        Console.ReadKey(true);
    }

    public static void WandOfStaves()
    {
        Text.Typewrite($"\nYou point the wand at your foe. {Program.currentPlayer.roomsClear} wooden staves are ejected");
        Text.Typewrite($"from the end of the wand and collide forcefully with {EnemyStats.enemyName}!");
        
        int wandRoll = Rolls.rand.Next(1, 5);
        int wandDmg = wandRoll * Program.currentPlayer.roomsClear;

        Text.Typewrite($"\n{EnemyStats.enemyName} takes {wandDmg} damage!");
        Text.Typewrite("...");
        Console.ReadKey(true);

        EnemyStats.enemyHealth -= wandDmg;
        artifactUsed = true;
    }

    public static void StaffofWands()
    {
        int staffDmg = Program.currentPlayer.roomsClear * 4;
        
        Text.Typewrite("\nYou raise the staff above your head and bring it down hard on the floor, Gandalf style.");
        Text.Typewrite($"{staffDmg} wands appear above your foe, then begin to rain down on them!");
        Text.Typewrite($"\n{EnemyStats.enemyName} takes {staffDmg} damage!");
        Text.Typewrite("...");
        Console.ReadKey(true);

        EnemyStats.enemyHealth -= staffDmg;
        artifactUsed = true;
    }

    public static void QuadForce()
    {
        Text.Typewrite("\nYou raise the legendary Quadforce over your head and bathe in its holy radiance. You feel");
        Text.Typewrite("courageous, wise, powerful, and fabulous! Your wounds have been healed!");
        Text.Typewrite("...");
        Console.ReadKey(true);

        Program.currentPlayer.health = Program.currentPlayer.maxHealth;
        artifactUsed = true;
    }

    public static void Goldfish()
    {
        Text.Typewrite("\nYou hold forth the mighty Goldfish in a Bag! Few can withstand its awesome fury!");
        Text.Typewrite("Your foe flees from the baleful gaze of the Goldfish!");
        Text.Typewrite("...");
        Console.ReadKey(true);

        EnemyStats.enemyHealth -= 999999;
        Program.currentPlayer.roomsClear -= 1;
    }

    public static void PotionChance()
    {
        int potDrop = Rolls.rand.Next(1, 101);

        if (potDrop <= 30)
        {
            Items.potions += 1;

            Text.Typewrite("\nOh, what's this? Looks like the enemy was guarding something....");
            Text.Typewrite("It's a potion! You snag your prize and continue up the tower.");
            Text.Typewrite("...");
            Console.ReadKey(true);
        }

    }

    public static void CowboyHat()
    {
        if (Program.currentPlayer.accessoryHat == true)
        {
            Program.currentPlayer.damage += 2;
        }
    }

    public static void Bracers()
    {
        if (Program.currentPlayer.accessoryBracers == true)
        {
            EnemyStats.plusPower -= 2;
            if (EnemyStats.plusPower < 0)
            {
                EnemyStats.plusPower = 0;
            }
            
            EnemyStats.power -= 2;
            if (EnemyStats.power <0)
            {
                EnemyStats.power = 0;
            }
        }    
    }

    public static void Keychain()
    {
        if (Program.currentPlayer.accessoryKeychain == true)
        {
            SpecialRooms.brainCheck += 2;
        }
    }

    public static void Sticker()
    {
        if (Program.currentPlayer.accessorySticker == true)
        {
            potHeal += 4;
        }
    }
}