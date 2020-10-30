using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    enum softType { WORK, GAME, BAG };
    abstract class  Soft
    {
        private string name;
        private int memory;
        private int ram;
        private int videoMemory;
        private softType type;
        private Developer dev;
        protected bool status;

        public Soft( int mem, int rm, int vMem, softType tp, string nm, string devName = "Sergei Walko", int expr = 100, string lg = "WSA-2020", RangType rng = RangType.SENIOR)
        {
            name = nm;
            memory = mem;
            ram = rm;
            videoMemory = vMem;
            type = tp;
            dev = new Developer(devName, expr, lg, rng);
            status = false;
        } 

        public string Name
        { 
            get
            {
                return name;
            }
        }

        public int Memory
        {
            get
            {
                return memory;
            }
        }

        public int RAM
        {
            get
            {
                return ram;
            }
        }

        public int VideoMemory
        {
            get
            {
                return videoMemory;
            }
        }

        public softType Type
        {
            get
            {
                return type;
            }
        }


        public string GetDevoloperInfo()
        {
            return dev.ToString();
        }

        virtual public void Exit()
        {
            Console.WriteLine("Soft application off");
        }

        public override string ToString()
        {
            return "Soft name: " + Name + "\n" + "Memory:" + Memory + "\nRAM: " + RAM + "\n" + dev.ToString() + "\n";
        }

        public override bool Equals(object obj)
        {
            if (obj is Soft && obj != null)
            {
                Soft temp = (Soft)obj;
                if (temp.Name == this.Name && temp.Type == this.Type) return true;
                else return false;
            }
            else
                return false;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
