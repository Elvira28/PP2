using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace move
{
    class Program
    {
        static bool Right = true;
        static bool Left = false;
        static int x = 10, y = 10;
        static void Main(string[] args)
        {
            while (true)
            {
                Move();
                Console.Clear();
            }

        }
        static void Move()
        {
            if (Right == true && Left == false)
            {
                x++;
            }
            else if (Left == true && Right == false)
            {
                x--;
            }
            if (x == 40)
            {
                Right = false;
                Left = true;
            }
            else if (x == 1)
            {
                Right = true;
                Left = false;
            }
            Console.SetCursorPosition(x, y);
            Console.Write('*');
            Thread.Sleep(100);


        }
    }
}
