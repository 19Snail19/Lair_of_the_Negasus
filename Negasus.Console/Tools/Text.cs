namespace Negasus.Console.Tools;

using System;

public class Text
{
    public static void Typewrite(string text, int speed = 10)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(speed);
            }
            Console.WriteLine();
        }
}