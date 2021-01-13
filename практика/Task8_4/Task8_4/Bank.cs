using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_4
{
    class Bank<T>: List<T>
    {
        public Bank():base()
        {

        }
        public Bank(int len):base(len)
        {

        }
    }
}
