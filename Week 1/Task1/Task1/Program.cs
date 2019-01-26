using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        // функция bool для проверки, простое число или нет
        public static bool IsPrime( int a )
        {
            if (a == 0)
                return false;
            if (a == 1)
                return false;

            for (int i = 2; i <= Math.Sqrt(a); i++)
            {
                if (a % i == 0)
                    return false;
            }
            return true;
        }
        
        public static void Main(string[] args)
        {
            //считываем нужные данные и переводим в integer, поскольку в с# все счтывается string'ом
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string s = Console.ReadLine();
            string[] str = s.Split();
            int[] arrp = new int[n];
            int cnt = 0;
            
            //переводим считанные числа из массива string'ов в массив из integer'ов
            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(str[i]); 
            }
            //делаем проверку для каждого элемента массива, если простое - закидываем в новый массив
            for (int i = 0; i < n; i++)
            {
                if (IsPrime(arr[i])) {
                    arrp[cnt] = arr[i];
                    cnt++;
                }
            }
            //выводим количество и массив из простых чисел
            Console.WriteLine(cnt);
            for (int i = 0; i < cnt; i++)
            {
                Console.Write(arrp[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
