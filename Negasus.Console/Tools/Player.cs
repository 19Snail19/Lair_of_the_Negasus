namespace Negasus.Console.Tools;

    public class Player
    {
        public string? name;
        public string? combatChoice;
        public string equipWeap = "fist";
        public string equipAcc = "none";
        public string equipArt = "none";

        public bool accessoryHat = false;
        public bool accessoryBracers = false;
        public bool accessoryKeychain = false;
        public bool accessorySticker = false;

        public int roomsClear = 0;
        public int health = 19;
        public int maxHealth = 19; //+ strength
        public int defense = 12;
        public int damage = 0;
        public int playerAtkRoll = 0; // + agility / 2
        public int strength = 1;
        public int agility = 1;
        public int intellect = 1;
        public int abilityPoints = 0;
    }