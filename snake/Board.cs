using System;
using System.Collections.Generic;
using System.Text;

namespace Snake
{

    class Board
    {
        int n;

        public Board(int size)
        {
            this.n = size;
        }

        public void drawBoard()
        {

            // upper 
            for (int i = 0; i < 2 * n; i++) Console.Write("*");
            Console.Write("\n");


            // middle
            for (int i = 0; i < n - 2; i++)
            {
                Console.Write("*");
                for (int j = 0; j < 2 * n - 2; j++) Console.Write(" ");
                Console.Write("*");
                Console.Write("\n");

            }

            //lower

            for (int i = 0; i < 2 * n; i++) Console.Write("*");
            Console.Write("\n");

     
        }

    }
    
}
