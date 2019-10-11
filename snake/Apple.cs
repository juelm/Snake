using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Apple
    {
        int x;
        int y;
        int minX;
        int minY;
        int maxX;
        int maxY;
        Random rand;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }

        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }

        }

        public Apple(int minY, int minX, int maxX, int maxY)
        {
            this.minX = minX;
            this.maxX = maxX;
            this.minY = minY;
            this.maxY = maxY;
            this.rand = new Random();

        }

        public void generate()
        {
            x = rand.Next(minX, maxX);
            y = rand.Next(minY, maxY);
            Console.SetCursorPosition(x, y);
            Console.Write('*');
        }



    }
}
