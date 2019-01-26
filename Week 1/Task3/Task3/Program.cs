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
            int[] arr = new int[2*n+1];
            string[] str = Console.ReadLine().Split();
            int temp = 0; // создаем временную переменную для того, чтобы обращаться к элементам массива string'ов

            for (int i = 0; i <= 2*n; i++)
            {
                arr[i] = 0;
            } // обнуляем массив, чтобы заполнить его элементами
            
            for (int i = 0; i < 2*n - 1; i += 2)
            {
                arr[i] = int.Parse(str[temp]);
                arr[i + 1] = int.Parse(str[temp]);
                temp++;
            } // заполняем по 2 элемента массива integer'ов элементом из string'a
            
            /*выводим массив*/
            for (int i = 0; i < 2*n; i++)
            {
                Console.Write(arr[i] + " ");
            }

            Console.ReadKey();
        }
    }
}
