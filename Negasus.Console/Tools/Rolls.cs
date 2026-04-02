namespace Negasus.Console.Tools;

using System;

class Rolls
{
    public static Random rand = new Random();

    public static void WeaponDamage()
        {
            switch (Program.currentPlayer.equipWeap)
            {
                case "fist":
                    FistDamage();
                    break;
            
                case "dagger":
                    DaggerDamage();
                    break;
            
                case "broomstick":
                    BroomDamage();
                    break;

                case "RPG":
                    RpgDamage();
                    break;

                case "whip":
                    WhipDamage();
                    break;

                case "pointy twig":
                    TwigDamage();
                    break;

                case "broadsword":
                    SwordDamage();
                    break;

                default:
                    FistDamage();
                    break;
            
            }
        }
    
    public static void FistDamage()
        {
            Program.currentPlayer.damage = rand.Next(1, 7);
        }
    
    public static void DaggerDamage()
        {
            Program.currentPlayer.damage = rand.Next(2, 9);
        }

    public static void BroomDamage()
        {
            Program.currentPlayer.damage = rand.Next(1, 9);
        }

    public static void RpgDamage()
        {
            Program.currentPlayer.damage = rand.Next(1, 21);
        }

    public static void WhipDamage()
        {
            Program.currentPlayer.damage = rand.Next(1, 11);
        }

    public static void TwigDamage()
        {
            Program.currentPlayer.damage = rand.Next(2, 6);
        }

    public static void SwordDamage()
        {
            Program.currentPlayer.damage = rand.Next(2, 13);
        }
}