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
            string[,] a = new string[n,n];

            // заполняем двойной массив символами
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    a[i, j] = "[*] ";
                } 
            } 
            // выводим массив в нужном порядке прописывая цикл, чтобы вышла елочка
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(a[i, j]);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
