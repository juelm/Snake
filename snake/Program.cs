using System;
using System.Timers;

namespace Snake
{
    class Program
    {

        static int minX = 0;
        static int minY = 0;
        static int maxX = 50;
        static int maxY = 50;
        static int ms = 200;
        static int snakeStartY = 20;
        static int snakeStartX = 20;
        static bool isAlive = true;
        static Apple apple = new Apple(minY, minX, maxX, maxY);
        static Snake snake = new Snake(snakeStartX, snakeStartY, ms);
        //static Timer timer = new System.Timers.Timer(ms);

        static void Main(string[] args)
        {

            //timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            //timer.Enabled = true;

            //Board board = new Board(50, 50, 0, 0);
            //board.DrawBoard();
            Console.CursorVisible = false;
            //Apple apple = new Apple(minY, minX, maxX, maxY);
            apple.generate();
            //Snake snake = new Snake(20,20,500);
            ConsoleKey action = ConsoleKey.F;
            snake.draw();


            while (action != ConsoleKey.Q)
            {
                //snake.draw();

                action = Console.ReadKey().Key;
                snake.changeDirection(action);
                //snake.slither();

                //if (action == ConsoleKey.UpArrow) snake.slither();

            }
            

            //static void Apple()
            //{
            //    Random apple = new Random();
            //    int x = apple.Next(0, 20);
            //    int y = apple.Next(0, 20);
            //    Console.SetCursorPosition(x, y);
            //    Console.Write("*");
            //}

        }

        public static void Eat(Apple ap, Snake sn)
        {
            if (ap.X == sn.PositionX && ap.Y == sn.PositionY)
            {
                snake.Grow(true);
                apple.generate();
            }
        }

        public static void amIDead(Snake snake)
        {
            if (snake.PositionX > maxX || snake.PositionX < minX || snake.PositionY > maxY || snake.PositionY < minY) isAlive = false;
        }

        public static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            snake.slither();
        }
    }
}
