using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace Task1
{
    public class ComplexNum
    {
        public string imagP;
        public string realP;

        public ComplexNum() { }

        public ComplexNum(string imagP, string realP)
        {
            this.imagP = imagP;
            this.realP = realP;
        }

        public override string ToString()
        {
            return "The real part is : " + realP + " and the imaginary part is: " + imagP;
        }
    }


    class Program
    {
        public static string realNum;
        public static string imagNum;

        public static void GetParts(string complex)
        {
            int i = 0;
            while (complex[i] != '+')
            {
                if (complex[i] >= '0' && complex[i] <= '9')
                {
                    realNum += complex[i];
                }
                i++;
            }


            while (complex[i] != 'i')
            {
                if (complex[i] >= '0' && complex[i] <= '9')
                {
                    imagNum += complex[i];
                }
                i++;
            }

        }

        public static void SR(ComplexNum cn, string Name)
        {
                FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer sr = new XmlSerializer(typeof(ComplexNum));
                sr.Serialize(fs, cn);
                fs.Close();
        }

        public static void DS(ComplexNum cn, string Name)
        {
                FileStream fs = new FileStream(Name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                XmlSerializer dr = new XmlSerializer(typeof(ComplexNum));
                cn = dr.Deserialize(fs) as ComplexNum;
                Console.WriteLine(cn);
                fs.Close();
        }

        static void Main(string[] args)
        {
            string complex = Console.ReadLine();
            string Name = Console.ReadLine();
            GetParts(complex);

            ComplexNum cn = new ComplexNum(imagNum, realNum);

            SR(cn, Name);
            DS(cn, Name);
            Console.ReadKey();
        }
    }
}