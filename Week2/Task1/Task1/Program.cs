using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program // recursion method to check whether the string is palindrome or not
    {
        public static bool IsPalin( string s, int i ) {
            if (s[i] != s[s.Length- 1 - i])
                return false;
            if (i == s.Length / 2)
                return true;
            return IsPalin(s, i + 1);
        }

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            string s = sr.ReadToEnd(); // to read from the "input" file

            if (IsPalin(s, 0)) // call the method to check, whether it is palindrome or not
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            sr.Close();
            Console.ReadKey();
        }
    }
}
