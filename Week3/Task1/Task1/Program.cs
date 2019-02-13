using System;
using System.IO;

namespace Task1
{
    class FarManager
    {
        public int cursor;
        public string path;
        public int size;
        public bool ok;
        DirectoryInfo direc = null;
        FileSystemInfo currentFs = null;
        public bool check;

        public FarManager()
        {
            cursor = 0;
        }

        public FarManager(string path)
        {
            this.path = path;
            cursor = 0;
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
                check = false;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                check = true;
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
                if (fs[i].Name[0] == '.')
                    size--;
            }

        }

        public void Rabotay()
        {
            ConsoleKeyInfo cki = Console.ReadKey();

            while (cki.Key != ConsoleKey.Escape)
            {
                CalcS();
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
                    if (check)
                    {
                        path = currentFs.FullName;
                    }

                    else
                    {
                        string str;
                        path = currentFs.FullName;
                        StreamReader sr = new StreamReader(path);
                        str = sr.ReadToEnd();
                        Console.WriteLine(str);
                        sr.Close();
                    }
                }

                if (cki.Key == ConsoleKey.Backspace)
                {
                    cursor = 0;
                    path = direc.Parent.FullName;
                }

                if (cki.Key == ConsoleKey.Delete)
                {
                    path = currentFs.FullName;
                    if (check)
                        Directory.Delete(path);
                    else
                        File.Delete(path);
                }

                if (cki.Key == ConsoleKey.VolumeMute)
                {
                    path = currentFs.FullName;
                    string nn = Path.Combine(path, "\\..");
                    if (check)
                    {
                        File.Move(path, nn + Console.ReadLine());
                    }
                    else
                    {
                        Directory.Move(path, nn + Console.ReadLine());
                    }
                }
            }
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
