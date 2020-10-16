using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    static class StatisticOperation
    {
        public static int max(OneDimensionArray arr)
        { 
            int max = arr[0];
            for (int i = 0;i<arr.Length;++i)
            {
                 if (arr[i] > max) max = arr[i];
            }
            
            return max;
        }

        public static int min(OneDimensionArray arr)
        {  
            int min = arr[0];
            for (int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] < min) min = arr[i];
            }
            
            return min;
        }

        public static dynamic Sum(OneDimensionArray arr)
        {
            if (arr.Length == 0) return null;
            dynamic result = arr[0];
            for (int i = 1; i < arr.Length; ++i) result += arr[i];
            return result;
        }

        public static int Diference(OneDimensionArray arr)
        {
           
            return max(arr) - min(arr);
        }

        public static int Count(OneDimensionArray arr)
        {
            return arr.Length;
        }

        public static bool isSymbol(this OneDimensionArray str)
        {
            for (int i = 0; i < str.Length; ++i) if (str[i] == 'a') return true;
            return false;
        }

        public static void delNegative(this OneDimensionArray arr)
        {
            int j = 0;
            dynamic[] newArr = new dynamic[arr.Length];
            for(int i = 0; i < arr.Length; ++i)
            {
                if (arr[i] >= 0)
                {
                    newArr[j] = arr[i];
                    j++;
                }
            }
            Array.Resize(ref newArr, j);
            arr.Values = newArr;
        }
    }
}
