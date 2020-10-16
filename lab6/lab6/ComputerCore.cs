using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    partial class Computer<T> 
    {
     
        public void Add(T value)
        {
            if (value is Soft) software.Add(value);
        }

        public void Remove(int index, int count = 1)
        {
            for (int i = index; i < i + count; ++i) software.RemoveAt(i);
        }

        public void ConsoleOut()
        {
            foreach (var i in software) Console.WriteLine(i);
        }

        public List<T> Get()
        {
            return software;
        }

        public void Set(List<T> newvalue)
        {
            if (newvalue is Soft) software = newvalue;
        }
    }
}

