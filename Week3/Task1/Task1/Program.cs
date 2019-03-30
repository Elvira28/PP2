using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task1
{
    class FarManager 
    {
        public bool dir;
        public int cursor;
        public string path;
        public int size;
        public bool hidden;
        DirectoryInfo direc = null;
        FileSystemInfo currentFs = null;
        public int UpG = 0;
        public int DwG = 10;

        public FarManager()
        { 
            cursor = 0;
        }

        public FarManager(string path) 
        {
            this.path = path;
            cursor = 0;
            dir = true;
            direc = new DirectoryInfo(path);
            size = direc.GetFileSystemInfos().Length;
            hidden = true;
        }

        public void Color(FileSystemInfo fs, int indx) 
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


        public void Korset() 
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            FileSystemInfo[] fs = direc.GetFileSystemInfos();

            for (int i = UpG; i < DwG; i++)
            {
                if (hidden == false && (fs[i].Name.StartsWith(".") || fs[i].Name.StartsWith("$")))
                {
                    continue;
                }              
                    Color(fs[i], i);
                    Console.WriteLine(i + ". " + fs[i].Name);
            }

        }

        public void UA() 
        {
            cursor--;

            if (cursor < 0)
            {
                cursor = size - 1;
                DwG = size - 1;
                UpG = size - 12;
            }

            if ( cursor < UpG )
            {
                    DwG--;
                    UpG--;
            }    
        }

        public void DA() 
        {
            cursor++;
            if (cursor >= DwG)
            {    
                    UpG++;
                    DwG++;    
            }

            if (cursor == size)
            {              
                cursor = 0;
                DwG = 10;
                UpG = 0;
            }
        }

        public void Razmer() 
        {
            direc = new DirectoryInfo(path);
            FileSystemInfo[] fs = direc.GetFileSystemInfos();
            size = direc.GetFileSystemInfos().Length;

            for (int i = 0; i < direc.GetFileSystemInfos().Length; i++)
            {
                if ((fs[i].Name[0] == '.' || fs[i].Name[0] == '$') && hidden == false)
                {
                    size--;
                }
            }

        }

        public void Rabotay()
        {
            ConsoleKeyInfo cki;
            do
            {
                if (dir) 
                {
                    Razmer();
                }

                Korset();

                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.UpArrow) 
                    UA();

                if (cki.Key == ConsoleKey.DownArrow) 
                    DA();

                if (cki.Key == ConsoleKey.PageDown) 
                {
                    hidden = false;
                    cursor = 0;
                }

                if (cki.Key == ConsoleKey.PageUp) 
                {
                    hidden = true;
                    cursor = 0;
                }

                if (cki.Key == ConsoleKey.Enter) 
                {
                    cursor = 0;
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                        path = currentFs.FullName;
                        UpG = 0;
                        DwG = 10;
                    } 

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
                    } 
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    UpG = 0;
                    DwG = 10;
                    cursor = 0;
                    path = direc.Parent.FullName;
                    dir = true;
                } 

                if (cki.Key == ConsoleKey.Delete)
                {
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                            Directory.Delete(currentFs.FullName);
                    }
                        
                    else
                        File.Delete(currentFs.FullName);
                } 

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
                } 
            } while (cki.Key != ConsoleKey.Escape); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Acer\Desktop\test"; 
            FarManager fm = new FarManager(path); 
            fm.Rabotay(); 
            Console.ReadKey();
        }
    }
}