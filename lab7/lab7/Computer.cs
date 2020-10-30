using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    partial class Computer
    {
        private List<Soft> software;
        private Hardware hard;

        public Computer()
        {
            software = new List<Soft>();
            hard = new Hardware(4096, 500, 2, "Intel Core i-3", "NVIDIA");
        }

        public int Length
        {
            get
            {
                return software.Count;
            }
        }

        public Hardware Hard
        {
            get
            {
                return hard;
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
