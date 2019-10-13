using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;

namespace Snake
{

    class Game
    {
        Apple apple;
        Board board;
        Timer timer;
        Snake snake;

        public Game(int level,int timerms, int snakeStartX, int snakeStartY)
        {
            this.apple = new Apple(level);
            this.board = new Board(level);
            this.timer = new System.Timers.Timer(timerms);
            this.snake = new Snake(snakeStartX, snakeStartY);
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
            snake.slither();
            snake.Eat(apple);
        }

    }
}
