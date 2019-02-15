using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    class FarManager //create needed variables
    {
        public bool dir;
        public int cursor;
        public string path;
        public int size;
        public bool hidden;
        DirectoryInfo direc = null;
        FileSystemInfo currentFs = null;

        public FarManager() // create constructor to get cursor to the 0-th string, if we open new folder
        {
            cursor = 0;
        }

        public FarManager(string path) // constructor for all methods
        {
            this.path = path;
            cursor = 0;
            dir = true;
            direc = new DirectoryInfo(path);
            size = direc.GetFileSystemInfos().Length;
            hidden = true;
        }

        public void Color(FileSystemInfo fs, int indx) // method to color folder, files and present string in different colors
        {
            if (cursor == indx)
            {
                currentFs = fs;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (fs.GetType() == typeof(FileInfo))
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


        public void Korset() //method to sort and write all folders and files 
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            var folders = direc.GetDirectories();
            var files = direc.GetFiles();

            int j = 0;
            foreach (var i in folders)
            {
                if (hidden == false && (i.Name.StartsWith(".") || i.Name.StartsWith("$")))
                {
                    continue;
                }
                Color(i, j);
                j++;
                Console.WriteLine(j + ". " + i.Name);
            }

            int temp = j;
            foreach(var i in files)
            {
                if (hidden == false && (i.Name.StartsWith(".") || i.Name.StartsWith("$")))
                {
                    continue;
                }
                Color(i, temp);
                temp++;
                Console.WriteLine(temp + ". " + i.Name);
            }
        }

        public void UA() // if we push UpArrow - goes up in list
        {
            cursor--;
            if (cursor < 0)
                cursor = size-1;
        }

        public void DA() // if we push DownArrow - goes down in list
        { 
            cursor++;
            if (cursor == size)
                cursor = 0;
        }

        public void CalcS() // to recalculate size every time, when we hide hidden files
        {
            direc = new DirectoryInfo(path);
            FileSystemInfo[] fs = direc.GetFileSystemInfos();
            size = direc.GetFileSystemInfos().Length;

            for (int i = 0; i < direc.GetFileSystemInfos().Length; i++)
            {
                if ((fs[i].Name[0] == '.' || fs[i].Name[0] == '$') && hidden == false)
                    size--;
            }

        }

        public void Rabotay()
        {
            ConsoleKeyInfo cki;
            do
            {
                if (dir) // if we in directory, recalculate size
                {
                    CalcS();
                }

                Korset();

                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.UpArrow) // call method
                    UA();

                if (cki.Key == ConsoleKey.DownArrow) // call method
                    DA();

                if (cki.Key == ConsoleKey.PageDown) // call method - hide hidden files
                {
                    hidden = false;
                    cursor = 0;
                }

                if (cki.Key == ConsoleKey.PageUp) // call method - show hidden files
                {
                    hidden = true;
                    cursor = 0;
                }

                if (cki.Key == ConsoleKey.Enter) // open folder or file
                {
                    cursor = 0;
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                        path = currentFs.FullName;
                    } // if folder

                    else
                    {
                        path = currentFs.FullName;
                        Console.Clear();
                        string str;
                        dir = false;
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);
                        str = sr.ReadToEnd();
                        Console.WriteLine(str);
                        Console.ReadKey();
                        sr.Close();
                        fs.Close();
                    } // if file
                }

                if (cki.Key == ConsoleKey.Backspace)
                {

                    cursor = 0;
                    path = direc.Parent.FullName;
                    dir = true;
                } // to go back to previous folder

                if (cki.Key == ConsoleKey.Delete)
                {
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                        Directory.Delete(currentFs.FullName);
                    else
                        File.Delete(currentFs.FullName);
                } //to delete file or folder

                if (cki.Key == ConsoleKey.LeftArrow)
                {
                    Console.Clear();
                    string nname = Console.ReadLine();

                    string npath = Path.Combine(direc.FullName, nname);
                    if (currentFs.GetType() == typeof(FileInfo))
                    {
                        File.Move(currentFs.FullName, npath);
                    }
                    else
                    {
                        Directory.Move(currentFs.FullName, npath);
                    }
                } // to rename file or folder
            } while (cki.Key != ConsoleKey.Escape); // to go out of a program
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Acer/Desktop/test"; // folder that we work with
            FarManager fm = new FarManager(path); 
            fm.Rabotay(); // calling method
            Console.ReadKey();
        }
    }
}