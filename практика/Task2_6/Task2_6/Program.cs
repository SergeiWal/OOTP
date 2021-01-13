using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Task2_6
{
    class Program
    {
        static void Main(string[] args)
        {
            User us1 = new User("korova@gmail.com", 1111, State.signin);
            User us2 = new User("volk@gmail.com", 1234, State.signout);
            User us3 = new User("fox@gmail.com", 1435, State.signin);
            User us4 = new User("zayac@gmail.com", 1456, State.signout);
            User us5 = new User("korova@gmail.com", 8909, State.signin);

            if (us1.Equals(us5)) Console.WriteLine("us1 == us5");
            if (us1.Equals(us2)) Console.WriteLine("us1 == us2");
           else Console.WriteLine("us1 != us2");

            switch (us2.CompareTo(us3))
            {
                case 1:
                    Console.WriteLine("us2 > us3");
                    break;
                case -1:
                    Console.WriteLine("us2 < us3");
                    break;
                case 0:
                    Console.WriteLine("us2 == us3");
                    break;
                default:
                    break;
            }

            WebNet github = new WebNet();
            github.Add(us1);
            github.Add(us2);
            github.Add(us3);
            github.Add(us4);
            github.Add(us5);

            int CountSignIn = github.Users.Where((n) => n.Status == State.signin).Count();
            Console.WriteLine($"{CountSignIn} столько пользователей зашло на github");

            foreach(var c in github.Users)
            {
                Serelisation(c);
            }
            
            Console.ReadKey();

        }

        public static void Serelisation(User us1)
        {
            BinaryFormatter sb = new BinaryFormatter();
            using (FileStream sw = new FileStream("file.dat", FileMode.OpenOrCreate))
            {
                sb.Serialize(sw, us1);
            }

        }
    }
}
