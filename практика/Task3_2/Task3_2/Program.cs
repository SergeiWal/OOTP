using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Task3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Park<Taxi> uber = new Park<Taxi>();
            Taxi t1 = new Taxi("AB3242C", new Location(12, 18, 65));
            Taxi t2 = new Taxi("AB3692d", new Location(13, 28, 75));
            Taxi t3 = new Taxi("AB3664C", new Location(12, 33, 45));
            Taxi t4 = new Taxi("AB3451s", new Location(123, 45, 25));
            uber.Add(t1);
            uber.Add(t2);
            uber.Add(t3);
            uber.Add(t4);

            uber.ParkColl.Sort((x,y) => {
                if (x.getPath(12, 14) > y.getPath(12, 14)) return 1;
                else if (x.getPath(12, 14) < y.getPath(12, 14)) return -1;
                else if (x.getPath(12, 14) == y.getPath(12, 14)) return 0;
                return -1;
            });

            using (StreamWriter sw = new StreamWriter("file.txt"))
            {
                sw.WriteLine(uber.ParkColl[0]);
            }


             Console.ReadKey();
        }

        //public static void Sort(Park<Taxi> park)
        //{
        //    for(int i =0;i<park.ParkColl.Count;++i)
        //    {
        //        for(int j=0;j<park.)
        //    }
        //}
            
    }
}
