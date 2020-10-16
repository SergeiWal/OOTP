using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    partial class Computer<T> 
    {
        private List<T> software;
        private Hardware hard;

        public Computer()
        {
            software = new List<T>();
            hard = new Hardware(4096, 500, 2, "Intel Core i-3", "NVIDIA");
        }

        public int Length
        {
            get
            {
                return software.Count;
            }
        }

    }

    struct Hardware
    {    
        public int RAM { get; set; }
        public int Memory { get; set; }
        public int  VideoMemory { get; set; }
        public string CPU { get; set; }
        public string GraphicAdapter { get; set; }

        public Hardware(int rm, int mem, int vm, string cpu, string ga)
        {
            RAM = rm;
            Memory = mem;
            VideoMemory = vm;
            CPU = cpu;
            GraphicAdapter = ga;
        }
    }

}
