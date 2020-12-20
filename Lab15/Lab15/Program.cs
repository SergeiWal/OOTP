using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Reflection;

namespace Lab15
{
    class Program
    {
        static void Main(string[] args)
        {
            //task1
            Console.WriteLine("--------------------------------task 1-------------------------------------------");
            ProcessInfo();
            //task2
            Console.WriteLine("--------------------------------task 2-------------------------------------------");
            DomainWork();
            //task3
            Console.WriteLine("--------------------------------task 3-------------------------------------------");
            Thread thread = new Thread(writeNumber);
            thread.Start();
            Console.WriteLine("Thread №1 is " + thread.ThreadState);
            thread.Name = "numbWriter";
            Console.WriteLine("Name: " + thread.Name + "\nPriority: " + thread.Priority + "\nStatus: " + thread.ThreadState + "\nId: " + thread.ManagedThreadId);
            thread.Join();
            //task4
            Console.WriteLine("--------------------------------task 4-------------------------------------------");
            Threads trd = new Threads(10);
            trd.t1.Start();
            trd.t1.Join();
            trd.t2.Start();
            trd.t2.Join();
            Console.WriteLine();

            Threads trd1 = new Threads(10);
            trd1.t1.Start();
            trd1.t2.Start();
            trd1.t1.Join();
            trd1.t2.Join();
            Console.WriteLine();

            //task4
            Console.WriteLine("--------------------------------task 4-------------------------------------------");
            int number = 3;
            TimerCallback callback = new TimerCallback(trd.Count);
            Timer timer = new Timer(callback, number, 150, 1000);
            

            Console.Read();
        }

       
        static void writeNumber()
        {
            try
            {
                Console.WriteLine("Enter number:");
                int number = Convert.ToInt32(Console.ReadLine());
                int[] arr = new int[number];
                for(int i = 0; i<number;++i)
                {
                    arr[i] = i + 1;
                    Console.Write($"{arr[i]} ");
                    using (StreamWriter file = new StreamWriter("file.txt", true))
                    {
                        file.WriteLine(arr[i]);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void DomainWork()
        {
            try
            {
                Console.WriteLine("\nDomain work: ");
                AppDomain domain = AppDomain.CurrentDomain;
                Console.WriteLine("Name: " + domain.FriendlyName);
                Console.WriteLine("Configuration: " + domain.SetupInformation);
                Console.WriteLine("Current assemblies in domain: ");
                Assembly[] assembly = domain.GetAssemblies();
                foreach (Assembly ass in assembly)
                {
                    Console.WriteLine(ass.GetName().Name);
                }
                AppDomain domain2 = AppDomain.CreateDomain("myDomain");
                Console.WriteLine("Lab13.exe load");
                domain2.ExecuteAssembly(@"D:\GIT\OOTP\Lab13\Lab13\bin\Debug\Lab13.exe");
                AppDomain.Unload(domain2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ProcessInfo()
        {
            try
            {
                var processes = from c in Process.GetProcesses(".") orderby c.Id select c;
                foreach (var c in processes)
                {
                    Console.WriteLine("Process:");
                    Console.WriteLine("Name: " + c.ProcessName);
                    Console.WriteLine("ID: " + c.Id);
                    //Console.WriteLine("StartTime: " + c.StartTime);
                    Console.WriteLine("Current state: " + c.Responding);
                    Console.WriteLine("Priority: " + c.BasePriority);
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
