using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Collections.Concurrent;

namespace Lab16
{
    class Program
    {
        static void Main(string[] args)
        {
            //task1
            int[,] mtx1 = new int[,]{ { 1,2,3}, {4,6,6 }, { 5,9,7} };
            int[,] mtx2 = new int[,] { { 2, 11 }, { 7, 9 }, { 8, 7 } };
            Console.WriteLine("Matrix A:");
            PrintMatrix(mtx1);
            Console.WriteLine("Matrix B:");
            PrintMatrix(mtx2);
            Stopwatch stopw = new Stopwatch();

            Task task1 = new Task(() => {
                Console.WriteLine($"Current task id: {Task.CurrentId}");
                Console.WriteLine("Matrix C:");
                var newMAtrix = MatrixMul(mtx1, mtx2);
                PrintMatrix(newMAtrix);
            });
            Console.WriteLine(" ----------------------- Task1 -----------------------------");
            Console.WriteLine($"IsCompleted: {task1.IsCompleted}");
            Console.WriteLine($"Status:{task1.Status}");
            stopw.Start();
            task1.Start();
            Console.WriteLine($"IsCompleted: {task1.IsCompleted}");
            Console.WriteLine($"Status:{task1.Status}");
            task1.Wait();
            stopw.Stop();
            Console.WriteLine($"Time:{stopw.ElapsedMilliseconds} ms");

            //task 2
            Console.WriteLine(" ----------------------- Task2 -----------------------------");
            var cst = new CancellationTokenSource();
                var token = cst.Token;

                Task task2 = new Task(() => {
                    try
                    {
                        if (token.IsCancellationRequested)
                        {
                            throw new OperationCanceledException(token);
                        }
                        else
                        {
                            Console.WriteLine($"Current task id: {Task.CurrentId}");
                            Console.WriteLine("Matrix C:");
                            var newMAtrix = MatrixMul(mtx1, mtx2);
                            PrintMatrix(newMAtrix);
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    
                });

                task2.Start();
                cst.Cancel();
                task2.Wait();

            //task 3
            Console.WriteLine(" ----------------------- Task3 -----------------------------");
            Task<Int32> t1 = new Task<int>((n)=>Sum((int)n),18);
            Task<Int32> t2 = new Task<int>((n) => Sum((int)n), 1000);
            Task<Int32> t3 = new Task<int>((n) => Sum((int)n), 123);
            t1.Start();
            t2.Start();
            t3.Start();
            Task.WaitAll();

            Task t4 = Task.Run(()=> {
                int result = 0;
                result += t1.Result + t2.Result + t3.Result;
                Console.WriteLine($"Task 3 result: {result}");
               
            });

            //task 4
            Console.WriteLine(" ----------------------- Task4 -----------------------------");
            //1
            //Task.WaitAll(t1, t2, t3, t4);
            var cwt = t1.ContinueWith(task => {
                Console.WriteLine($"t1 result: {t1.Result}");
            });

            //2
            var i = t2.GetAwaiter().GetResult();
            Console.WriteLine("t2 result:" + i);


            //task 5
            Console.WriteLine(" ----------------------- Task5 -----------------------------");
            Task.WaitAll(t1,t2,t3,t4);
            Console.WriteLine("For:");
            forStandart();
            forParalell();
            Console.WriteLine("ForEach:");
            foreachStandart();
            foreachParalell();

            //task 6
            Console.WriteLine(" ----------------------- Task6 -----------------------------");
            Task.WaitAll(t1, t2, t3, t4);
            Parallel.Invoke(
                ()=>ArrayGeneration(10000),
                ()=>ArrayGeneration(1000),
                ()=>ArrayGeneration(100000));
            //task 7
            try
            {
                bool flag = false;
                BlockingCollection<string> assortment = new BlockingCollection<string>();
                Task prod = new Task(()=> { Producer.producerWork(ref assortment, ref flag, "product"); });
                Task shop = new Task(() => { Shopper.shopperWork(ref assortment, ref flag); });
                prod.Start();
                shop.Start();
                Thread.Sleep(3000);
                //task8
                Task.WaitAll(prod, shop);
                Console.WriteLine(" ----------------------- Task6 -----------------------------");
                FactorialAsync(4);
                Console.Read();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
           
        }

        //факториал 
        static void Factorial(int x)
        {
            int result = 1;
            for (int i = 1; i <= x; i++)
            {
                result *= i;
            }
            Thread.Sleep(8000);
            Console.WriteLine($"Факториал от {x} равен: {result}");
        }
        // определение асинхронного метода
        static async void FactorialAsync(int x)
        {
            Console.WriteLine("Начало метода FactorialAsync"); // выполняется синхронно
            await Task.Run(() => Factorial(x));                // выполняется асинхронно
            Console.WriteLine("Конец метода FactorialAsync");
        }

        public static void ArrayGeneration(int size)
        {
            int[] a = new int[size];
        }
        public static void forStandart()
        {
            Stopwatch stopw = new Stopwatch();
            stopw.Start();

            for (int i = 0; i < 1000; ++i)
                ArrayGeneration(i);
            stopw.Stop();
            Console.WriteLine($"Time standart: {stopw.ElapsedMilliseconds} ms");
        }

        public static void forParalell()
        {
            Stopwatch stopw = new Stopwatch();
            stopw.Start();

            Parallel.For(0, 100000,  i => ArrayGeneration(i));
            stopw.Stop();
            Console.WriteLine($"Time paralell: {stopw.ElapsedMilliseconds} ms");
        }
        public static void foreachStandart()
        {
            Stopwatch stopw = new Stopwatch();
            int[] a = new int[1000000];
            stopw.Start();
            foreach (var i in a) ArrayGeneration(1000);
            stopw.Stop();
            Console.WriteLine($"Time standart: {stopw.ElapsedMilliseconds} ms");
        }

        public static void foreachParalell()
        {
            Stopwatch stopw = new Stopwatch();
            int[] a = new int[1000000];
            stopw.Start();
            Parallel.ForEach(a, ArrayGeneration);
            stopw.Stop();
            Console.WriteLine($"Time paralell: {stopw.ElapsedMilliseconds} ms");
        }

        public  static Int32 Sum(Int32 n)
        {  
            Int32 sum = 0;
            for (; n > 0; n--)  
                checked { sum += n; }
            Thread.Sleep(2000);
            return sum; 
        } 

        static public int[,] MatrixMul(int[,] m1, int[,] m2)
        {
            if (m1.GetUpperBound(1) + 1 != m2.GetUpperBound(0) + 1)
                throw new Exception("Не совпадают колво строк и столбцов в перемнажаемых матрицах!");

            var newMatrix = new int[m1.GetUpperBound(0) + 1, m2.GetUpperBound(1) + 1];

            for (var i = 0; i < m1.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < m2.GetUpperBound(1) + 1; j++)
                {
                    newMatrix[i, j] = 0;

                    for (var k = 0; k < m1.GetUpperBound(1) + 1; k++)
                    {
                        newMatrix[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return newMatrix;
        }

        static public void PrintMatrix(int[,] m1)
        {
            for (var i = 0; i < m1.GetUpperBound(0) + 1; i++)
            {
                for (var j = 0; j < m1.GetUpperBound(1) + 1; j++)
                {
                    Console.Write(m1[i, j].ToString().PadLeft(4));
                }

                Console.WriteLine();
            }
        }
    }
}
