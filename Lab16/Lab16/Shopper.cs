using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using System.Threading;

namespace Lab16
{
    class Shopper
    {
        private string name;

        public string Name { get; }

        public Shopper(string nm) { Name = nm; }

        public void Buy(BlockingCollection<string> stock, string prod, bool b)
        {
            try 
            {
                if (stock.Count == 0 && b)
                {
                    Console.WriteLine("Склад пуст!");
                    //Thread.ResetAbort();
                }
                Random rand = new Random();
                Thread.Sleep(rand.Next(500, 2500));

                if (stock.TryTake(out prod))
                    Console.WriteLine($"Покупатель: {Name}, купил товар.");
                else
                    Console.WriteLine($"Покупатель:{Name}, ушел.");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public static void shopperWork(ref BlockingCollection<string> assortment, ref bool flag)
        {
            Shopper[] people = new[]
            {
                new Shopper("Sergo"),
                new Shopper("Max"),
                new Shopper("Iwan№1"),
                new Shopper("Iwan№2"),
                new Shopper("Efim"),
                new Shopper("Kazimir"),
                new Shopper("Nikita"),
                new Shopper("Kiril"),
                new Shopper("Dima"),
                new Shopper("Igor"),
                new Shopper("Oleg"),
                new Shopper("Lera")
            };


            while (!assortment.IsCompleted)
            {
                foreach (var i in people)
                    i.Buy(assortment, "product", flag);
            }
            Console.WriteLine("Склад пуст!");
        }
    }
}
