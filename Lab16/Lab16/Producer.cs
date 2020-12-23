using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace Lab16
{
    class Producer
    {
        private string name;
        private int speed  = 2500;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (speed >= 2500) speed = 1;
                else speed -= value;
            }
        }

        public Producer(string nm, int spd)
        {
            Name = nm;
            Speed = spd;
        }

        public void Add(BlockingCollection<string> assortment, string prod)
        {
            Thread.Sleep(speed);
            if(assortment.TryAdd(prod)) Console.WriteLine($"Поставщик:{Name}, доставил свою продукцию!");
        }

        public static void producerWork(ref BlockingCollection<string> assortment, ref bool flag, string product)
        {
            Producer[] producers = new[]
            {
                new Producer("Bob", 500),
                new Producer("Frank", 1100),
                new Producer("Gomer", 300),
                new Producer("Tramp", 100),
                new Producer("Pytin", 760)
            };

            for (int i = 0; i < 12;)
            {
                foreach (var p in producers)
                {
                    if (i == 5){ flag = true; break; }
                    Thread.Sleep(p.Speed);
                    p.Add(assortment,product);
                    i++;
                }
                if (flag == true) break;
            }
            assortment.CompleteAdding();
        }

    }


}
