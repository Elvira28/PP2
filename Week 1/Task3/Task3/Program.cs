using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*вводим данные и сразу же переводим в тип данных integer*/
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string[] str = Console.ReadLine().Split();
            List<int> list = new List<int>();

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(str[i]);
            }
            /*заполняем list, с динамическим размером, элементами массива:каждый два раза*/
            for (int i = 0; i < n; i++)
            {
                list.Add(arr[i]);
                list.Add(arr[i]);
            }
            /*выводим массив*/
            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

            Console.ReadKey();
        }
    }
}