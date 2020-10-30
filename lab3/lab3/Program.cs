using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            OneDimensionArray arr1 = new OneDimensionArray(1, 2, 3, 4, 5, 6, 7);
            OneDimensionArray arr2 = new OneDimensionArray(2, -4, 3, 6, 7, 8, 9);
            OneDimensionArray arr3 = arr1 * arr2;
            if (arr1) Console.WriteLine("arr1 - true");
            if (arr2) Console.WriteLine("arr2 - true");

            Console.WriteLine((int)arr1);

            OneDimensionArray arr4 = new OneDimensionArray(1, 2, 3, 4, 5, 6, 7);
            if (arr1 == arr4) Console.WriteLine("arr1 == arr4");
            OneDimensionArray arr5 = new OneDimensionArray(1, 2, 3);
            if (arr5 < arr1) Console.WriteLine("arr5 < arr1");

            OneDimensionArray str = new OneDimensionArray("mambarumba");
            if (str.isSymbol()) Console.WriteLine("str have symbol a");

            arr2.delNegative();
            for (int i = 0; i < arr2.Length; ++i) Console.WriteLine(arr2[i]);

            Console.Read();
        }
    }
}
