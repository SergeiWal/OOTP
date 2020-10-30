using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace lab7
{
    sealed class Word: TextProcessor
    {
        private int LineCount;

        public Word(int maxLine, int mem, int rm, int vMem, string nm = "Word", softType tp = softType.WORK, string devName = "Sergei Walko", int expr = 100,
            string lg = "WSA-2020", RangType rng = RangType.SENIOR):base( mem, rm, vMem, nm, tp, devName, expr, lg, rng)
        {
            if (LineCount > maxCountLines) LineCount = maxCountLines;
            else LineCount = maxLine;
        }

        public override void InputText()
        {
            Console.WriteLine("Goes process text input in Word application!");
        }

        public override void ChecingText()
        {
            Console.WriteLine("Goes process text checking in Word application!");
        }

        public override void SearchInText()
        {
            Console.WriteLine("Goes process searching in text  in Word application!");
        }
        public override void TextRedaction()
        {
            Console.WriteLine("Goes process text redaction in Word application!");
        }

        public override string ToString()
        {
            return base.ToString() + "Word id desktop application for home and office work";
        }
    }
}
