using System;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace Snake
{
    public class Snake
    {
        protected int positionX;
        protected int positionY;        
        private char icon = '<';
        public Queue<Point> q = new Queue<Point>();
        public int direction = 1;
        public bool grow = false;
        public bool killSnake = false;
        ComputerSnake cSnake;
        private static Random _random = new Random();
        public object eLock = new object();

        private static ConsoleColor GetRandomConsoleColor()
        {
            var consoleColors = Enum.GetValues(typeof(ConsoleColor));
            return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
        }

        public int PositionY
        {

            get
            {
                return positionY;
            }

            set
            {
                positionY = value;
            }

        }

        public int PositionX
        {

            get
            {
                return positionX;
            }

            set
            {
                positionX = value;
            }

        }

        public Snake(int x, int y)
        {
            positionX = x;
            positionY = y;

        }

        public virtual void changeDirection(ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    this.direction = 0;
                    break;
                case ConsoleKey.DownArrow:
                    this.direction = 2;
                    break;
                case ConsoleKey.LeftArrow:
                    this.direction = 3;
                    break;
                case ConsoleKey.RightArrow:
                    this.direction = 1;
                    break;
            }
        }

        public bool slither()
        {
            if(direction == 0)
            {
                if (icon == '>' || icon == '<' || icon == '-' || icon == '\u0C79' || icon == '\u02C4') icon = '\u02C5';
                else if (icon == '>' || icon == '<' || icon == '-' || icon == '\u02C5' || icon == '\u02C4') icon = '\u0C79';

                positionY -= 1;
            }

            if (direction == 1)
            {
                if (icon == '>' || icon == '\u02C4' || icon == '-' || icon == '\u0C79' || icon == '\u02C5') icon = '<';
                else if (icon == '>' || icon == '<' || icon == '\u0C79' || icon == '\u02C5' || icon == '\u02C4') icon = '-';

                positionX += 1;
            }

            if (direction == 2)
            {
                if (icon == '>' || icon == '<' || icon == '-' || icon == '\u0C79' || icon == '\u02C5') icon = '\u02C4';
                else if (icon == '>' || icon == '<' || icon == '-' || icon == '\u02C5' || icon == '\u02C4') icon = '\u0C79';

                positionY += 1;
            }

            if (direction == 3)
            {
                if (icon == '\u02C4' || icon == '<' || icon == '-' || icon == '\u0C79' || icon == '\u02C5') icon = '>';
                else if (icon == '>' || icon == '<' || icon == '\u0C79' || icon == '\u02C5' || icon == '\u02C4') icon = '-';

                positionX -= 1;
            }

            bool isSnakeDead = isDead();

            Point position = new Point(positionX, positionY);
            q.Enqueue(position);

            draw();

            return isSnakeDead;
        }
       
        public void snakeDisapear()
        {
            lock (eLock)
            {
                foreach (Point p in q)
                {
                    Console.SetCursorPosition(p.X, p.Y);
                    Console.Write(" ");
                }
            }

        }
        public void draw()
        {


            if (q.Count > 1 && grow == false)
            {
                Point tail = q.Dequeue();

                Console.SetCursorPosition(tail.X, tail.Y);

                Console.Write(" ");

            }

            Console.ForegroundColor = GetRandomConsoleColor();
            lock (eLock)
            {
                foreach (Point pt in q)
                {

                    Console.SetCursorPosition(pt.X, pt.Y);
                    Console.Write('*');

                    Console.SetCursorPosition(positionX, positionY);
                    Console.Write(icon);
                }
                Console.ResetColor();


                grow = false;
            }
        }

        public void Eat(Apple apple)
        {

            if (apple.X == PositionX && apple.Y == PositionY)
            {
                grow = true;
             
                apple.generate();
            }  
        }

        public bool isDead()
        {
            bool amIDead = false;

            if (q.Count >= 1)
            {
                foreach (Point p in q)
                {
                    if (p.X == PositionX & p.Y == PositionY)
                    {
                        amIDead = true;
                    }
                    
                }
            }

            return amIDead;
        }

    }
}
