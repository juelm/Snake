using System;
namespace Snake
{
    public class ComputerSnake : Snake
    {
        public ComputerSnake(int x, int y) : base(x, y)
        {

        }

        public void changeDirection(Apple apple)
        {
            if ((apple.X - positionX) > 0)
            {
                //go right
                direction = 1;
            }
            if ((apple.X - positionX) < 0)
            {
                //go left
                direction = 3;
            }
            if ((apple.Y - positionY) < 0)
            {
                //go up
                direction = 0;
            }
            if ((apple.Y - positionY) > 0)
            {
                //go down
                direction = 2;
            }
        }
    }
}
