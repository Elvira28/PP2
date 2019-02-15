using System;
using System.IO;

namespace Task1
{
    class FarManager
    {
        public bool dir;
        public int cursor;
        public string path;
        public int size;
        public bool ok;
        DirectoryInfo direc = null;
        FileSystemInfo currentFs = null;

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
            ok = true;
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

            for (int i = 0, j = 0; i < fs.Length; i++)
            {
                if (ok == false && (fs[i].Name.StartsWith(".") || fs[i].Name.StartsWith("$")))
                {
                    continue;
                }
                Color(fs[i], j);
                j++;
                Console.WriteLine(j + ". " + fs[i].Name);

            }
        }

        public void UA()
        {
            cursor--;
            if (cursor < 0)
                cursor = size - 1;
        }

        public void DA()
        {
            cursor++;
            if (cursor == size)
                cursor = 0;
        }

        public void CalcS()
        {
            direc = new DirectoryInfo(path);
            FileSystemInfo[] fs = direc.GetFileSystemInfos();
            size = direc.GetFileSystemInfos().Length;

            for (int i = 0; i < direc.GetFileSystemInfos().Length; i++)
            {
                if ((fs[i].Name[0] == '.' || fs[i].Name[0] == '$') && ok == false)
                    size--;
            }

        }

        public void Rabotay()
        {
            ConsoleKeyInfo cki;
            do {
                if (dir)
                {
                    CalcS();
                }
                Korset();
                
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.UpArrow)
                    UA();
                if (cki.Key == ConsoleKey.DownArrow)
                    DA();
                if (cki.Key == ConsoleKey.PageDown)
                {
                    ok = false;
                    cursor = 0;
                }
                if (cki.Key == ConsoleKey.PageUp)
                {
                    ok = true;
                    cursor = 0;
                }

                if (cki.Key == ConsoleKey.Enter)
                {
                    cursor = 0;
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                    {
                        path = currentFs.FullName;
                    }

                    else
                    {
                        Console.Clear();
                        string str;
                        dir = false;
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);
                        str = sr.ReadToEnd();
                        Console.WriteLine(str);
                        Console.ReadKey();
                        sr.Close();
                    }
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    
                    cursor = 0;
                    path = direc.Parent.FullName;
                    dir = true;
                }



                if (cki.Key == ConsoleKey.Delete)
                {
                    if (currentFs.GetType() == typeof(DirectoryInfo))
                        Directory.Delete(path);
                    else
                        File.Delete(path);
                }

                if (cki.Key == ConsoleKey.LeftArrow)
                {
                    string nn = Path.Combine(path, "\\..");
                    if (currentFs.GetType() == typeof(FileInfo) )
                    {
                        File.Move(path, nn + Console.ReadLine());
                    }
                    else
                    {
                        Directory.Move(path, nn + Console.ReadLine());
                    }
                }
            } while (cki.Key != ConsoleKey.Escape);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string path = "C:/Users/Acer/Desktop/test";
            FarManager fm = new FarManager(path);
            fm.Rabotay();
            Console.ReadKey();
        }
    }
}
