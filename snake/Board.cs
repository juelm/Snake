using System;

using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Board
    {
        int n;

        public int N { set; get; }

        public Board(int size)
        {
            this.n = size;
        }
        private static Random _random = new Random();
        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }

        public void drawBoard()
        {

            Console.ForegroundColor = GetRandomConsoleColor();

            // upper 
            for (int i = 0; i < n; i++) Console.Write("*");
            Console.Write("\n");
            // middle
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("*");
                for (int j = 0; j <  n - 2; j++) Console.Write(" ");
                Console.Write("*");
                Console.Write("\n");
            }
            //lower
            for (int i = 0; i <  n; i++) Console.Write("*");
            Console.Write("\n");
        }
    }

}

//using System;
//namespace Snake
//{
//    public class Board
//    {
//        private int height;
//        private int width;
//        private int startX;
//        private int startY;

//        public Board(int height, int width, int startX, int startY)
//        {
//            this.height = height;
//            this.width = width;
//            this.startX = startX;
//            this.startY = startY;
//        }

//        public void DrawBoard()
//        {
//            for (int i = startY; i < height; i++)
//            {
//                if (i == 0 || i == height - 1)
//                    for (int j = 0; j < width; j++)
//                    {
//                        Console.Write("-");
//                    }
//                else
//                {
//                    for (int j = 0; j < width; j++)
//                    {
//                        if (j == 0 || j == width - 1)
//                        {
//                            Console.Write("|");
//                        }
//                        else
//                        {
//                            Console.Write(" ");
//                        }
//                    }
//                }
//                Console.WriteLine();
//            }

//        }
//    }
//}
