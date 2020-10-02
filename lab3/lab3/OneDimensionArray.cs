using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    partial class  OneDimensionArray
    {
        private dynamic[] values;
        private int length;
        private Owner owner;
        private Date date;

        public OneDimensionArray()
        {
            owner = new Owner();
            date = new Date();
            values = new dynamic[] { };
            length = 0;
        }

        public OneDimensionArray(params dynamic[] arr)
        {
            owner = new Owner();
            date = new Date();
            length = arr.Length;
            values = new dynamic[length];
            for (int i = 0; i < length; ++i) values[i] = arr[i];
        }

        public OneDimensionArray(string str)
        {
            owner = new Owner();
            date = new Date();
            length = str.Length;
            values = new dynamic[length];
            for (int i = 0; i < length; ++i) values[i] = str[i];
        }

        public OneDimensionArray(int ln)
        {
            owner = new Owner();
            date = new Date();
            if (ln<0)
            {
                Console.WriteLine("Введён не верный размер массива!");
                Environment.Exit(-1);
            }
            length = ln;
            values = new dynamic[ln];
        }


        public int Length
        {
            get
            {
                return length;
            }
        }

        public dynamic[] Values
        {
            get
            {
                return values;
            }
            set
            {
                values = value;
                length = values.Length;
            }
        }

        public dynamic this[int index]
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
