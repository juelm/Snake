using System;
using System.Timers;

namespace Snake
{
    class Program

    {
        static int height = 20;
        static int ms = 200;
        static int snakeStartX = 5;
        static int snakeStartY = 5;
        static void Main(string[] args)
        {
            ConsoleKey play = ConsoleKey.N;

            while(play != ConsoleKey.Q)
            {
                Console.Clear();
                Game game = new Game(height, ms, snakeStartX, snakeStartY);
                game.playGame();

                Console.WriteLine("\n\n   Any key to play again. q to quit");
                play = Console.ReadKey().Key;
            }
        }  
    }
}
