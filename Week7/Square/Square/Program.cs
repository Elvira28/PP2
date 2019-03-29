using System;
using System.Threading;

namespace Square
{
    class Program
    {
        static int x = 0, y = 0, dx = 1, dy = 0;
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; ++i)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("*");
                Console.SetCursorPosition(i, 0);
                Console.Write("*");
                Console.SetCursorPosition(9, i);
                Console.Write("*");
                Console.SetCursorPosition(i, 9);
                Console.Write("*");

            }
            Console.SetCursorPosition(0, 0);
            Console.Write("#");

            Thread t = new Thread(work);
            t.Start();
            Thread.Sleep(1000);
            while (true)
            {

            }
        }

        private static void work()
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
            Console.SetCursorPosition(x, y);
            Console.Write("#");

            if (x == 9 && y == 0)
                {
                    dx = 0;
                    dy = 1;
                }

            if (x == 9 && y == 9)
                {
                    dx = -1;
                    dy = 0;
                }

            if (x == 0 && y == 9)
                {
                    dx = 0;
                    dy = -1;
                }

            if (x == 0 && y == 0)
                {
                    dx = 1;
                    dy = 0;
                }

            while (true)
            {

                x += dx;
                y += dy;
            }
                
        }
    }
}
