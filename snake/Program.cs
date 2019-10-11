using System;
using System.Timers;
using System.Drawing;
using System.Collections.Generic;

namespace snakeGame
{
    class Program
    {
        static void Main(string[] args)
        {

            int x = 1;
            int y = 1;
            snake snake = new snake(1, 1, 50);
            snake.print();
            ConsoleKey action = ConsoleKey.F;

            while (action != ConsoleKey.Q)
            {
                //quit = Console.ReadKey().Key;
                //int oldX = x;
                //int oldY = y;

                //switch (quit)
                //{
                //    case ConsoleKey.UpArrow:
                //        y = y - 1;
                //        if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C4")) pacMan = "\u02C5";
                //        else if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u02C5") || pacMan.Equals("\u02C4")) pacMan = "\u0C79";
                //        break;
                //    case ConsoleKey.DownArrow:
                //        y = y + 1;
                //        if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5")) pacMan = "\u02C4";
                //        else if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u02C5") || pacMan.Equals("\u02C4")) pacMan = "\u0C79";
                //        break;
                //    case ConsoleKey.LeftArrow:
                //        x = x - 1;
                //        if (pacMan.Equals("\u02C4") || pacMan.Equals("<") || pacMan.Equals("-") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5")) pacMan = ">";
                //        else if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5") || pacMan.Equals("\u02C4")) pacMan = "-";
                //        break;
                //    case ConsoleKey.RightArrow:
                //        x = x + 1;
                //        if (pacMan.Equals(">") || pacMan.Equals("\u02C4") || pacMan.Equals("-") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5")) pacMan = "<";
                //        else if (pacMan.Equals(">") || pacMan.Equals("<") || pacMan.Equals("\u0C79") || pacMan.Equals("\u02C5") || pacMan.Equals("\u02C4")) pacMan = "-";
                //        break;
                //}

                ////if (pacMan.Equals("<")) pacMan = "-";
                ////else pacMan = "<";

                //WriteAt(pacMan, x, y);
                //WriteAt(" ", oldX, oldY);

                while (action != ConsoleKey.Q)
                {
                    snake.print();

                    action = Console.ReadKey().Key;

                    if (action == ConsoleKey.UpArrow)
                        snake.facing = 2;

                    if (action == ConsoleKey.DownArrow)
                        snake.facing = 3;

                    if (action == ConsoleKey.LeftArrow)
                        snake.facing = 1;


                    if (action == ConsoleKey.RightArrow)
                        snake.facing = 0;





                        snake.go();

                }
            }

        }
    }

    class snake
    {
        int posX;
        int posY;
        int priorX;
        int priorY;
        Timer timer;
        int length;
        int count;
   
        public int facing;

     
        //timer
        public snake(int x, int y, int ms)
        {

            posX = x;
            posY = y;
            timer = new Timer(ms);


            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Enabled = true;


        }
        public void go()
        {
            if (facing == 0)
            {
                priorX = posX;
                posX += 1;
                print();
            }
            //facing left
            if (facing == 1)
            {
                priorX = posX;
                posX -= 1;
                print();
            }
            //facing up 
            if (facing == 2)
            {
                
                
                priorY = posY;
                posY -= 1;
                print();
                

            }
            //facing down
            if (facing == 3)
            {
                
                
                priorY = posY;
                posY += 1;
                print();
            }

        }
        //public void updateTurn()
        //{
        //    //facing right
        //    if (facing == 0)
        //    {
        //        priorX = posX;
        //        posX += 1;
        //    }

        //    //facing left
        //    if (facing == 1)
        //    {
        //        priorX = posX;
        //        posX -= 1;
        //    }
        //    //facing up 
        //    if (facing == 2)
        //    {
        //        priorY = posY;
        //        posY -= 1;

        //    }
        //    //facing down
        //    if (facing == 3)
        //    {
        //        priorY = posY;
        //        posY += 1;
        //    }

        //    //updatePosition(x, y);
        //}
        public bool checkCrash()
        {
            if (posX == 50 || posY == 50)
            {
                return true;
            }

            return false;

        }

        public void grow()
        {
            length++;
        }
        //public void Turn(int facing)
        //{
        //    if (facing == 0)
        //    {
        //        turnRight();
        //    }
        //    if (facing == 1)
        //    {
        //        turnLeft();

        //    }
        //    if (facing == 2)
        //    {
        //        turnUp();
        //    }
        //    if (facing == 3)
        //    {
        //        turnDown();
        //    }

        



            public void print()
        {
            Console.SetCursorPosition(posX, posY);
            int x = posX;
            int y = posY;
            //facing right
            if (facing == 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    
                    Console.Write("*");


                }

            }
                //  facing left
                if (facing == 1)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(posX + i, posY);
                    Console.Write("*");


                }
            }
            
            // facing up  move 

            if (facing == 2) {
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(posX, posY + i);

                    Console.Write("*");


                }

            }

            // facing down move
            if (facing == 3)
            {

                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(posX , posY+i);

                    Console.Write("*");


                }
            }
            
            if (facing == 0)
            {
                Console.SetCursorPosition(priorX, posY);

                //Console.Write("why cant ");
                Console.Write(" ");
            }
                
           if ( facing == 1)
            {


                Console.SetCursorPosition(priorX+5, posY);

                //Console.Write("why cant ");
                Console.Write(" ");


            }
            if (facing == 2)
            {
                Console.SetCursorPosition(posX, priorY+5);
                Console.WriteLine(" ");

            }
                
                    
             if ( facing == 3)
            {
                Console.SetCursorPosition(posX, priorY);
                Console.WriteLine(" ");

            }


        }


        public void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            go();
            count++;
        }
    }
}
    


