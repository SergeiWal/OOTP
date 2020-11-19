using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    static class SpecMethods
    {
        public static int AbsolyteValue(this Vector<int> vc)
        {
            int value = 0;
            foreach (int i in vc) value += i;
            value /= vc.Length;
            return value;
        }

        public static bool isMinus(this Vector<int> vc)
        {
            foreach (var i in vc)
                if (i < 0) return true;
            return false;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            //--------------------------------------------task 1-----------------------------------------------------------
            //part 1
            string[] months = {"January","February","March","April","May",
                "June", "Jule","August","September","October","November","Decenber" };

            int n;
            Console.WriteLine("Enter once namber:");
            n = Convert.ToInt32(Console.ReadLine());
            var nLineMonth = from c in months where c.Length == n select c;
            foreach (var i in nLineMonth) Console.WriteLine(i);
            Console.WriteLine();

            //part2
            string[] winterMonths = { "Decenber", "January", "February" };
            string[] summerMonths = { "June", "Jule", "August" };
            var winterAndSommerMonths = from c in months where Array.IndexOf(winterMonths, c) != -1 ||
                                        Array.IndexOf(summerMonths, c) != -1 select c;
            foreach (var i in winterAndSommerMonths) Console.WriteLine(i);
            Console.WriteLine();

            //part3
            var ABCmonths = from c in months orderby c select c;
            foreach (var i in ABCmonths) Console.WriteLine(i);
            Console.WriteLine();

            //part4
            var uFourMonths = from c in months where c.Contains("u") && c.Length >= 4 select c;
            foreach (var i in uFourMonths) Console.WriteLine(i);
            Console.WriteLine();

            //---------------------------------------------------- task 2 and task3 ---------------------------------------


            List<Vector<int>> vectorList = new List<Vector<int>> { new Vector<int>(1,2,3,4,5),new Vector<int>(0,1,0,11,1),new Vector<int>(9,-4,4,5),
                                   new Vector<int>(4,-3,5,21,9), new Vector<int>(1,2,11,1,34), new Vector<int>(2,3,4,5), new Vector<int>(2,0),
                                   new Vector<int>(-1,-2,-3), new Vector<int>(9,9,9,9,9,9,9)};

            //query1
            var countNullVector = from c in vectorList where c.Contains(0) select c;
            foreach(var i in countNullVector)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            //query2
            var minModule = (from c in vectorList select SpecMethods.AbsolyteValue(c)).Min();
            var minModuleVectors = from c in vectorList where SpecMethods.AbsolyteValue(c) == minModule select c;
            foreach (var i in minModuleVectors)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            //query3
            var fixedLengthVectors = vectorList.Where(p=>p.Length==3|| p.Length == 5|| p.Length == 7);
            foreach (var i in fixedLengthVectors)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            //query4(a)
            var maxLen = (from c in vectorList select c.Length).Max();
            var maxVector1 = from c in vectorList where c.Length == maxLen select c;
            foreach (var i in maxVector1)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            //query4(b)
            //var maxModule = (from c in vectorList select SpecMethods.AbsolyteValue(c)).Max();
            //var maxVector2 = from c in vectorList where SpecMethods.AbsolyteValue(c) == maxModule select c;
            //foreach (var i in maxVector2)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine();

            //query5
            var firstMinusVector = vectorList.First(p=>SpecMethods.isMinus(p));
            foreach (var i in firstMinusVector)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            //query6
            var sortVector = vectorList.OrderBy(p=>p.Length);
            foreach (var i in sortVector)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //------------------------------------task4------------------------------------------------

            var megaQuery = (from c in vectorList where c.Contains(0) || c.Contains(1) select c).OrderBy(p => p[0]).Take(2);
            foreach (var i in megaQuery)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //------------------------------------task5------------------------------------------------

            int[] number = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

            var result = vectorList.Join(number, p => p.Length, s => s, (p, s) => new { arr = p, len = s });
            foreach (var i in result)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
