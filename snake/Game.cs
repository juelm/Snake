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
        ComputerSnake cSnake;
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

            ConsoleKey action = ConsoleKey.UpArrow;
            snake.draw();


            while (action == ConsoleKey.UpArrow || action == ConsoleKey.DownArrow || action == ConsoleKey.LeftArrow || action == ConsoleKey.RightArrow)
            {
                action = Console.ReadKey().Key;
                snake.changeDirection(action);
         
            }
        }

        public void playAgainstComputer()
        {
            cSnake = new ComputerSnake(snake.PositionX + 5, snake.PositionY + 5);
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
            timer.Enabled = true;


            board.drawBoard();
            Console.CursorVisible = false;

            apple.generate();

            ConsoleKey action = ConsoleKey.UpArrow;
            snake.draw();


            while (action == ConsoleKey.UpArrow || action == ConsoleKey.DownArrow || action == ConsoleKey.LeftArrow || action == ConsoleKey.RightArrow)
            {
                action = Console.ReadKey().Key;
                snake.changeDirection(action);

            }
        }

        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            bool isSnakeDead = snake.slither();
            snake.Eat(apple);
            amIDead(isSnakeDead, snake);
        }

        public void OnTimedEvent2(Object source, ElapsedEventArgs e)
        {
            cSnake.changeDirection(apple);
            bool isComputerSnakeDead = cSnake.slither();
            bool isSnakeDead = snake.slither();
            snake.Eat(apple);
            cSnake.Eat(apple);
            amIDead(isSnakeDead, snake);
            amIDead(isComputerSnakeDead, cSnake);
        }

        public void amIDead(bool isDead, Snake sn)
        {

            if(isDead || sn.PositionX <= 0 || sn.PositionX >= yDimension * 2 -1 || sn.PositionY <= 0 || sn.PositionY >= yDimension - 1)
            {
                timer.Stop();
                Console.SetCursorPosition(yDimension / 2, yDimension / 2);
                Console.Write("****Game Over****");
                Console.SetCursorPosition(yDimension / 2, yDimension / 2 + 1);
                Console.Write("Enter to continue");

            }
        }

    }
}
