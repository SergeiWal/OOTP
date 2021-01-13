using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Item it_1 = new Item("Ручка", 12324123, 43.2);
            Item it_2 = new Item("Карандаш", 352245, 34.5);
            Item it_3 = new Item("Ластик", 12314456, 11.2);
            Item it_4 = new Item("Циркуль", 987456311, 43.2);
            Item it_5 = new Item("Тетрадь", 33456654, 34.5);
            Item it_6 = new Item("Линейка", 111199083, 11.2);
            Item it_7 = new Item("Ручка", 12324123, 43.2);

            Shop market = new Shop();
            market += it_1;
            market += it_2;
            market += it_3;
            market += it_4;
            market += it_5;
            market += it_6;
            market += it_7;
            //market.Add(it_1);
            //market.Add(it_2);
            //market.Add(it_3);
            //market.Add(it_4);
            //market.Add(it_5);
            //market.Add(it_6);

            foreach (var i in market)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("--------------------------------------------------------");
            //market -= 2;
            //foreach (var i in market)
            //{
            //    Console.WriteLine(i);
            //}
            Console.WriteLine("--------------------------------------------------------");

            foreach(var i in market)
            {
                Console.WriteLine(i.GetHashCode());
            }
            Console.WriteLine("--------------------------------------------------------");
            Shop market2 = new Shop();
            market2.Add(it_1);
            market2.Add(it_2);
            market2.Add(it_3);
            market2.Add(it_4);
            market2.Add(it_5);
            market2.Add(it_6);
            market2.Add(it_7);
            Shop market3 = new Shop();

            if (market.Equals(market2)) Console.WriteLine("Market1 and market2 equel!");
            if (market.Equals(market3)) Console.WriteLine("Market1 and market3 equel!");

            Console.WriteLine("--------------------------------------------------------");
            Manager mng = new Manager();
            mng.Sale += it_1.Rebate;
            mng.Sale += it_2.Rebate;
            mng.Sale += it_4.Rebate;
            mng.StartSale();

            foreach (var i in market)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("--------------------------------------------------------");
            var ElementCount = market.assortment.Count(p => p.Name == "Ручка");
            Console.WriteLine($"Кол-во ручек в магазине:{ElementCount}");

            Console.ReadKey();
        }
    }
}
