using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
     partial class Vector
    {
        //методы
        public int getID()
        {
            return id;
        }
        public void multiplication(int value)
        {
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] *= value;
            }
        }
        public void multiplication(int pos, int value)
        {
            numbers[pos] *= value;
        }

        public void add(int value)
        {
            for (int i = 0; i < numbers.Length; ++i)
            {
                numbers[i] += value;
            }
        }
        public void add(int pos, int value)
        {
            numbers[pos] += value;
        }
        public object Clone()
        {
            return new Vector(length, numbers, state);
        }

        public void Copy(ref int[] vc)
        {
            vc = new int[numbers.Length];
            foreach (int i in numbers) vc[i] = numbers[i];
        }

        public bool IsNullInVector()
        {
            for(int i =0; i<length;++i)if (numbers[i] == 0) return true;
            
            return false;
        }

        public int absoluteValueForVector()
        {
            int sum = 0;
            for (int i = 0; i < length; i++) sum += numbers[i] * numbers[i];
            return (int)Math.Sqrt(sum);
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

        public override bool Equals(object obj)
        {
           if(obj is Vector && obj!=null)
            {
                Vector vc;
                vc = (Vector)obj;
                if (vc.length != this.length) return false;
                for (int i =0; i<vc.length; ++i)
                {
                    if (vc[i] != this[i]) return false;
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        

    }
}
