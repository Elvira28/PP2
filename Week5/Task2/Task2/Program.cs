using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task2
{
    public class Mark
    {
        public int points;
        public string LetterMark;

        public Mark() { }

        public Mark (int points)
        {
            this.points = points;
            LetterMark = GetLetter();
        }

        public string GetLetter()
        {
            if (points > 100 || points < 0)
                return "Error! Does not exist!";
            if (points >= 95 && points <= 100)
                return "Your mark is A c:";
            if (points >= 90 && points < 95)
                return "Your mark is A- c:";
            if (points >= 85 && points < 90 )
                return "Your mark is B+ c:";
            if (points >= 80 && points < 85)
                return "Your mark is B c:";
            if (points >= 75 && points < 80)
                return "Your mark is B- c:";
            if (points >= 70 && points < 75)
                return "Your mark is C+ c:";
            if (points >= 65 && points < 70)
                return "Your mark is C c:";
            if (points >= 60 && points < 65)
                return "Your mark is C- c:";
            else
                return "Your mark is F c:";
        }

        public override string ToString()
        {
            return GetLetter();
        }
    }

    class Program
    {

        static void SR(List<Mark> marks, string name)
        { 
            FileStream fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sr = new XmlSerializer(typeof(List<Mark>));
            sr.Serialize(fs, marks);
            fs.Close();
        }

        static void DS(List<Mark> marks, string name)
        {
            FileStream fs = new FileStream(name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer ds = new XmlSerializer(typeof(List<Mark>));
            marks = ds.Deserialize(fs) as List<Mark>;
            fs.Close();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("How many marks do you want to check?");
            int n = int.Parse(Console.ReadLine());
            List<Mark> marks = new List<Mark>();

            for (int i = 0; i < n; i++)
            {
                Mark mark = new Mark(int.Parse(Console.ReadLine()));
                marks.Add(mark);
                Console.WriteLine(mark);
            }

            string name = Console.ReadLine();

            SR(marks, name);
            DS(marks, name);

            Console.ReadKey();

        }
    }
}