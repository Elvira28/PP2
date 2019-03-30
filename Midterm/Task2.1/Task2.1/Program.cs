using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

namespace Task2._1
{
    public class User
    {
        Login log;
        Password pas;

        public User(Login log, Password pas)
        {
            this.log = log;
            this.pas = pas;
        }

        public User()
        {

        }
    }
    class Program
    {
        public static void R(User us)
        {
            FileStream fs = new FileStream("save.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(User));
            xs.Serialize(fs, us);
            fs.Close();
        }

        public static void A(User us)
        {
            FileStream fs = new FileStream("save.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer dr = new XmlSerializer(typeof(User));
            us = dr.Deserialize(fs) as User;
            Console.WriteLine("Welcome");
            fs.Close();
        }

        static void Main(string[] args)
        {
            Login log = new Login("log");
            Password pas = new Password("pas");
            User us = new User(log, pas);
            Console.WriteLine("Choose: 1 or 2");
            string ans = Console.ReadLine();

            if (ans == "1")
                R(us);
            else
                A(us);
        }
    }
}
