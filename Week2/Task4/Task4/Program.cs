using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        public static void WithFile() // method to create, cope and delete file
        {
            StreamWriter lolkek = new StreamWriter("C:/PP1/keklol.txt"); // creating file
            lolkek.WriteLine("tut dolzhn byt' kakoi-to tekst");
            lolkek.Close();
            //File.WriteAllText("C:/PP1/keklol.txt", "tut dolzhn byt' kakoi-to tekst"); // another way to create file and fill it in
            File.Copy("C:/PP1/keklol.txt", "C:/work/keklol.txt"); // copying file
            File.Delete("C:/PP1/keklol.txt"); // deleting file
        }

        public static void WithDirectory() // method to create and move file
        {
            Directory.CreateDirectory("C:/1 course/kek"); // creating directory
            Directory.Move("C:/1 course/kek", "C:/work/kek"); // moving directory
            //Directory.Delete("C:/1 course/kek");  // we can not use delete function if we moved file 
        }

        public static void Main(string[] args) // calling methods 
        {
            WithFile();
            WithDirectory();
            Console.ReadKey();
        }
    }
}
