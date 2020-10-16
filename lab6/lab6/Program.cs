using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Program
    {
        static void Main(string[] args)
        {
            Sapper sp1 = new Sapper(true, false, "arcada", "9.0", 235, 500, 211);
            Sapper sp2 = new Sapper(true, false, "arcada", "9.0", 235, 500, 211);


            CConficer tr = new CConficer(235, 500, 211);
            Word wd = new Word(900, 235, 500, 211);

            Game gm1 = new Game(true, false, "strategy", "5.0", 235, 500, 211, "Command&Conguer");
            TextProcessor wordPd = new TextProcessor(235, 500, 211, "WordPad");

            Computer<Soft> pc = new Computer<Soft>();
            pc.Add(sp1);
            pc.Add(sp2);
            pc.Add(tr);
            pc.Add(wd);
            pc.Add(gm1);
            pc.Add(wordPd);




            ComputerManager.AbcOut(pc);
            ComputerManager.SearchGame(pc, "strategy");
            ComputerManager.SearchTextProcessor(pc);
            Console.Read();
        }
    }
}
