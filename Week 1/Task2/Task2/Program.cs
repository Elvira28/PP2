using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student //создаем класс
    {
        public string name;
        public string id;
        public int year;

        public Student() { }

        public Student(string name, string id) // создаем конструктор для двух переменных, this  - работает как поинтер, который хранит адрес экземпляра, с которого была вызвана функция
        {
            this.name = name;
            this.id = id;
        }
        public Student (int year) // конструктор для однй переменной
        {
            this.year = year;
        }

        public void Print() // метод для вывода данных
        {
            Console.WriteLine("Student's name is " + name + ";");
            Console.WriteLine("Student's id is " + id + ";");
        }

        public void Incyear() // метод для вывода данных и ля увеличения года на 1
        {
            ++year;
            Console.WriteLine("Year of student's education is increased, now it is : " + year + ".");
        }
    }

    class Program
    {
        static void F1() // считываем данные, используя методы, увеличиваем год и выводим данные через методы
        {
            string s = Console.ReadLine();
            string[] str = s.Split();
            string name = str[0];
            string id = str[1];
            int year = int.Parse(str[2]);
            Student st1 = new Student(name, id);
            st1.year = year;
            st1.Print();
            st1.Incyear();
        }

        static void F2() // для вывода даннных, без ввода
        {
            Student st2 = new Student("Elvira", "18BD110190");
            st2.year = int.Parse(Console.ReadLine());
            st2.Print();
            st2.Incyear();
        }

        static void Main(string[] args)
        {
            F2();
            Console.ReadKey();
        }
    }
}
