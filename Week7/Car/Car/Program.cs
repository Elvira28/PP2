using System;
using System.Threading;
using System.Collections.Generic;
using System.IO;

namespace Car
{
    class Program
    {
        public static List<Body> bb = new List<Body>();
        public static List<Body> wall = new List<Body>();
        public static bool ok = true;
        public static ConsoleKeyInfo kf = new ConsoleKeyInfo();

        public static void ReadCar()
        {
            StreamReader sr = new StreamReader("car.txt");
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    if ((bb != null) && (rows[i][j] == '*'))
                        bb.Add(new Body(j, i));
                    if ((wall != null) && (rows[i][j] == '#'))
                        wall.Add(new Body(j, i));
                }
            }
        }

        public static bool IsNotCol()
        {
            foreach(Body b in bb)
            {
                foreach (Body b1 in wall)
                {
                    if (b1.x == b.x && b1.y == b.y
                        )
                        return false;
                }
            }
            return true;
        }

        public static void Direction(ConsoleKeyInfo kd)
        {
            if (kd.Key == ConsoleKey.LeftArrow)
                ok = false;
            if (kd.Key == ConsoleKey.RightArrow)
                ok = true;
        }

        public static void Draw()
        {
            while (true)
            {
                Console.Clear();

                    if (!IsNotCol() && ok)
                    {
                        ok = false;
                    }
                    else if (!IsNotCol() && !ok)
                    {
                        ok = true;
                    }
                    for (int i = bb.Count - 1; i >= 0; i--)
                    {
                        if (ok)
                            bb[i].x++;
                        else
                            bb[i].x--;
                        Console.SetCursorPosition(bb[i].x, bb[i].y);
                        Console.Write('*');
                    }

                for (int i = wall.Count-1; i > 0; i--)
                {
                    Console.SetCursorPosition(wall[i].x, wall[i].y);
                    Console.Write('#');
                }
                Thread.Sleep(100);
            }
        }

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            ReadCar();
            Thread thread = new Thread(Draw);
            thread.Start();
            while (true)
            {
                kf = Console.ReadKey();
                Direction(kf);
            }
        }
    }
}