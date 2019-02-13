using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task1
{
    class FarManager
    {
        public int cursor;
        public string path1;
        //FileSystemInfo currentFs = null;

        public FarManager()
        {
            cursor = 2;
        }

        public FarManager(string path1)
        {
            this.path1 = path1;
            cursor = 2;
        }

        public void Color(FileSystemInfo fs, int index)
        {
            if (cursor == index)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;           
            }

            if (fs.GetType() == typeof(FileInfo))
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void Screen()
        {
            DirectoryInfo directory = new DirectoryInfo(path1);
            FileSystemInfo[] fs = directory.GetFileSystemInfos();

            for (int i = 0; i < fs.Length; i++)
            {
                if (fs[i].Name[0] == '.')
                {
                    continue;
                }
                Color(fs[i], i);
                Console.WriteLine(fs[i].Name);
            }
        }

        public void ArUp()
        {
            cursor++;
        }

        public void ArDown()
        {
            cursor--;
        }

        public void cout ()
        {
            ConsoleKeyInfo cki = Console.ReadKey();

            Screen();

            if (cki.Key == ConsoleKey.UpArrow)
            {
                ArUp();
            }

            if (cki.Key == ConsoleKey.DownArrow)
            {
                ArDown();
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            string path1 = "C:/Users/Acer/Desktop/test";
            FarManager fm = new FarManager(path1);
            fm.Screen();
            Console.ReadKey();
        }
    }
}
