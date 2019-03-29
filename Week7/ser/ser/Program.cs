using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ser
{
    public class Shop
    {  
        public string name;
        public string kupil;

        [XmlIgnore]
        public static string[] producty = { "pechenka", "fruits", "sandwich", "sok" };
        public Shop()
        {

        }
        public static void Vyvod()
        {
            for (int i = 0; i < producty.Length; i++)
            {
                Console.WriteLine(producty[i]);
            }
        }
    }
    class Program
    {

        public static void SR(Shop shop)
        {
            FileStream fs = new FileStream(shop.name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer sr = new XmlSerializer(typeof(Shop));
            sr.Serialize(fs, shop);
            fs.Close();
        }

        public static void DS(Shop shop)
        {
            FileStream fs = new FileStream(shop.name, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            XmlSerializer dr = new XmlSerializer(typeof(Shop));
            shop = dr.Deserialize(fs) as Shop;
            Console.WriteLine(shop);
            fs.Close();
        }

        static void Main(string[] args)
        {

            Shop shop = new Shop();
            Console.WriteLine("Hello! What is your name?");
            shop.name = Console.ReadLine();
            Console.Clear();
            Shop.Vyvod();
            int x = 0, y = 0;
            Console.SetCursorPosition(x, y);
            int curs = 0;
            ConsoleKeyInfo cf = new ConsoleKeyInfo();
            while (true)
            {
                cf = Console.ReadKey();

                if (cf.Key == ConsoleKey.Enter)
                {
                    shop.kupil = Shop.producty[curs];
                    SR(shop);
                    break;
                }
                if (cf.Key == ConsoleKey.DownArrow)
                {
                    curs++;
                    y++;
                    if (y > 3)
                    {
                        y = 0;
                        curs = 0;
                    }
                }
                if (cf.Key == ConsoleKey.UpArrow)
                {
                    curs--;
                    y--;
                    if (y < 0)
                    {
                        y = 3;
                        curs = 3;
                    }
                }
                Console.SetCursorPosition(x, y);
            }
            Console.Clear();
            DS(shop);
        }
        
    }

}