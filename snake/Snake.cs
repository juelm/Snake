using System;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace Snake
{
    public class Snake
    {
        private int positionX;
        private int positionY;
        private int priorY;
        private char icon = '<';
        private Queue<Point> q = new Queue<Point>();
        private System.Timers.Timer timer;
        private int direction = 1;
        private bool grow = false;


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

        public Snake(int x, int y, int ms)
        {
            positionX = x;
            positionY = y;
            timer = new System.Timers.Timer(ms);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;
        }

        public void changeDirection(ConsoleKey direction)
        {
            switch (direction)
            {
                case ConsoleKey.UpArrow:
                    this.direction = 0;
                    if (icon == '>' || icon == '<' || icon == '-' || icon == '\u0C79' || icon == '\u02C4') icon = '\u02C5';
                    else if (icon == '>' || icon == '<' || icon == '-' || icon == '\u02C5' || icon == '\u02C4') icon = '\u0C79';
                    break;
                case ConsoleKey.DownArrow:
                    this.direction = 2;
                    if (icon == '>' || icon =='<' || icon == '-' || icon == '\u0C79' || icon == '\u02C5') icon = '\u02C4';
                    else if (icon == '>' || icon == '<' || icon == '-' || icon == '\u02C5' || icon == '\u02C4') icon = '\u0C79';
                    break;
                case ConsoleKey.LeftArrow:
                    this.direction = 3;
                    if (icon == '\u02C4' || icon == '<' || icon == '-' || icon == '\u0C79' || icon == '\u02C5') icon = '>';
                    else if (icon == '>' || icon == '<' || icon == '\u0C79' || icon == '\u02C5' || icon == '\u02C4') icon = '-';
                    break;
                case ConsoleKey.RightArrow:
                    this.direction = 1;
                    if (icon == '>' || icon == '\u02C4' || icon == '-' || icon == '\u0C79' || icon == '\u02C5') icon = '<';
                    else if (icon == '>' || icon == '<' || icon == '\u0C79' || icon == '\u02C5' || icon == '\u02C4') icon = '-';
                    break;
            }
        }

        public void slither()
        {
            if(direction == 0)
            {
                positionY -= 1;
            }

            if (direction == 1)
            {
                positionX += 1;
            }

            if (direction == 2)
            {
                positionY += 1;
            }

            if (direction == 3)
            {
                positionX -= 1;
            }

            Point position = new Point(positionX, positionY);
            q.Enqueue(position);

            draw();
        }

        public void draw()
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(icon);

            if(q.Count > 1 && grow == false)
            {
                Point tail = q.Dequeue();
                Console.SetCursorPosition(tail.X, tail.Y);
                Console.Write(" ");
            }

            if (q.Count > 1)
            {
                foreach (Point pt in q)
                {
                    Console.SetCursorPosition(pt.X, pt.Y);
                    Console.Write('*');
                }
            }
        }

        public void Grow(bool biggify)
        {
            this.grow = biggify;
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            slither();
        }
    }
}
