using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    partial class OneDimensionArray
    {
        public int Find(dynamic element)
        {
           
            for (int i = 0; i < length; ++i)
            {
                if (values[i] == element) return i;
            }
            return -1;
        }

        public int FindToEnd(dynamic element)
        {
           
            for (int i = length - 1; i >= 0; --i)
            {
                if (values[i] == element) return i;
            }
            return -1;
        }

        public int Count(dynamic element)
        {
            int sum = 0;
            
            for (int i = 0; i < length; ++i)
            {
                if (values[i] == element) sum++;
            }
            return sum;
        }

        public void PushBack(dynamic value)
        {
            
            length++;
            Array.Resize(ref values, length);
            values[length - 1] = value;
        }

        public void OwnerInfo()
        {
            Console.WriteLine($"Name: {owner.NAME}\nID: {owner.ID}\nOrganization: {owner.ORG}");
        }



        public static OneDimensionArray operator *(OneDimensionArray lhs, OneDimensionArray rhs)
        {
           
            if (lhs.Length != rhs.Length) return null;
            dynamic[] arr = new dynamic[lhs.Length];
            for (int i = 0; i < lhs.Length; ++i) arr[i] = lhs[i] * rhs[i];
            return new OneDimensionArray(arr);
        }

        public static bool operator true(OneDimensionArray arr)
        {
         
            for (int i = 0; i < arr.Length; ++i) if (arr[i] < 0) return false;
            return true;
        }

        public static bool operator false(OneDimensionArray arr)
        {
           
            for (int i = 0; i < arr.Length; ++i) if (arr[i] < 0) return true;
            return false;
        }

        public static  explicit operator int(OneDimensionArray arr)
        {
            return arr.Length;
        }

        public static bool operator ==(OneDimensionArray lhs, OneDimensionArray rhs)
        {
            
            if (lhs.Length != rhs.Length) return false;
            for (int i = 0; i < lhs.Length; ++i) if (lhs[i] != rhs[i]) return false;

            return true;
        }

        public static bool operator !=(OneDimensionArray lhs, OneDimensionArray rhs)
        {
            
            if (lhs.Length != rhs.Length) return true;
            for (int i = 0; i < lhs.Length; ++i) if (lhs[i] != rhs[i]) return true;

            return false;
        }

        public static bool operator <(OneDimensionArray lhs, OneDimensionArray rhs)
        {
            return lhs.Length < rhs.Length?true:false;
        }

        public static bool operator >(OneDimensionArray lhs, OneDimensionArray rhs)
        {
            return lhs.Length > rhs.Length ? true : false;
        }

    }
}
