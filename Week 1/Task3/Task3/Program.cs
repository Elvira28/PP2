using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static void Array(int[] arr, int n, string[] str)
        {
            int temp = 0;
            for (int i = 0; i < 2 * n - 1; i += 2)
            {
                arr[i] = int.Parse(str[temp]);
                arr[i + 1] = int.Parse(str[temp]);
                temp++;
            }// заполняем обнуленный массив продублированными числами

            for (int i = 0; i <2*n; i++)
            {
                Console.Write(arr[i] + " ");
            } // выводим массив
        }

        static void Main(string[] args)
        {
            //вводим данные и сразу же переводим в тип данных integer
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[2*n];
            string[] str = Console.ReadLine().Split();

            for (int i = 0; i < 2*n; i++)
            {
                arr[i] = 0;
            }// обнуляем массив

            Array(arr,n,str); // вызываем функцию

            Console.ReadKey();
        }
    }
}
