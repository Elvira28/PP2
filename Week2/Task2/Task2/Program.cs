using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        public static bool IsPrime(int a) // method to check, whether the number is prime or not
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

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt"); // to read from the text file
            string s = sr.ReadToEnd();
            sr.Close(); 

            string[] str = s.Split();
            int[] arr = new int[10000];
            
            for (int i = 0; i < str.Length; i++)
            {
                arr[i] = int.Parse(str[i]);
            }

            StreamWriter sw = new StreamWriter("output.txt"); // create text file to write in it

            for (int i = 0; i < s.Length; i++) // fill in "output" file
            {
                if (IsPrime(arr[i]))
                    sw.Write(arr[i] + " ");
            }
            sw.Close();
            Console.ReadKey();
        }
    }
}
