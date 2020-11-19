using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {       
        static void Main(string[] args)
        {
            User us1 = new User("Sergei","Host1",200);
            User us2 = new User("Nikita", "Host2", 100);
            User us3 = new User("Jon", "Host1", 1100);
            User us4 = new User("Alexa", "Host5", 400);

            us1.Compr += new User.CompressionMemory(us1.Compression);
            us1.Compr += new User.CompressionMemory(WriteCompr);

            us2.Move += new User.SershHostForUser(us2.MoveUser);
            us2.Move += new User.SershHostForUser(WriteMove);

            User.SershHostForUser sh = new User.SershHostForUser(us3.MoveUser);
            sh += (string str) => { Console.WriteLine($"User moved in new host:{str}"); };

            us3.Move += sh;
            us3.Compr += new User.CompressionMemory(us3.Compression);
            

            us4.Move += new User.SershHostForUser(us4.MoveUser);
            us4.Compr += delegate(int value){ 
                us4.Compression(value);
                WriteCompr(value);
            };

            us1.Search(100, "Host2");
            us2.Search(100, "Host5");
            us3.Search(100, "Host4");
            us4.Search(100, "Host19");

            string text = "The first day in University was very long. I am learn  Math, Informatik and Physik! AAAAAA";
            Func<string, string> fc = new Func<string, string>(DeletePunctuation);
            fc += Symbol;
            fc += ToUpper;
            fc += SpaceDelete;
            fc += ToLowwer;

            fc(text);

            Console.ReadKey();
        }

        public static void WriteMove(string finish)
        {
            Console.WriteLine($"User moved in new host:{finish}");
        }

        public static void WriteCompr(int value)
        {
            Console.WriteLine($"User Memory compressied in {value}");
        }

        public static string DeletePunctuation(string str)
        {
            for (int i = 0; i < str.Length; ++i)
                if (str[i] == '.' || str[i] == ',' || str[i] == '!' || str[i] == '?' || str[i] == ';' || str[i] == ':')str = str.Remove(i, 1);
            Console.WriteLine(str);
            return str;
        }

        public static string  Symbol(string str)
        {
            Console.WriteLine("Please, enter one symbol!");
            char symbol = (char)Console.Read();
            str += symbol;
            Console.WriteLine(str);
            return str;
        }

        public static string ToUpper( string str)
        {
            str = str.ToUpper();
            Console.WriteLine(str);
            return str;
        }

        public static string SpaceDelete(string str)
        {
            for (int i = 0; i < str.Length; ++i)
                if (str[i] == ' ') str = str.Remove(i, 1);
            Console.WriteLine(str);
            return str;
        }

        public static string ToLowwer(string str)
        {
            str = str.ToLower();
            Console.WriteLine(str);
            return str;
        }
    }    
}
