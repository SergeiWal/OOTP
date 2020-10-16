using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab4
{

    class Program
    {
        static void Main(string[] args)
        {
            Sapper sp1 = new Sapper(true, false, "arcada", "9.0", 235, 500, 211);
            Sapper sp2 = new Sapper(true, false, "arcada", "9.0", 235, 500, 211);


            CConficer tr = new CConficer(235, 500, 211);
            Word wd = new Word(900, 235, 500, 211);

            wd.Start();
            Console.WriteLine(wd.CurrentStatus());
            wd.Exit();

            sp1.Start();
            Console.WriteLine(sp2.CurrentStatus());
            sp1.Exit();

            tr.Start();
            tr.Exit();
           

            Console.WriteLine("\n" + sp2.ToString());

            if (sp1 is Game) Console.WriteLine("sp1 is game");
            if(wd is Game ) Console.WriteLine("wd is game");
            else Console.WriteLine("wd not is game");


            Printer prt = new Printer();
            Object[] arr = { sp1, sp2, wd, tr, prt };
            foreach(var i in arr)
            {
                if (i is Soft) ((Printer)arr[4]).IAmPrinting((Soft)i);
            }

            Console.Read();
        }
    }
}
