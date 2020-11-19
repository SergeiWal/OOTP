using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab11
{
    partial class Vector<T>:IEnumerable<T> where T: struct
    {
        //переменные-члены
        private T[] numbers;
        private int length; 
        private int state;
        private readonly int id;
        public const int maxsize = 232;

        static private int exampleCount = 0;

        //свойства
        public int Length
        {
            get
            {
                return length;
            }
            set
            {
                length = value;
            }
        }

        public T[] Numbers
        {
            get
            {
                return numbers;
            }
            set
            {
                numbers = new T[value.Length];
                for(int i= 0;i<value.Length;++i)
                {
                    numbers[i] = value[i];
                }
            }
        }

        public int State
        {
            get
            {
                return state;
            }
        }
        public int ID
        {
            get
            {
                return id;
            }
        }   

        //индексатор
        public T this[int index]
        {
            get => numbers[index];
            set => numbers[index] = value;
        }

        //конструкторы
        public Vector()
        {
            exampleCount++;
            id = GetHashCode();
            numbers = new T[] { };
            length = 0;
            state = 0;
        }

        public Vector(int len = 0)
        {
            exampleCount++;
            id = GetHashCode();
            if (len<maxsize)
            {
                numbers = new T[len];
                length = len;
                state = 0;
            }
            else
            {
                state = -1;
            }
            
        }

        public Vector( params T[] nmb)
        {
            exampleCount++;
            id = this.GetHashCode();
            if(nmb.Length < maxsize)
            {
                length = nmb.Length;
                numbers = new T[length];
                for (int i = 0; i < nmb.Length; ++i)
                {
                    numbers[i] = nmb[i];
                }
                state = 0;
            }
            else
            {
                state = -1;
            }
            
        }

        
        private Vector(int len, T[] numbers, int st)
        {
            this.state = st;
            id = this.GetHashCode();

            if (st==0)
            {
                this.numbers = numbers;
                this.length = len;
            }
           
        }
    }
}
