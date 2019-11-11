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
        Apple apple1;
        Apple apple2;


        Board board;
        Timer timer;
        Snake snake;
        ComputerSnake cSnake;
        ComputerSnake cSnake1;
        ComputerSnake cSnake2;

        int dimension;





        public Game(int level, int timerms, int snakeStartX, int snakeStartY)
        {
            apple = new Apple(level);
            //apple1 = new Apple(level);
           // apple2 = new Apple(level);



            this.board = new Board(level);
            this.snake = new Snake(snakeStartX, snakeStartY);
            this.timer = new Timer(timerms);
            dimension = level;


        }

        public void playGame()
        {
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;


            board.drawBoard();
            Console.CursorVisible = false;




            ConsoleKey action = ConsoleKey.UpArrow;
            // snake.draw();


            while (action == ConsoleKey.UpArrow || action == ConsoleKey.DownArrow || action == ConsoleKey.LeftArrow || action == ConsoleKey.RightArrow)
            {
                action = Console.ReadKey().Key;
                snake.changeDirection(action);

            }
        }

        public void playAgainstComputer()
        {
            Console.CursorVisible = false;

            cSnake = new ComputerSnake(snake.PositionX + 5, snake.PositionY + 5);
            cSnake1 = new ComputerSnake(snake.PositionX + 5, snake.PositionY + 5);
            cSnake2 = new ComputerSnake(snake.PositionX + 5, snake.PositionY + 5);

            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
            timer.Enabled = true;

            cSnake.size = dimension;
            cSnake1.size = dimension;
            cSnake2.size = dimension;
            //Console.Clear();
            board.drawBoard();
            Console.CursorVisible = false;

            apple.generate();
            //apple1.generate();
            //apple2.generate();

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
            //amIDead(isSnakeDead, snake);
        }
        int count1 = 0;
        int count = 0;
        public void OnTimedEvent2(Object source, ElapsedEventArgs e)
        {

            Console.CursorVisible = false;
            lock (cSnake.eLock)
            {
                if (!cSnake.killSnake)
                {


                    cSnake.BFS(cSnake.maps(dimension), cSnake.Convert(apple.X, apple.Y), cSnake.Convert(cSnake.PositionX, cSnake.PositionY), (dimension * dimension) + 1);

                    cSnake.changeDirection(apple);
                    cSnake.slither();
                    cSnake.Eat(apple);
                }


                else
                {
                    cSnake.snakeDisapear();

                    cSnake = new ComputerSnake(snake.PositionX + 5, snake.PositionY + 5);

                    cSnake.size = dimension;
                }
            }
            lock (cSnake2.eLock)

            {

                if (!cSnake2.killSnake)
                {
                    cSnake2.bestFirstSeach(cSnake2.maps(dimension), cSnake2.Convert(apple.X, apple.Y), cSnake2.Convert(cSnake2.PositionX, cSnake2.PositionY), (dimension * dimension) + 1);



                    cSnake2.changeDirection(apple);
                    cSnake2.slither();


                    cSnake2.Eat(apple);
                }

                else
                {
                    cSnake2.snakeDisapear();
                    // count1 = 0;

                    cSnake2 = new ComputerSnake(snake.PositionX + 5, snake.PositionY + 5);
                    cSnake2.size = dimension;
                    //cSnake.killSnake = false;

                }
            }

            lock (cSnake1.eLock)
            {
                if (cSnake1.killSnake)
                {


                    cSnake1.BFS(cSnake1.maps(dimension), cSnake1.Convert(apple.X, apple.Y), cSnake1.Convert(cSnake1.PositionX, cSnake1.PositionY), (dimension * dimension) + 1);



                    cSnake1.changeDirection(apple);
                    cSnake1.slither();


                    cSnake1.Eat(apple);
                }

                else
                {
                    cSnake1.snakeDisapear();
                    // count1 = 0;

                    cSnake1 = new ComputerSnake(snake.PositionX + 5, snake.PositionY + 5);
                    cSnake1.size = dimension;
                    //cSnake.killSnake = false;

                }
            }

            //cSnake.BFS(cSnake.maps(dimension), cSnake.Convert(apple.X, apple.Y), cSnake.Convert(cSnake.PositionX, cSnake.PositionY), (dimension * dimension) + 1);

            //bool isSnakeDead = snake.slither();
            //snake.Eat(apple);


            // amIDead(isSnakeDead, snake);
            //amIDead(isComputerSnakeDead, cSnake);
        }
    }
}



    
