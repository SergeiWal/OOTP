using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Lab11
{
    partial class Vector<T> : IEnumerable<T> where T : struct
    {
        //методы
        public int getID()
        {
            return id;
        }
       
        public object Clone()
        {
            return new Vector<T>(length, numbers, state);
        }


        public static void MaxValue(out int maxValue, params int[] number)
        {
            maxValue = number[0];
            foreach (int i in number) if (i > maxValue) maxValue = i;
        }

        public static void Info()
        {
            Console.WriteLine("Класс Vector: содержит массив целых чисел, его длину, статус и методы работы с числовым вектором!");
        }

        //переопределение некаторых стандартных методов

        public override string ToString()
        {
            StringBuilder str = new StringBuilder("type<lab2.Vector> value<[");
            for (int i =0;i< length;++i) str.Append(numbers[i]);
            str.Append("]>");
            return str.ToString();
        }

        //public override bool Equals(object obj)
        //{
        //   if(obj is Vector<T> && obj!=null)
        //    {
        //        Vector<T> vc;
        //        vc = (Vector<T>)obj;
        //        if (vc.length != this.length) return false;
        //        for (int i =0; i<vc.length; ++i)
        //        {
        //            if (vc[i] != this[i]) return false;
        //        }
        //        return true;
        //    }
        //    return false;
        //}
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)numbers).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return numbers.GetEnumerator();
        }
    }
}
