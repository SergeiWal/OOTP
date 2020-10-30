using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    partial class CollectionType<T> : IGenericCollection<T> 
    {
        
        public void OwnerInfo()
        {
            Console.WriteLine($"Name: {owner.NAME}\nID: {owner.ID}\nOrganization: {owner.ORG}");
        }

        public void AddElement(T val)
        {
            length++;
            values.Add(val);
        }

        public void DeleteElement(int idx)
        {
            values.RemoveAt(idx);
        }

        public void WriteCollection()
        {
            foreach (var item in values) Console.WriteLine(item);
        }


        public void WriteInFile()
        {
            using (StreamWriter f = new StreamWriter(@"D:\GIT\OOTP\lab8\lab8\log.txt", true, System.Text.Encoding.Default))
            {
                f.WriteLine(this.ToString());
                f.WriteLine(length);
                f.WriteLine("Values:");
                foreach (var i in values) f.WriteLine(i);
            }
                
        }

        public void ReadInFile()
        {
            using (StreamReader f = new StreamReader(@"D:\GIT\OOTP\lab8\lab8\log.txt", System.Text.Encoding.Default))
            {
                while (!f.EndOfStream) Console.WriteLine(f.ReadLine());
            }
                
        }
    }
}
