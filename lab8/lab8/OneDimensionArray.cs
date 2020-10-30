using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    partial class CollectionType<T> : IGenericCollection<T> //where T: class
    {
        private List<T> values;
        private int length;
        private Owner owner;
        private Date date;



        public CollectionType()
        {
            owner = new Owner();
            date = new Date();
            values = new List<T> { };
            length = 0;
        }

        public CollectionType(params T[] arr)
        {
            owner = new Owner();
            date = new Date();
            length = arr.Length;
            values = new List<T> ();
            for (int i = 0; i < length; ++i) values.Add(arr[i]);
        }


        public CollectionType(int ln)
        {
            owner = new Owner();
            date = new Date();
            if (ln<0)
            {
                Console.WriteLine("Введён не верный размер массива!");
                Environment.Exit(-1);
            }
            length = ln;
            values = new List<T>(ln);
        }


        public int Length
        {
            get
            {
                return length;
            }
        }

        public  List<T> Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
                length = values.ToArray().Length;
            }
        }

        public T this[int index]
        {
            get => values[index];
            set
            {
                if ((value.GetType() == values[index].GetType() && value.GetType() == values[index - 1].GetType()) || index == 0)
                    values[index] = value;
            }
        }


    }
}
