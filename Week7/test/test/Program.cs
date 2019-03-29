using System;
using System.Threading;

namespace test
{
    class Program
    {
        static string s;

        static void Main(string[] args)
        {
            Thread th1 = new Thread(Substr);
            Thread th2 = new Thread(Time);
            s = Console.ReadLine();
            th1.Start();
            th2.Start();
        }

        static void Substr()
        {
            //string s = Console.ReadLine();
            Console.WriteLine(s);
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    Console.WriteLine(s.Substring(i, j - i + 1));
                    Thread.Sleep(1000);
                }
            }
            Console.WriteLine("End.");
            Environment.Exit(0);
        }

        static void Time()
        {
            for (int i = 0; i < 1000; i++)
            {
                string curTimeLong = DateTime.Now.ToLongTimeString();
                Console.WriteLine(curTimeLong);
                Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }
    }
}
