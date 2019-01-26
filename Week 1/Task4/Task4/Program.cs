using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //считываем количество строк, переводим в integer;
            int n = int.Parse(Console.ReadLine());

            //выводим треугольник по строчкам;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write("[*]");
                } //для того, чтобы началась новая строка;
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
