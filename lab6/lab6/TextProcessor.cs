using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    class TextProcessor: Soft, Operations
    {
        public static int maxCountLines = 1024;
        

        public TextProcessor(int mem, int rm, int vMem, string nm, softType tp = softType.WORK, string devName = "Sergei Walko", int expr = 100, string lg = "WSA-2020",
            RangType rng = RangType.SENIOR):base( mem, rm, vMem, tp, nm, devName, expr, lg, rng)
        {
        }

        public bool Start()
        {
            Console.WriteLine("Start work text processor!");
            this.status = true;
            return true;
        }

        public string CurrentStatus()
        {
            if (this.status) return "Text processor working!";
            else return "Text processor off";
        }
        

        virtual public void InputText()
        {
            Console.WriteLine("Goes process text input in text processor!");
        }

        virtual public void TextRedaction()
        {
            Console.WriteLine("Goes process text redaction in text processor!");
        }

        virtual public void SearchInText()
        {
            Console.WriteLine("Goes process searching in text in text processor!");
        }

        virtual public void ChecingText()
        {
            Console.WriteLine("Goes process cheking text in text processor!");
        }

        public override string ToString()
        {
            return base.ToString() + "Type: Text Processor\n";
        }
    }
}
