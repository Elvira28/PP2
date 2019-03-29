using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Moving
{
    class Program
    {
        static int g = 0;
        static int r = 0;
        static int gy = 0;
        static int ry = 1;
        static void Main(string[] args)
        {
            Thread th1 = new Thread(Green);
            Thread th2 = new Thread(Red);
            th1.Start();
            th2.Start();
            while (true)
            {
                ConsoleKeyInfo a = Console.ReadKey();
                if (a.Key == ConsoleKey.Spacebar)
                {
                    th1.Abort();
                    th2.Abort();
                }
            }
        }
        static void Green()
        {
            while (true)
            {
                if (g == 10)
                {
                    gy += 2;
                    g = 0;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(g++, gy);
                Console.Write('-');
                Thread.Sleep(500);
            }
        }
        static void Red()
        {
            while (true)
            {
                if (r == 10)
                {
                    ry += 2;
                    r = 0;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(r++, ry);
                Console.Write('-');
                Thread.Sleep(225);
            }
        }
    }
}
