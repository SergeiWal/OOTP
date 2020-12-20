using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Lab14
{
    [Serializable]
    [DataContract]
    public sealed class Sapper : Game
    {
        [NonSerialized]
        [DataMember]
        public int fieldSize;

        [DataMember]
        public int HardestLevel;
       
        public Sapper() { }
        

        public Sapper(bool off, bool online, string gnr, string direct, int mem, int rm, int vMem, string nm = "Sapper", softType tp = softType.GAME, string devName = "Sergei Walko", int expr = 100,
            string lg = "WSA-2020", RangType rng = RangType.SENIOR) : base(off, online, gnr, direct, mem, rm, vMem,  nm, tp, devName, expr, lg, rng)
        {
        }


        public override bool Start()
        {
            this.Menu();
            this.status = true;
            Console.WriteLine("Hello, please click in play!");
            Console.WriteLine("Okey, input field size and hard level!");
            fieldSize = Convert.ToInt32(Console.ReadLine());
            HardestLevel = Convert.ToInt32(Console.ReadLine());
            this.GameLoop();
            return true;
        }

        public void Win()
        {
            Console.WriteLine("You win");
        }

        public override string ToString()
        {
            return base.ToString() + "Sapper is game for crazy man!!!!\n";
        }
    }
}
