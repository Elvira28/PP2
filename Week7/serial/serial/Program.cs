using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace serial
{
    class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product("Name1", 200);
            Product p2 = new Product("Name2", 500);
            Shop shop = new Shop("ShopName", "ShopType", p1);
            shop.body.Add(p2);
            shop.Ser(shop);
            Shop shop2 = shop.Des();
            Console.WriteLine("WELCOME TO" + shop2.ShopName);
            Console.WriteLine("It is an " + shop2.ShopType + " Shop");
            Console.Write("NAME " + shop2.p.name + " PRICE " + shop2.p.price);
            Console.ReadKey();

        }
    }
    public class Shop
    {
        public string ShopName;
        public string ShopType;
        public List<Product> body;
        public Product p;
        public Shop() { }
        public Shop(string ShopName, string ShopType, Product p)
        {
            this.ShopName = ShopName;
            this.ShopType = ShopType;

            this.p = p;
            body = new List<Product>
            {
                new Product("NAME",100)
            };

        }
        public override string ToString()
        {
            return ShopType;
        }
        public void Ser(Shop s)
        {
            FileStream fs = new FileStream("save.xml", FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new XmlSerializer(typeof(Shop));
            xs.Serialize(fs, s);
            fs.Close();
        }
        public Shop Des()
        {
            FileStream fs = new FileStream("save.xml", FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new XmlSerializer(typeof(Shop));
            Shop S = xs.Deserialize(fs) as Shop;
            return S;
        }
    }
    public class Product
    {
        public string name;
        public int price;
        public Product() { }
        public Product(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

    }
}
