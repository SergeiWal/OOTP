using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    partial class Computer
    {
     
        public void Add(Soft value)
        {
            HardwareExeption.HardwareChrcking(this, value);
            MaliciousSoftware.IsVirus(value);
            software.Add(value);
        }

        public void Remove(int index, int count = 1)
        {
            for (int i = index; i < i + count; ++i) software.RemoveAt(i);
        }

        public void ConsoleOut()
        {
            foreach (var i in software) Console.WriteLine(i);
        }

        public List<Soft> Get()
        {
            return software;
        }

        public void Set(List<Soft> newvalue)
        {
            foreach(var i in newvalue)
            {
                HardwareExeption.HardwareChrcking(this, i);
                MaliciousSoftware.IsVirus(i);
            }
            software = newvalue;
        }
    }
}

