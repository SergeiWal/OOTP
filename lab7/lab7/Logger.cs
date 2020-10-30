using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    interface ILogger
    {
        void LogInput(string message);
    }

    class FileLogger : ILogger
    {
        private DateTime date;
        

        public FileLogger()
        {
            date = DateTime.Now;
            using (StreamWriter f = new StreamWriter(@"D:\GIT\OOTP\lab7\lab7\log.txt", false, System.Text.Encoding.Default))
            {
                f.WriteLine($"{date.ToString()}INFO:Test log message");
            }
        }

        public void LogInput(string message)
        {
            using (StreamWriter f = new StreamWriter(@"D:\GIT\OOTP\lab7\lab7\log.txt", true , System.Text.Encoding.Default))
            {
                f.WriteLine(message);
            }
            
        }

    }

    class ConsoleLogger : ILogger
    {
        private DateTime date;
       
        public ConsoleLogger()
        {
            date = DateTime.Now;
            Console.WriteLine($"{date.ToString()}INFO:Test log message");
        }

        public void LogInput(string message)
        {
            Console.WriteLine(message);
        }

    }

}
