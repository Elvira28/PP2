using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task1
{
    class Circle
    {
        public int x;
        public int y;

        public Circle()
        {
            this.x = 10;
            this.y = 10;
        }
        public void Movex(int dir)
        {
            if (dir > 0)
                x++;
            else
                x--;
        }
        public void Movey(int dir)
        {
            if (dir > 0)
                y++;
            else
                y--;
        }
        public void Draw()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.SetCursorPosition(x, y);
            Console.Write('o');
        }
    }
    class Program
    {
        static Circle c;
        public static int dirx = 1;
        public static int diry = 1;
        static void Main(string[] args)
        {
            c = new Circle();
            Thread t = new Thread(Move);
            t.Start();

            while (true)
            {
                if (c.x == Console.WindowWidth) dirx = 0;
                else
                if (c.x == 0) dirx = 1;
                if (c.y == Console.WindowHeight) diry = 0;
                else
                    if (c.y == 0) diry = 1;
            }
        }
        public static void Move()
        {
            while (true)
            {
                c.Movex(dirx);
                c.Movey(diry);
                c.Draw();
                Thread.Sleep(250);
            }
        }
    }
}

