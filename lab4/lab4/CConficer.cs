using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{
    sealed class CConficer: Bag
    {

        private int ipPCforAtaccing;

        public CConficer(int mem, int rm, int vMem, string nm = "CConficer", softType tp = softType.BAG, string devName = "Sergei Walko", int expr = 100, string lg = "WSA-2020",
           RangType rng = RangType.SENIOR) : base(mem, rm, vMem, nm, tp, devName, expr, lg, rng)
        {
        }

        public override bool Start()
        {
            Console.WriteLine("Input Ip PC for atacing!");
            ipPCforAtaccing = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("He-he, im crooking file in this PC!");
            this.status = true;
            return true;
        }

        public override string ToString()
        {
            return base.ToString() + "CConficer crooked info from Pc\n";
        }
    }
}
