using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.Drawing;

namespace Snake
{

    class Game
    {
        Apple apple;
        Board board;
        Timer timer;
        Snake snake;
        int yDimension;

        public Game(int level,int timerms, int snakeStartX, int snakeStartY)
        {
            this.apple = new Apple(level);
            this.board = new Board(level);
            this.snake = new Snake(snakeStartX, snakeStartY);
            this.timer = new Timer(timerms);
            yDimension = level;

        }

        public void playGame()
        {
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;

            
            board.drawBoard();
            Console.CursorVisible = false;
        
            apple.generate();
       
            ConsoleKey action = ConsoleKey.F;
            snake.draw();


            while (action != ConsoleKey.Q)
            {
                action = Console.ReadKey().Key;
                snake.changeDirection(action);
         
            }
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            bool isSnakeDead = snake.slither();
            snake.Eat(apple);
            amIDead(isSnakeDead);
        }

        public void amIDead(bool isDead)
        {

            if(isDead || snake.PositionX <= 0 || snake.PositionX >= yDimension * 2 -1 || snake.PositionY <= 0 || snake.PositionY >= yDimension - 1)
            {
                timer.Stop();
                Console.SetCursorPosition(yDimension / 2, yDimension / 2);
                Console.Write("****Game Over****");
            }
        }

    }
}
