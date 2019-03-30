using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Threading;

namespace moove
{
    class Program
    {
        static int x = 0, y = 0;
        static int x1 = 1, y1 = 0;
        static int x2 = 0, y2 = 1;
        static int x3 = 1, y3 = 1;

        static int direction = 1;
        static void Draw(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("*");
            Console.SetCursorPosition(x1, y1);
            Console.Write("*");
            Console.SetCursorPosition(x2, y2);
            Console.Write("*");
            Console.SetCursorPosition(x3, y3);
            Console.Write("*");
        }
        static void output()
        {
            while (true)
            {
                if (direction == 1)
                {
                    x++;
                    x1++;
                    x2++;
                    x3++;
                    if (x1 == Console.WindowWidth - 1)
                    {
                        direction = 2;
                    }
                }
                if (direction == 2)
                {
                    y++;
                    y1++;
                    y2++;
                    y3++;
                    if (y2 == Console.WindowHeight - 1)
                    {
                        direction = 3;
                    }
                }
                if (direction == 3)
                {
                    x--;
                    x1--;
                    x2--;
                    x3--;
                    if (x2 == 0)
                    {
                        direction = 4;
                    }
                }
                if (direction == 4)
                {
                    y--;
                    y1--;
                    y2--;
                    y3--;
                    if (y == 0)
                    {
                        direction = 1;
                    }
                }
                Console.Clear();
                Draw(x, y);
                Thread.Sleep(30);
                Console.CursorVisible = false;
            }
        }
        static void Main(string[] args)
        {
            Thread thread = new Thread(output);
            thread.Start();
        }
    }
}
