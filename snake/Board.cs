using System;
namespace Snake
{
    public class Board
    {
        private int height;
        private int width;
        private int startX;
        private int startY;

        public Board(int height, int width, int startX, int startY)
        {
            this.height = height;
            this.width = width;
            this.startX = startX;
            this.startY = startY;
        }

        public void DrawBoard()
        {
            for (int i = startY; i < height; i++)
            {
                if (i == 0 || i == height - 1)
                    for (int j = 0; j < width; j++)
                    {
                        Console.Write("-");
                    }
                else
                {
                    for (int j = 0; j < width; j++)
                    {
                        if (j == 0 || j == width - 1)
                        {
                            Console.Write("|");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
