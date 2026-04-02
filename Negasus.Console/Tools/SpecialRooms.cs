namespace Negasus.Console.Tools;

using System;

class SpecialRooms
{
    static int trapDif = 8 + (Program.currentPlayer.roomsClear / 2);
    public static int brainCheck = 0;
    static string healChoice = "";
    public static int roomSelect = 0;
    
    public static void RoomChoice()
    {
            roomSelect = Rolls.rand.Next(1, 101);

            if (roomSelect <=10)
                {
                    SpecialRooms.HealingRoom();
                }
            else if ((roomSelect > 10) && (roomSelect <= 20))
                {
                    SpecialRooms.LootRoom();
                }                                    
            else if ((roomSelect > 20) && (roomSelect <=26))
                {
                    SpecialRooms.TrapRoomPit();
                }
            else if ((roomSelect > 26) && (roomSelect <= 32))
                {
                    SpecialRooms.TrapRoomDarts();
                }
            else if ((roomSelect > 32) && (roomSelect <= 38))
                {
                    SpecialRooms.TrapRoomHex();
                }
            else if (roomSelect > 38)
                {
                    Combat.RandEncounter();
                }
    }
    
    //Room for restoring health
    public static void HealingRoom()
    {        
        Text.Typewrite("\nAs you crest the stairs and peer into the room beyond,");
        Text.Typewrite("you are greeted by an elderly butler. He gestures behind him");
        Text.Typewrite("toward crackling fireplace and a comfy looking sofa. When you");
        Text.Typewrite("turn back to the butler, you see with surprise that he has");
        Text.Typewrite("vanished and in his place is a tray bearing a steaming bowl");
        Text.Typewrite("of stew, a carafe of clear, cold water, and a crystal drinking");
        Text.Typewrite("glass. This seems to be as good a place as any to get some rest.");
        Text.Typewrite("\nWill you rest and recover? Y/N");

        WhutFour:
        SpecialRooms.healChoice = Console.ReadLine().ToUpper();

        if ((SpecialRooms.healChoice != "Y") && (SpecialRooms.healChoice != "N"))
        {
            Text.Typewrite("Whut?");
            goto WhutFour;
        }

        else if (SpecialRooms.healChoice == "Y")
        {
            Text.Typewrite("\nYou eat the stew and sip the cool water as you lounge on the");
            Text.Typewrite("sofa. Within moments your head droops and you drift off to sleep.");
            Text.Typewrite("...");
            Console.ReadKey(true);
            
            Text.Typewrite("\nYou awaken with a start. The fire is now merely embers but you");
            Text.Typewrite("feel as good as new. Your HP has been restored! With renewed vigor,");
            Text.Typewrite("you cross the room and proceed up the stairs.");
            Text.Typewrite("...");
            Console.ReadKey(true);

            Program.currentPlayer.health = Program.currentPlayer.maxHealth;
            Items.artifactUsed = false;
        }
        
        else if (SpecialRooms.healChoice == "N")
        {
            Text.Typewrite("\nConfident that your stamina will hold, you politely tell the bowl");
            Text.Typewrite("of stew, 'No thank you'. You dash past the crackling fire place and");
            Text.Typewrite("comfy sofa, leaving behind a very disappointed meal.");
            Text.Typewrite("...");
            Console.ReadKey(true);
        }
    }

    //Trap that damages agility
    public static void TrapRoomPit()
    {
        Text.Typewrite("\nAs you enter the room, you see... Nothing. No angry enemies, no evil");
        Text.Typewrite("Negasus. Just... nothing, save for the exit at the far side. With a");
        Text.Typewrite("shrug you make for the exit, glad to have a break from combat.");
        Text.Typewrite("...");
        Console.ReadKey(true);

        brainCheck = Rolls.rand.Next(1, 21) + Program.currentPlayer.intellect;
        Items.Keychain();

        if (brainCheck >= trapDif)
        {
            Text.Typewrite("\nA handful of steps into the room you stop. Ahead on the floor you");
            Text.Typewrite("spot an area where the floor tiles are slightly raised. With a smug");
            Text.Typewrite("grin, you give the area a wide berth and arrive safely at the room's exit.");
            Text.Typewrite("...");
            Console.ReadKey(true);
        }

        else
        {
            Text.Typewrite("\nAs you near the midpoint of the room, you feel a slight shift beneath");
            Text.Typewrite("your leading foot accompanied by a subtle click. Before you have time to");
            Text.Typewrite("utter a curse, the floor falls away beneath you!");
            Text.Typewrite("...");
            Console.ReadKey(true);

            Text.Typewrite("\nFeeling panic grip at your very soul, you shriek as you enter freefall.");
            Text.Typewrite("That is, until you make contact with the ground a couple of seconds later.");
            Text.Typewrite("You land hard on your feet. Though it hurts, you don't think anything is");
            Text.Typewrite("broken... but you also feel like you might not be able to move quite as");
            Text.Typewrite("nimbly as you normally could for a while.");
            
            Program.currentPlayer.agility -= 1;

            if (Program.currentPlayer.agility < 0)
            {
                Program.currentPlayer.agility = 0;
            }

            Text.Typewrite("You lose 1 agility point.");
            Text.Typewrite("...");
            Console.ReadKey(true);
        }
    }
    

    //Trap that damages Strength
    public static void TrapRoomDarts()
    {
        Text.Typewrite("\nAt the top of the stairs, you are not greeted by a room, but rather a long");
        Text.Typewrite("narrow hallway. Not seeing any enemies ahead, you press on.");
        Text.Typewrite("...");
        Console.ReadKey(true);

        brainCheck = Rolls.rand.Next(1, 21) + Program.currentPlayer.intellect;
        Items.Keychain();

        if (brainCheck >= trapDif)
        {
            Text.Typewrite("\nYou catch a glimpse of something curious out of the corner of your eye");
            Text.Typewrite("that gives you pause. Upon closer inspection, what you intitially thought");
            Text.Typewrite("was simply decoration along the walls is a cleverly disguised dart trap!");
            Text.Typewrite("Quickly determining the trigger, you are able to bypass the trap and");
            Text.Typewrite("continue on your way.");
            Text.Typewrite("...");
            Console.ReadKey(true);
        }
        
        else
        {
            Text.Typewrite("\nStriding confidently down the hall, you are stopped by a subtle fwhip,");
            Text.Typewrite("followed by a stinging sensation in your right arm. You look down and see");
            Text.Typewrite("a small feathered dart protruding from your bicep. You feel a sudden urge");
            Text.Typewrite("to flee, so you do. You sprint down the hall toward the exit chased by an");
            Text.Typewrite("orchestra of fwhips.");
            Text.Typewrite("...");
            Console.ReadKey(true);

            Program.currentPlayer.strength -= 1;

            if (Program.currentPlayer.strength < 0)
            {
                Program.currentPlayer.strength = 0;
            }

            Text.Typewrite("\nYou stop at the foot of the stairwell to catch your breath and assess the");
            Text.Typewrite("damage. You pluck several darts from varous parts of your body and toss");
            Text.Typewrite("them to the ground bitterly. As you turn and begin to ascend the stairs, you");
            Text.Typewrite($"notice that you feel a little weaker than normal. You lose 1 strength point.");
            Text.Typewrite("...");
            Console.ReadKey(true);
        }
    }

    //Trap to reduce Int
    public static void TrapRoomHex()
    {
        Text.Typewrite("\nArriving at the top of the stairs, you peer into the next room. It is empty, other");
        Text.Typewrite("than the pedestal in the center. Atop it sits a polished chrome orb. As you approach,");
        Text.Typewrite("you notice a small switch on the back of the orb.");
        Text.Typewrite("...");
        Console.ReadKey(true);

        brainCheck = Rolls.rand.Next(1, 21) + Program.currentPlayer.intellect;
        Items.Keychain();

        if (brainCheck >= trapDif)
        {
            Text.Typewrite("\nYou reach for the switch, but stop short. You feel like you have seen this");
            Text.Typewrite("orb somewhere before. Feeling it is better to err on the side of caution,");
            Text.Typewrite("you wisely choose to ignore the orb and continue across the room and up the");
            Text.Typewrite("stairs.");
            Text.Typewrite("...");
            Console.ReadKey(true);
        }
        
        else
        {
            Text.Typewrite("\nCuriosity overrides your common sense as you reach out and flip the switch.");
            Text.Typewrite("The orb immediately begins emitting visible waves of... confusion? Oh no!");
            Text.Typewrite("It's the Orb of Confusion!");
            Text.Typewrite("...");
            Console.ReadKey(true);

            Program.currentPlayer.intellect -= 1;

            if (Program.currentPlayer.intellect < 0)
            {
                Program.currentPlayer.intellect = 0;
            }

            Text.Typewrite("\nYou stand next to the orb, making dumb sounds and drooling. By some stroke");
            Text.Typewrite("of blind luck, you stumble into the pedestal, knocking the orb to the floor");
            Text.Typewrite("where it shatters. You slowly regain your senses and turn to leave, wiping drool");
            Text.Typewrite("from your chin.");
            Text.Typewrite("...");
            Console.ReadKey(true);

            Text.Typewrite("\nBy the time you reach the stairs and begin to ascend, you have already forgotten");
            Text.Typewrite($"what had happened just moments before... You lose 1 intellect point.");
            Text.Typewrite("...");
            Console.ReadKey(true);
        }
    }

    public static void LootRoom()
    {
        Text.Typewrite("\nAs soon as you enter the room your loot senses begin tingle.");
        Text.Typewrite("Your eyes greedily scan the room until... there! A box!");
        Text.Typewrite("You dash over to the box and do a little prospector jig");
        Text.Typewrite("before kneeling to remove the lid.");
        Text.Typewrite("...");
        Console.ReadKey(true);

        int lootRoll = Rolls.rand.Next(1, 101);
        
        if (lootRoll <= 50)
        {
            Items.NoLoot();
        }

        else if ((lootRoll >= 51) && (lootRoll <= 70))
        {
            Items.WeapLoot();
        }

        else if ((lootRoll >= 71) && (lootRoll <= 90))
        {
            Items.AccLoot();
        }

        else if (lootRoll >= 91)
        {
            Items.ArtLoot();
        }
    }






}