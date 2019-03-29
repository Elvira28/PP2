using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Svetofor
{
    class Program
    {
        static List<ConsoleColor> l = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green };
        static void Main(string[] args)
        {
            Timer timer = new Timer(500);
            timer.Elapsed += Timer_Elapsed1;
            timer.Start();
            while (true)
            {
            }
        }

        private static void Timer_Elapsed1(object sender, ElapsedEventArgs e)
        {
            ConsoleColor t = l[0];
            l[0] = l[2];
            l[2] = l[1];
            l[1] = t;
            for (int i = 0; i < 3; ++i)
            {
                Console.SetCursorPosition(40, 10 + i * 2);
                Console.BackgroundColor = l[i];
                Console.Write(" ");
            }
        }


    }
}
