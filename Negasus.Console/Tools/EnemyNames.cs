namespace Negasus.Console.Tools;

using Negasus.Console.Tools;
class EnemyNames
{
    public static string EnemyName()
    {
        switch (Rolls.rand.Next(0, 16))
        {
            case 0:
                return "Tiny Mushroom Man";
            case 1:
                return "Skeleton";
            case 2:
                return "Rat of Unusual Size";
            case 3:
                return "Sentient Bowl of Beans";
            case 4:
                return "Guy with a Taser";
            case 5:
                return "Vampire";
            case 6:
                return "Rock with Legs";
            case 7:
                return "Troll";
            case 8:
                return "Giant Millipede";
            case 9:
                return "Wild Bulbasaur";
            case 10:
                return "Kobold";
            case 11:
                return "Clown Shark";
            case 12:
                return "Swarm of Bees";
            case 13:
                return "Generic Half-elven Dual Class Ranger";
            case 14:
                return "Fairy with a Tiny Uzi";
            case 15:
                return "Cat Riding a Dog Riding a Horse";
            default:
                return "MISSINGNO";
        }
    }
}