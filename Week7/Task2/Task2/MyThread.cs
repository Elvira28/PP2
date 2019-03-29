using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task2
{
    public class MyThread
    {
        public Thread threadField;
        public MyThread(string name)
        {
            threadField = new Thread(Starting);
            threadField.Name = name;

        }

        public void startThread()
        {
            this.threadField.Start();

        }

        void Starting()
        {
            for (int i = 1; i <= 4; i++)
            {
                Console.WriteLine(this.threadField.Name + " выводит " + i.ToString());               
            }
            Console.WriteLine(this.threadField.Name + " завершился.");
        }
    }
}
