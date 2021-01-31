using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Abiturient a1 = new Abiturient("Сергей",2002,5,3,85,82,72,54);
            Abiturient a2 = new Abiturient("Иван", 2002, 5, 3, 20, 54, 62, 54);
            Abiturient a3 = new Abiturient("Казимир", 2002, 5, 3, 84, 100, 72, 64);
            Abiturient a4 = new Abiturient("Дима", 2002, 5, 3, 65, 65, 22, 23);
            Abiturient a5 = new Abiturient("Олег", 2002, 5, 3, 45, 45, 44, 54);
            Abiturient a6 = new Abiturient("Никита", 2002, 5, 3, 25, 62, 62, 54);
            Abiturient a7 = new Abiturient("Кирил", 2002, 5, 3, 35, 72, 72, 54);
            Abiturient a8 = new Abiturient("ефим", 2002, 5, 3, 35, 44, 72, 54);
            Abiturient a9 = new Abiturient("Лера", 2002, 5, 3, 25, 22, 72, 54);
            Abiturient a10 = new Abiturient("Игорь", 2002, 5, 3, 35, 32, 32, 54);
            Abiturient a11 = new Abiturient("Жан", 2002, 5, 3, 99, 99, 65, 54);

            FIT fit = new FIT();
            fit.AddStudent(a1);
            fit.AddStudent(a2);
            fit.AddStudent(a3);
            fit.AddStudent(a4);
            fit.AddStudent(a5);
            fit.AddStudent(a6);
            fit.AddStudent(a7);
            fit.AddStudent(a8);
            fit.AddStudent(a9);
            fit.AddStudent(a10);
            fit.AddStudent(a11);
            foreach(var c in fit.Students)
            {
                Console.WriteLine($"{c.Name}");
            }

            fit.DeleteStudent(a11);
            Console.WriteLine("-------------fit be for deleted----------------");
            foreach (var c in fit.Students)
            {
                Console.WriteLine($"{c.Name}");
            }

            Console.WriteLine("-------------absolyte number----------------");
            Console.WriteLine($"Absolyte number:{fit.Average()}"); 
            Console.ReadKey();
        }
    }
}
