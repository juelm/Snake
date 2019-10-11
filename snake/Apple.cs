using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    class Apple
    {
        private int n;
       

        public Apple(int height)
        {
            this.n = height;
        }

        public void generateApple()
        {
            Random apple = new Random();
            int x = apple.Next(1, 2 * n - 1);
            int y = apple.Next(1, n);
            Console.SetCursorPosition(x, y);
            Console.Write("@");

         
        }
    }
}
