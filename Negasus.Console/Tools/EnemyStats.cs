namespace Negasus.Console.Tools;

class EnemyStats
{
        public static string enemyName = "";

        public static int enemyHealth = 8 + (Program.currentPlayer.roomsClear * 2);
        public static int power = 0; //Rolls.rand.Next(1, 7) + (Program.currentPlayer.roomsClear / 2)
        public static int plusPower = 0; //Rolls.rand.Next(2, 13) + (Program.currentPlayer.roomsClear)
        public static int enemyDef = 8;
        public static int enemyAtkRoll = 0; // + (Program.currentPlayer.roomsClear / 2)
        public static int enemyChoice = 0;
}