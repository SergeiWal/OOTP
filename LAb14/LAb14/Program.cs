using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

using System.Xml;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml.Linq;
using System.Xml.XPath;


namespace Lab14
{
     class Program
    {
        static void Main(string[] args)
        {
            //---task1
            Sapper sp1 = new Sapper(true, false, "arcada", "9.0", 235, 500, 211);
            BinaryFormatter bf = new BinaryFormatter();

            using (FileStream fs = new FileStream("Serl1.dat",FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, sp1);
            }

            using (FileStream fs = new FileStream("Serl1.dat",FileMode.Open, FileAccess.Read))
            {
                Sapper sp2 = (Sapper)bf.Deserialize(fs);
            }

            SoapFormatter sf = new SoapFormatter();
            using (FileStream fs = new FileStream("Serl2.soap", FileMode.OpenOrCreate))
            {
                sf.Serialize(fs, sp1);
            }

            using(FileStream fs = new FileStream("Serl2.soap", FileMode.OpenOrCreate))
            {
                Sapper s3 =(Sapper) sf.Deserialize(fs);
            }

           
            XmlSerializer xs = new XmlSerializer(typeof(Sapper));
            using (FileStream fs =new FileStream("Serl3.xml", FileMode.OpenOrCreate))
            {
                xs.Serialize(fs, sp1);
            }

            using (FileStream fs = new FileStream("Serl3.xml", FileMode.OpenOrCreate))
            {
                Sapper s4 = (Sapper)xs.Deserialize(fs);
            }

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(Sapper));

            using (FileStream fs = new FileStream("Serl4.json",FileMode.OpenOrCreate))
            {
                js.WriteObject(fs, sp1);
            }

            using (FileStream fs = new FileStream("Serl4.json", FileMode.OpenOrCreate))
            {
                Sapper sp4 = (Sapper)js.ReadObject(fs);
            }

            //---task2

            List<Sapper> spcl = new List<Sapper>() { new Sapper(true, false, "arcada", "9.0", 235, 500, 211) ,
                new Sapper(true, false, "arcada", "11.0", 400, 500, 211),
                new Sapper(true, false, "arcada", "8.0", 235, 1500, 211),
                new Sapper(true, false, "arcada", "18.0", 235, 500, 211)};

            DataContractJsonSerializer jsn = new DataContractJsonSerializer(typeof(List<Sapper>));
            using (FileStream fs = new FileStream("Serl5.json", FileMode.OpenOrCreate))
            {
                jsn.WriteObject(fs, spcl);
            }

            using (FileStream fs = new FileStream("Serl5.json", FileMode.OpenOrCreate))
            {
                List<Sapper> sp4 = (List<Sapper>)jsn.ReadObject(fs);
            }

            //---task3

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Serl3.xml");
            XmlElement root = xDoc.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("*");
            foreach (XmlNode i in nodes) Console.WriteLine(i);
            Console.WriteLine();
            XmlNodeList nodes2 = root.SelectNodes("fieldSize");
            foreach (XmlNode i in nodes2) Console.WriteLine(i);

            //---task4

            XDocument xdoc = new XDocument();
            XElement book = new XElement("Book");
            XAttribute name = new XAttribute("name", "Чистый код");
            XElement price = new XElement("Price", "1200");
            book.Add(name);
            book.Add(price);

            XElement xroot = new XElement("lib");
            xroot.Add(book);
            xdoc.Add(xroot);
            xdoc.Save("data.xml");

            var result = from c in xdoc.Descendants("book") select new { title = c.Attribute("title").Value, c.Element("price").Value };

            Console.Read();
        }
    }
}
