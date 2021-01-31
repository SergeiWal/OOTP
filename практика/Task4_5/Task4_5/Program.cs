using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Task4_5
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("-----------------------TASK 1_3 --------------------------");
                Bill b1 = new Bill(5);
                Bill b2 = new Bill(10);
                Bill b3 = new Bill(20);
                Bill b4 = new Bill(50);
                Bill b5 = new Bill(100);
                Bill b6 = new Bill(100);
                Bill b7 = new Bill(10);

                Wallet<Bill> wallet = new Wallet<Bill>();
                wallet.Add(b1);
                wallet.Add(b2);
                wallet.Add(b3);
                wallet.Add(b4);
                wallet.Add(b5);
                //wallet.Add(b6);
                //wallet.Add(b7);
                Console.WriteLine("------------------------Basic wallet---------------------------");
                foreach (var c in wallet.Bills)
                {
                    Console.WriteLine($"{c}:{c.Number}");
                }
                wallet.Delete();
                Console.WriteLine("------------------------Wallet be for deleted---------------------------");
                foreach (var c in wallet.Bills)
                {
                    Console.WriteLine($"{c}:{c.Number}");
                }
                Console.WriteLine("-----------------------TASK 4----------------------------");
                var bill5 = (from c in wallet.Bills where c.Number == 5 select c).Count();Console.WriteLine($"В кошельке {bill5} 5 рублёвых купюр...");
                var bill10 = (from c in wallet.Bills where c.Number == 10 select c).Count(); Console.WriteLine($"В кошельке {bill10} 10 рублёвых купюр...");
                var bill20 = (from c in wallet.Bills where c.Number == 20 select c).Count(); Console.WriteLine($"В кошельке {bill20} 20 рублёвых купюр...");
                var bill50 = (from c in wallet.Bills where c.Number == 50 select c).Count(); Console.WriteLine($"В кошельке {bill50} 50 рублёвых купюр...");
                var bill100 = (from c in wallet.Bills where c.Number == 100 select c).Count(); Console.WriteLine($"В кошельке {bill100} 100 рублёвых купюр...");
                Console.WriteLine("----------------------TASK 5(DATA IN FILE)-----------------------------");

                foreach(var c in wallet.Bills)
                {
                    Serilisation(c);
                }

            }
            catch(ToMunchMoney e)
            {
                Console.WriteLine(e.Message);
            }
            catch(NoBillinWallet c)
            {
                Console.WriteLine(c.Message);
            }
            catch(Exception d)
            {
                Console.WriteLine(d.Message);
            }
            finally
            {
                Console.Read();
            }

        }

        public static void Serilisation(Bill obj)
        {
            DataContractJsonSerializer sb = new DataContractJsonSerializer(typeof(Bill));
            using (FileStream fs = new FileStream("data.json",FileMode.Append))
            {
                sb.WriteObject(fs, obj);
                byte[] array = Encoding.Default.GetBytes("\n");
                fs.Write(array,0,array.Length);
            }
        }
    }
}
