using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CollectionType<int> icoll = new CollectionType<int>();
                Console.WriteLine("Please, enter a count new element to int collection:");
                int count = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < count; ++i) icoll.AddElement(Convert.ToInt32(Console.ReadLine()));

                CollectionType<string> scoll = new CollectionType<string>();
                Console.WriteLine("Please, enter a count new element to string collection:");
                count = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < count; ++i) scoll.AddElement(Console.ReadLine());

                CollectionType<double> dcoll = new CollectionType<double>();
                Console.WriteLine("Please, enter a count new element to int collection:");
                count = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < count; ++i) dcoll.AddElement(Convert.ToDouble(Console.ReadLine()));

               

                Sapper sp1 = new Sapper(true, false, "arcada", "9.0", 235, 500, 211);
                Sapper sp2 = new Sapper(true, false, "arcada", "9.0", 235, 500, 211);

                CollectionType<Sapper> spcoll = new CollectionType<Sapper>(sp1, sp2);

                spcoll.WriteInFile();
                //icoll.WriteCollection();
                //scoll.WriteCollection();
                //dcoll.WriteCollection();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("----THE END----");
                Console.WriteLine("Enter random buttom for exit...");
                Console.ReadLine();
            }
        }
    }
}
