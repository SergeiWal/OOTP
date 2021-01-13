using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_1
{
    class Manager
    {
        public  delegate void Rebates();
        public event Rebates Sale; 

        public void StartSale()
        {
            Console.WriteLine("Sale starting!!!!!!");
            Sale?.Invoke();
        }
    }
}
