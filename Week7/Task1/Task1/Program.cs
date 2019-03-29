using System;
using System.Threading;

namespace Task1
{
    class Program
    {
        public static int j = 0;

        static void Main(string[] args)
        {
            Thread[] th = new Thread[3];
            
            for (int i = 0; i < 3; i++)
            {
                j++;
                th[i] = new Thread(Name);
                th[i].Name = "Thread " + j;
                th[i].Start();
 
            }
            Console.ReadKey();
        }

        static void Name()
        {
            for (int i = 0; i < 3; i++)
                Console.WriteLine(Thread.CurrentThread.Name);
        }
    }
}
