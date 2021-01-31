using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Task8_4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"---------------------TASK_1 ----------------------");
            Person p1 = new Person(2002, 5, 3, 4000);
            Person p2 = new Person(2012, 5, 3, 1100);
            Person p3 = new Person(2004, 5, 3, 222);
            Person p4 = new Person(2005, 5, 3, 2345);
            Person p5 = new Person(2021, 5, 3, 0);
            Person p6 = new Person(2002, 5, 3, 42334);

            p5.Add(2300);
            Console.WriteLine($"На счёт p5 зачислено 2300$");
            Console.WriteLine($"Со счёта p1 снято { p1.GetMoney(2000)}$");

            Console.WriteLine($"---------------------TASK2_3 ----------------------");

            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Создано {Person.GetPersonCount()} объектов класса Person...");
            Console.WriteLine("----------------------------");
            if (p1.Equals(p6)) Console.WriteLine("p1 == p6");
            else Console.WriteLine("p1 != p6");
            if (p1.Equals(p4)) Console.WriteLine("p1 == p4");
            else Console.WriteLine("p1 != p4");
            Console.WriteLine("-----------------------------");

            Console.WriteLine($"---------------------TASK_4(NO_DATA) ----------------------");
            Bank<Person> belarus = new Bank<Person>();
            Bank<Person> alfa = new Bank<Person>();
            Bank<Person> vtb = new Bank<Person>();

            belarus.Add(p1);
            belarus.Add(p2);
            belarus.Add(p3);
            alfa.Add(p2);
            alfa.Add(p3);
            alfa.Add(p4);
            vtb.Add(p3);
            vtb.Add(p4);
            vtb.Add(p5);

            Console.WriteLine($"---------------------TASK_5 ----------------------");
            Task<Person> task1 = new Task<Person>(()=>FindClient(belarus,new DateTime(2002, 5, 3)));
            Task<Person> task2 = new Task<Person>(() => FindClient(alfa, new DateTime(2004, 5, 3)));
            Task<Person> task3 = new Task<Person>(() => FindClient(vtb, new DateTime(2021, 5, 3)));
            task1.Start();
            task2.Start();
            task3.Start();
            Thread.Sleep(3000);
            Task.WaitAll(task1, task2, task3);
            Console.WriteLine($"Tasks finished, results:{task1.Result},{task2.Result},{task3.Result}");

            Console.ReadKey();           
        }

        public static Person FindClient(Bank<Person> clients, DateTime date)
        {
            foreach(var i in clients)
            {
                if (i.Date == date) return i;
            }
            throw new Exception("Клиент не найден...");
        }
    }
}
