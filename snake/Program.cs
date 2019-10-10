using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 1;
            int y = 1;
            Snake snake = new Snake(1,1,50);
            snake.draw();
            ConsoleKey action = ConsoleKey.F;

            while (action != ConsoleKey.Q)
            {
                //quit = Console.ReadKey().Key;
                //int oldX = x;
                //int oldY = y;

                //switch (quit)
                //{
                //    case ConsoleKey.UpArrow:
                //        y = y - 1;
                //        if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C4")) pacMan = "\u02C5";
                //        else if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u02C5") || pacMan.Equals("\u02C4")) pacMan = "\u0C79";
                //        break;
                //    case ConsoleKey.DownArrow:
                //        y = y + 1;
                //        if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5")) pacMan = "\u02C4";
                //        else if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u02C5") || pacMan.Equals("\u02C4")) pacMan = "\u0C79";
                //        break;
                //    case ConsoleKey.LeftArrow:
                //        x = x - 1;
                //        if (pacMan.Equals("\u02C4") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5")) pacMan = ">";
                //        else if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5") || pacMan.Equals("\u02C4")) pacMan = "-";
                //        break;
                //    case ConsoleKey.RightArrow:
                //        x = x + 1;
                //        if (pacMan.Equals(">") || pacMan.Equals("\u02C4") || pacMan.Equals("-") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5")) pacMan = "<";
                //        else if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5") || pacMan.Equals("\u02C4")) pacMan = "-";
                //        break;
                //}

                ////if (pacMan.Equals("<")) pacMan = "-";
                ////else pacMan = "<";

                //WriteAt(pacMan, x, y);
                //WriteAt(" ", oldX, oldY);

                while (action != ConsoleKey.Q)
                {
                    snake.draw();

                    action = Console.ReadKey().Key;

                    if (action == ConsoleKey.UpArrow) snake.slither();

                }
            }
        }
    }
}
