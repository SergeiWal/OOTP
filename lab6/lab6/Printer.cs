using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class Printer
    {
        virtual public  void IAmPrinting(Soft sft)
        {
            if(sft is Game)
            {
                Console.WriteLine("This soft is Game!");
                if(sft is Sapper) Console.WriteLine("And this soft is Sapper!");
                

            }
            else if (sft is TextProcessor)
            {
                Console.WriteLine("This soft is TextProcessor!");
                if (sft is Word) Console.WriteLine("And this soft is Word!");
            }
            else if(sft is Bag)
            {
                Console.WriteLine("This soft is Virus!");
                if (sft is CConficer) Console.WriteLine("And this soft is CConficer!");
            }
            Console.WriteLine(sft.ToString());
        }

    }
}
