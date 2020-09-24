using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            // базовые типы
            bool bl = true;
            byte bt = 1;
            sbyte sb = 2;
            char ch = 'a';
            decimal dc = 1.234m;
            double db = 3.14;
            float fl = 5.1345f;
            int it = -3;
            uint uit = 3;
            long lg = 1243254612343434;
            ulong ulg = 1431432;
            short sh = -13;
            ushort ush = 13;

            Console.WriteLine("System.Boolean:" + bl);
            Console.WriteLine("System.Byte:" + bt);
            Console.WriteLine("System.SByte:" + sb);
            Console.WriteLine("System.Char:" + ch);
            Console.WriteLine("System.Decimal:" + dc);
            Console.WriteLine("System.Double:" + db);
            Console.WriteLine("System.Single:" + fl);
            Console.WriteLine("System.Int32:" + it);
            Console.WriteLine("System.UInt32:" + uit);
            Console.WriteLine("System.Int64:" + lg);
            Console.WriteLine("System.UInt64:" + ulg);
            Console.WriteLine("System.Int16:" + sh);
            Console.WriteLine("System.UInt16:" + ush);

            //преобразование типов
            //неявное
            lg = it;
            db = fl;
            fl = it;
            it = sh;
            sh = bt;
            //явное
            dc = (decimal)db;
            uit = (uint)it;
            lg = (long)ulg;
            ush = (ushort)sh;
            it = (int)db;
            bl = Convert.ToBoolean(bt);

            //упаковка и распаковка
            Int32 value1 = 10;
            Int16 value2 = 11;
            Double value3 = 12.1;
            Object link1 = value1;
            Object link2 = value2;
            Object link3 = value3;

            byte resultValue1 = (byte)(int)link1;
            byte resultValue2 = (byte)(short)link2;
            float resultValue3 = (float)(double)link3;

            //var
            var value = 10;
            value += 10;
            var number = 12.3;
            var str = "sdfdf";

            //nullable
            string word;
            word = null;
            int? vl = null;

            //F
            //var randomValue = 10;
            //randomValue = 123.4545;

            ////////////////////////////Part2////////////////////////////////////

            //if (name == lastName) Console.WriteLine("LastName == Name");
            if (String.Equals("POIT", "ISIT")) Console.WriteLine("true");

            string name = "Sergei";
            string lastName = "Walko";
            string city = "Minsk";
            string st = null;

            string myAbsolyteName = name + lastName; //конкатенация
            st = String.Copy(city);
            int begin = myAbsolyteName.IndexOf(name);
            int end = myAbsolyteName.LastIndexOf(name);

            string miniText = "Hello, World!";
            string[] words = miniText.Split(new char[] { ' ', ',' });
            


            myAbsolyteName = myAbsolyteName.Insert(0, "Serg");
            myAbsolyteName = myAbsolyteName.Replace(lastName, "");

            miniText = $"I'm live in {city}";

            string nullString = null;
            string EmptyString = "";
            if (string.IsNullOrEmpty(nullString)) Console.WriteLine("null string");
            if (string.IsNullOrEmpty(EmptyString)) Console.WriteLine("empty string");

            StringBuilder sbString = new StringBuilder("Laboratorian Work");
            sbString.Remove(2, 1);
            sbString.Remove(7, 1);
            sbString.AppendLine(" 18.09.20");
            sbString.Insert(0, "№2 ");
            Console.WriteLine(sbString);

            /////////////////////PART3////////////////////////////
            int[,] myMatrix;
            myMatrix = new int[4, 4];

            //input matrix
            for(int i =0;i<4;++i)
            {
                for(int j=0;j<4; ++j)
                {
                    myMatrix[i, j] = i * j;
                }
            }

            //output matrix
            Console.WriteLine("My Matrix:");
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    Console.Write(myMatrix[i, j]);
                }
                Console.Write("\n");
            }

            //string array

            string[] strArray = new string[] { "Sergei", "Walko", "Alexandrovich","18","student" };

            Console.WriteLine($"String array:\nhis, length:{strArray.Length}");
            for(int i =0;i<strArray.Length;++i)
            {
                Console.Write(strArray[i] + " ");
            }
            Console.WriteLine("\nВведите позицию заменяемого элемента и значение:");
            int pos = Convert.ToInt32(Console.ReadLine());
            string newWord = Console.ReadLine();
            strArray[pos] = newWord;
            Console.WriteLine("New string:");
            for (int i = 0; i < strArray.Length; ++i)
            {
                Console.Write(strArray[i] + " ");
            }

            //зубчатый массив
            double[][] jagArray = new double[3][];

            jagArray[0] = new double[2];
            jagArray[1] = new double[3];
            jagArray[2] = new double[4];

            Console.WriteLine("\nPlease,input value:");
            for(int i =0;i<jagArray.Length;++i)
            {
                for(int j =0;j<jagArray[i].Length;++j)
                {
                    jagArray[i][j] = Convert.ToDouble(Console.ReadLine());
                }
            }


            Console.WriteLine("JagArray:");
            for (int i = 0; i < jagArray.Length; ++i)
            {
                for (int j = 0; j < jagArray[i].Length; ++j)
                {
                    Console.Write(jagArray[i][j]);
                }
                Console.WriteLine();
            }

            var arr = jagArray;
            var strX = strArray[0];


            //////////////////////PART4///////////////////////
            (int, string, char, string, ulong) values = (4, "kort", 'c', "FFFF", 124);
            Console.WriteLine(values);
            Console.WriteLine(values.Item1 + " " + values.Item3 + " " + values.Item5);

            //распаковка
            string s1 = values.Item2;
            //
            (var a, var b, var c, var d, var e) = values;
            (var a2, _, var c2, var d2, var e2) = values;

            (int, string, char, string, ulong) srsf = (4, "kort", 'c', "FFFF", 124);
            if (values == srsf) Console.WriteLine("true");

            ////////////PART5////////////////////
            (int, int, int, char) vls = LocalFunction(new int[]{1,4,5,2,2 },"name");
            Console.WriteLine(vls);

            ////////////////////PART6///////////////////////////
            UnCheckFunction();
            CheckFunction();
            
            Console.ReadLine();
        }

        static (int,int,int,char) LocalFunction(int[] arr, string str)
        {
            Array.Sort(arr);
            int maxEl = arr[arr.Length - 1];
            int minEl = arr[0];
            int sum = 0;
            for(int i =0;i<arr.Length;++i)
            {
                sum += arr[i];
            }
            return (maxEl, minEl, sum, str[0]);
        }

        static void CheckFunction()
        {
            checked
            {
                int max = 2147483647;
            }
        }

        static void UnCheckFunction()
        {
            unchecked
            {
                int max = 2147483647;
            }
        }
    }
}
