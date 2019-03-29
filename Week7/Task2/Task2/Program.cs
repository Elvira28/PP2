using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThread t1 = new MyThread("Thread 1");
            MyThread t2 = new MyThread("Thread 2");
            MyThread t3 = new MyThread("Thread 3");
            t1.startThread();
            t2.startThread();
            t3.startThread();

            Console.ReadKey();
        }
    }
}
