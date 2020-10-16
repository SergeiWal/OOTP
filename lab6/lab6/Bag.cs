using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    abstract class Bag: Soft, Operations
    {
        protected bool result;

        public Bag(int mem, int rm, int vMem, string nm, softType tp = softType.BAG, string devName = "Sergei Walko", int expr = 100, string lg = "WSA-2020",
           RangType rng = RangType.SENIOR) : base(mem, rm, vMem,  tp, nm, devName, expr, lg, rng)
        {
        }

        virtual public bool Start()
        {
            Console.WriteLine("Virus input in system!");
            this.status = true;
            return true;
        }

        virtual public string CurrentStatus()
        {
            if (this.status) return "Virus working!";
            else return "Virus off";
        }
        virtual public void Exit()
        {
            Console.WriteLine("Virus finished his work!");
            this.status = false;
            result = true;
        }

        public override string ToString()
        {
            return base.ToString() + "Bag - application for hackers!\n";
        }

        
    }
}
