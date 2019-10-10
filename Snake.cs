using System;
using System.Timers;
namespace Snake
{
    public class Snake
    {
        private int positionX;
        private int positionY;
        private int priorY;
        private char icon = '<';
        private System.Timers.Timer timer;

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

        public Snake(int x, int y, int ms)
        {
            positionX = x;
            positionY = y;
            timer = new System.Timers.Timer(ms);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;
        }

        public void flap()
        {
            priorY = PositionY;

            PositionY -= 3;

        }

        public void slither()
        {
            priorY = positionY;
            PositionY += 1;

            draw();
        }

        public void draw()
        {
            Console.SetCursorPosition(positionX, positionY);
            Console.Write(icon);

            Console.SetCursorPosition(positionX, priorY);
            Console.Write(" ");
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            slither();
        }
    }
}
