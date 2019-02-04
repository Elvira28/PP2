using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        public static void Spaces(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Console.Write("    ");
            }
        }

        public static void Direc(DirectoryInfo dir, int level) // method to write all files and directories that are located in directory, that we are working with
        {
            foreach (FileInfo f in dir.GetFiles()) // to write all files and directories, that are in previous directory
            {
                Spaces(level); // to separate by spaces
                Console.WriteLine(f.Name);
            }

            foreach (DirectoryInfo d in dir.GetDirectories()) 
            {
                Spaces(level); // to separate by spaces
                Console.WriteLine(d.Name);
                Direc(d, level+1); // call this method again (recursion)
            }
            
        }

        static void Main(string[] args)
        {
            DirectoryInfo directory = new DirectoryInfo("C:/1 course"); // we choose the directory, that we will work with

            Direc(directory, 0); // call the method

            Console.ReadKey();
        }
    }
}
