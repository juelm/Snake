using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace Snake
{
    public class ComputerSnake : Snake
    {
        public ArrayList a = new ArrayList();
        public int size;
        HashSet<int> sets = new HashSet<int>();

        public ComputerSnake(int x, int y) : base(x, y)
        {

        }

        //create the adjacency list
        public Dictionary<int, HashSet<int>> maps(int n)
        {
            bool weGoUp = false;
            bool weGoDown = true;
            bool weGoLeft = true;
            bool weGoRight = true;
            int count = 1;

            Dictionary<int, HashSet<int>> adjanceyList = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    HashSet<int> set = new HashSet<int>();
                    if (i > 0) weGoUp = true;
                    if (i >= n - 1) weGoDown = false;
                    if (count % n == 1)
                    {
                        weGoLeft = false;
                    }
                    else
                    {
                        weGoLeft = true;
                    }
                    if (count % n == 0)
                    {
                        weGoRight = false;
                    }

                    else
                    {
                        weGoRight = true;
                    }


                    if (weGoUp) set.Add(count - n);

                    if (weGoDown) set.Add(count + n);


                    if (weGoRight) set.Add(count + 1);


                    if (weGoLeft) set.Add(count - 1);


                    if (adjanceyList.ContainsKey(count))
                    {
                        adjanceyList.Remove(count);
                        adjanceyList.Add(count, set);
                    }
                    else
                    {
                        adjanceyList.Add(count, set);
                    }
                    count++;
                }
            }
            return adjanceyList;
        }

        public void BFS(Dictionary<int, HashSet<int>> adjanceyList, int ApplePos, int headPos, int noOfVertices)
        {

            bool[] isVisited = new bool[noOfVertices];
            Stack<int> s = new Stack<int>();
            Queue<int> q = new Queue<int>();
            isVisited[headPos] = true;
            q.Enqueue(headPos);
            s.Push(headPos);

            while (q.Count != 0)
            {
                headPos = q.Dequeue();
                if (headPos == ApplePos) break;

                HashSet<int> set;
                adjanceyList.TryGetValue(headPos, out set);

                foreach (int j in set)
                {
                    if (!isVisited[j] && !isMe(ConvertToPoint(j)) && !isWall(ConvertToPoint(j)))
                    {

                        isVisited[j] = true; s.Push(j); q.Enqueue(j);
                    }
                }
            }

            ArrayList shortestPathList = new ArrayList();
            shortestPathList.Add(ApplePos);

            int node, next = ApplePos; s.Pop();
            while (s.Count != 0)
            {
                node = s.Pop();
                HashSet<int> set = new HashSet<int>();
                if (adjanceyList.TryGetValue(node, out set) && set.Contains(next))
                {

                    if (node == headPos) break;
                    shortestPathList.Add(node);
                    next = node;

                }
            }
            shortestPathList.Reverse();
            a = shortestPathList;
        }
        public void bestFirstSeach(Dictionary<int, HashSet<int>> adjanceyList, int ApplePos, int headPos, int noOfVertices)
        {
            bool[] isVisited = new bool[noOfVertices];
            Stack<int> s = new Stack<int>();
            Queue<int> q = new Queue<int>();
            isVisited[headPos] = true;
            q.Enqueue(headPos);
            s.Push(headPos);
            int l = ApplePos;
            int n = 100;
            int k = 0;

            while (q.Count != 0)
            {
                headPos = q.Dequeue();
                if (headPos == ApplePos) break;
                HashSet<int> set;
                HashSet<int> setss = new HashSet<int>();
                adjanceyList.TryGetValue(headPos, out set);

                foreach (int j in set)
                {

                    if (!isVisited[j])
                    {
                        if (n > manHattanDistance(ConvertToPoint(headPos), ConvertToPoint(j)))

                        {

                            n = manHattanDistance(ConvertToPoint(headPos), ConvertToPoint(j));
                            k = j;

                        }
                    }
                    isVisited[j] = true;

                }


                if (k != 0)

                {
                    if (!setss.Add(k))
                    {

                        q.Enqueue(k);
                        s.Push(k);
                        n = 100;
                        k = 0;
                    }
                }
            }





            ArrayList shortestPathList = new ArrayList();
            shortestPathList.Add(ApplePos);

            int node, next = ApplePos;
            s.Pop();
            while (s.Count != 0)
            {
                node = s.Pop();

                HashSet<int> set = new HashSet<int>();

                if (adjanceyList.TryGetValue(node, out set) && set.Contains(next))
                {
                    shortestPathList.Add(node);
                    next = node;
                    if (node == headPos)
                        break;



                }
            }


            shortestPathList.Reverse();

            a = shortestPathList;
        }

        public bool isMe(Point p)
        {
            HashSet<Point> set = new HashSet<Point>();
            set.Add(p);
            foreach (Point s in q)
            {
                if (!set.Add(s))

                    return true;
            }

            return false;
        }

        public bool isWall(Point p)
        {

            if (p.Y < 1 || p.Y > size - 2 || p.X < 1 || p.X > size) return true;

            return false;

        }
        public int Convert(int PositionX, int PositionY)
        {

            int number = 1;
            number += PositionX + ((size) * PositionY);
            return number;
        }
        public void changeDirection(Apple apple)
        {


            int Step = (int)a[0];


            if (a.Count > 1)
            {
                Step = (int)a[1];
            }



            Point pStep = ConvertToPoint(Step);



            if (!isMe(pStep) && !isWall(pStep))
            {
                // go right
                if ((pStep.X - positionX) > 0) direction = 1;
                //go left
                if ((pStep.X - positionX) < 0) direction = 3;
                //go up
                if ((pStep.Y - positionY) < 0) direction = 0;
                //go down
                if ((pStep.Y - positionY) > 0) direction = 2;



            }
            else
            {
                killSnake = true;
            }
        }
        public Point ConvertToPoint(int num)
        {

            Point number = new Point();
            number.Y = num / size;
            number.X = (num % size) - 1;
            return number;


        }

        public int manHattanDistance(Point x, Point z)
        {



            if (isMe(z))
            {
                return 500;
            }
            return Math.Abs(x.X - z.X) + Math.Abs(z.Y - z.X);


        }



































        //    public void BSFS(Dictionary<int, HashSet<int>> map, int ApplePos, int headPos, int noOfVertices)
        //    {
        //        bool[] isVisited = new bool[noOfVertices];
        //        Stack<int> s = new Stack<int>();
        //        Queue<int> q = new Queue<int>();
        //        isVisited[headPos] = true;
        //        q.Enqueue(headPos);
        //        s.Push(headPos);
        //        int l = ApplePos;

        //        int n = 100;
        //        int k = 0;

        //        while (q.Count != 0)
        //        {


        //            headPos = q.Dequeue();
        //            if (headPos == ApplePos) break;



        //            HashSet<int> set;
        //            HashSet<int> setss = new HashSet<int>();




        //            map.TryGetValue(headPos, out set);



        //            foreach (int j in set)
        //            {

        //                if (!isVisited[j] && !isWall(ConvertToPoint(j)) && !isMe(ConvertToPoint(j)))
        //                {


        //                    if (n > manHattanDistance(ConvertToPoint(headPos), ConvertToPoint(j)))

        //                    {

        //                        n = manHattanDistance(ConvertToPoint(headPos), ConvertToPoint(j));



        //                        k = j;

        //                    }


        //                    isVisited[j] = true;


        //                }


        //            }


        //            if (k != 0)

        //            {
        //                if (!setss.Add(k))
        //                {

        //                    q.Enqueue(k);
        //                    s.Push(k);
        //                    n = 100;
        //                    k = 0;



        //                }



        //            }
        //        }


        //        ArrayList shortestPathList = new ArrayList();
        //        shortestPathList.Add(ApplePos);

        //        int node, next = ApplePos;
        //        s.Pop();
        //        while (s.Count != 0)
        //        {
        //            node = s.Pop();

        //            HashSet<int> set = new HashSet<int>();

        //            if (map.TryGetValue(node, out set) && set.Contains(next))
        //            {
        //                shortestPathList.Add(node);
        //                next = node;
        //                if (node == headPos)
        //                    break;



        //            }
        //        }


        //        shortestPathList.Reverse();

        //        a = shortestPathList;
        //    }
        //}

    }
}
