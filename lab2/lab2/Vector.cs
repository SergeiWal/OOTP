using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace lab2
{
    partial class Vector
    {
        //переменные-члены
        private int[] numbers;
        private int length;
        private int state;
        private readonly int id;
        public const int maxsize = 232;

        static private int defaultValue;
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

        public int[] Numbers
        {
            get
            {
                return numbers;
            }
            set
            {
                numbers = new int[value.Length];
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
        public static int DefaultValue
        {
            get
            {
                return defaultValue;
            }
            set
            {
                defaultValue = value;
            }
        }
        

        //индексатор
        public int this[int index]
        {
            get => numbers[index];
            set => numbers[index] = value;
        }




        //конструкторы
        public Vector()
        {
            exampleCount++;
            id = this.GetHashCode();
            numbers = new int[] { };
            length = 0;
            state = 0;
        }

        public Vector(int len = 0)
        {
            exampleCount++;
            id = this.GetHashCode();
            if (len<maxsize)
            {
                numbers = new int[len];
                for (int i = 0; i < len; ++i)
                {
                    numbers[i] = defaultValue;
                }
                length = len;
                state = 0;
            }
            else
            {
                state = -1;
            }
            
        }

        public Vector( params int[] nmb)
        {
            exampleCount++;
            id = this.GetHashCode();
            if(nmb.Length < maxsize)
            {
                length = nmb.Length;
                numbers = new int[length];
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

        static Vector()
        {
            defaultValue = 0;
        }
        
        private Vector(int len, int[] numbers, int st)
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
