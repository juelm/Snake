using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{
    public class Apple
    {

        private int n;
        public int X;
        public int Y;
        public Apple(int height)
        {
            this.n = height;
           
        }
        public void generate()
        {
            Random apple = new Random();
            X = apple.Next(1, 2 * n - 1);
            Y = apple.Next(1, n - 1);
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("@");
            Console.ResetColor();


        }
    }
}



//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Snake
//{
//    public class Apple
//    {
//        int x;
//        int y;
//        int minX;
//        int minY;
//        int maxX;
//        int maxY;
//        Random rand;

//        public int X
//        {
//            get
//            {
//                return x;
//            }
//            set
//            {
//                x = value;
//            }

//        }

//        public int Y
//        {
//            get
//            {
//                return y;
//            }
//            set
//            {
//                y = value;
//            }

//        }

//        public Apple(int minY, int minX, int maxX, int maxY)
//        {
//            this.minX = minX;
//            this.maxX = maxX;
//            this.minY = minY;
//            this.maxY = maxY;
//            this.rand = new Random();

//        }

//        public void generate()
//        {
//            x = rand.Next(minX, maxX);
//            y = rand.Next(minY, maxY);
//            Console.SetCursorPosition(x, y);
//            Console.Write('*');
//        }



//    }
//}
