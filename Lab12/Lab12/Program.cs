using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab12
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("----------------------------------------------------class1--------------------------------");
            Vector vc = new Vector(1, 2, 3, 4, 5, 6);
            Console.WriteLine(Reflector.GetAssemblyInfo(vc.GetType()));
            if (Reflector.IsPublishConstructors(vc.GetType())) Console.WriteLine("Class has constructor...");
            else Console.WriteLine("Constructor in clas not found...");
            Console.WriteLine("Methods:");
            Console.WriteLine("------------------------------------");
            foreach (var i in Reflector.GetMetodsInfo(vc.GetType())) Console.WriteLine(i);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Fields:");
            Console.WriteLine("------------------------------------");
            foreach (var i in Reflector.GetFieldInfo(vc.GetType())) Console.WriteLine(i);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Interfaces:");
            Console.WriteLine("------------------------------------");
            foreach (var i in Reflector.GetInterfaceInfo(vc.GetType())) Console.WriteLine(i);
            Console.WriteLine("------------------------------------");
            Reflector.OutputMetodsNameFromParamType(vc.GetType());


            Console.WriteLine("----------------------------------------------------class2--------------------------------");
            //-----------------------------------------
            Owner ow = new Owner();
            Console.WriteLine(Reflector.GetAssemblyInfo(ow.GetType()));
            if (Reflector.IsPublishConstructors(ow.GetType())) Console.WriteLine("Class has constructor...");
            else Console.WriteLine("Constructor in clas not found...");
            Console.WriteLine("Methods:");
            Console.WriteLine("------------------------------------");
            foreach (var i in Reflector.GetMetodsInfo(ow.GetType())) Console.WriteLine(i);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Fields:");
            Console.WriteLine("------------------------------------");
            foreach (var i in Reflector.GetFieldInfo(ow.GetType())) Console.WriteLine(i);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Interfaces:");
            Console.WriteLine("------------------------------------");
            foreach (var i in Reflector.GetInterfaceInfo(ow.GetType())) Console.WriteLine(i);
            Console.WriteLine("------------------------------------");
            Reflector.OutputMetodsNameFromParamType(ow.GetType());

            Console.WriteLine("----------------------------------------------------standart class--------------------------------");
            List<int> l = new List<int> { 1,2,3,4,5,6,7,8};
            Console.WriteLine(Reflector.GetAssemblyInfo(l.GetType()));
            if (Reflector.IsPublishConstructors(l.GetType())) Console.WriteLine("Class has constructor...");
            else Console.WriteLine("Constructor in clas not found...");
            Console.WriteLine("Methods:");
            Console.WriteLine("------------------------------------");
            foreach (var i in Reflector.GetMetodsInfo(l.GetType())) Console.WriteLine(i);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Fields:");
            Console.WriteLine("------------------------------------");
            foreach (var i in Reflector.GetFieldInfo(l.GetType())) Console.WriteLine(i);
            Console.WriteLine("------------------------------------");
            Console.WriteLine("Interfaces:");
            Console.WriteLine("------------------------------------");
            foreach (var i in Reflector.GetInterfaceInfo(l.GetType())) Console.WriteLine(i);
            Console.WriteLine("------------------------------------");
            Reflector.OutputMetodsNameFromParamType(l.GetType());
            object[] param = new object[1];
            using (FileStream fstream = File.OpenRead($"data.txt"))
            {
                // преобразуем строку в байты
                byte[] array = new byte[fstream.Length];
                // считываем данные
                fstream.Read(array, 0, array.Length);
                // декодируем байты в строку
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                param[0] = Convert.ToInt32(textFromFile);
            }
            Reflector.Invoke(l, "Add", param);
            Random rand = new Random();
            param[0] = rand.Next();
            Reflector.Invoke(l, "Add", param);
           
            Console.ReadLine();
        }
    }
}
