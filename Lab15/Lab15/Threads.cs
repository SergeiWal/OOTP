using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Lab15
{
    class Threads
    {
        public Thread t1;
        public Thread t2;
        public int Number { get; set; }
        public Threads(int num)
        {
            t1 = new Thread(Even);
            t2 = new Thread(new ThreadStart(Odd)) { Priority = ThreadPriority.AboveNormal };
            Number = num;
        }
        public void Count(object obj)
        {
            Console.WriteLine("Таймер :");
            int x = (int)obj;
            for (int i = 1; i < 5; i++, x++)
            {
                Console.WriteLine(x * i - i);
            }

        }

        public void Even()
        {
            for (int i = 0; i < Number; i++)
            {
                if (i % 2 == 0)
                {
                    Console.Write(i + " ");
                }
                Thread.Sleep(200);
            }
        }
        public void Odd()
        {
            for (int i = 0; i < Number; i++)
            {
                if (i % 2 != 0)
                {
                    Console.Write(i + " ");
                }
                Thread.Sleep(200);
            }
        }
    }
}
