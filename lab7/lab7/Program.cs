using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            FileLogger flg = new FileLogger();
            ConsoleLogger clg = new ConsoleLogger();

           
            try
            {
                Sapper sp1 = new Sapper(true, false, "arcada", "9.0", 235, 500, 211);
                Sapper sp2 = new Sapper(true, false, "arcada", "9.0", 235, 500, 211);


                CConficer tr = new CConficer(235, 500, 211);
                Word wd = new Word(900, 235, 500, 211);

                Game gm1 = new Game(true, false, "strategy", "5.0", 235, 500, 211, "Command&Conguer");
                TextProcessor wordPd = new TextProcessor(235, 500, 211, "WordPad");

                Computer pc = new Computer();
                pc.Add(sp1);
                pc.Add(sp2);
                //pc.Add(tr);
                pc.Add(wd);
                pc.Add(gm1);
                pc.Add(wordPd);


               //Debug.Assert(sp1 == null, "Debager hello!");

                ComputerManager.AbcOut(pc);
                ComputerManager.SearchGame(pc, "strategy");
                ComputerManager.SearchTextProcessor(pc);
                clg.LogInput("Good work - null exception!");
                flg.LogInput("Good work - null exception!");

            }
            catch(HardwareExeption e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.HelpLink);
                //clg.LogInput(e.Message);
                flg.LogInput(e.Message);
            }
            catch(MaliciousSoftware e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.HelpLink);
                //clg.LogInput(e.Message);
                flg.LogInput(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                //clg.LogInput(e.Message);
                flg.LogInput(e.Message);
            }
            finally
            {
                Console.WriteLine("*****7lab<Exception>*****");
                Console.WriteLine("*****Enter random buttom for exit programm*****");
                Console.ReadKey();
                //clg.LogInput("------THE END-----");
                flg.LogInput("------THE END-----");
            }
        }
    }
}
