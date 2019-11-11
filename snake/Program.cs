using System;
using System.Timers;

namespace Snake
{
    class Program

    {
        static int height = 20;
        static int ms = 100;
        static int snakeStartX = 5;
        static int snakeStartY = 5;
        static void Main(string[] args)
        {
            ConsoleKey play = ConsoleKey.N;

            Console.WriteLine("Do you want to play traditional snake?");
            Console.WriteLine("Or against the computer");

            Console.WriteLine("\nEnter c to play computer or any other key to play the traditional snake game.");

            ConsoleKey type = Console.ReadKey().Key;

            while (play != ConsoleKey.Q)
            {
                Console.Clear();
                Game game = new Game(height, ms, snakeStartX, snakeStartY);

                if (type == ConsoleKey.C) game.playAgainstComputer();
                else game.playGame();

                Console.WriteLine("\n\n   Any key to play again. q to quit");
                play = Console.ReadKey().Key;
            }
        }  
    }
}
