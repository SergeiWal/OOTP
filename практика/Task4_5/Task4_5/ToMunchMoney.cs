using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_5
{
    class ToMunchMoney: ApplicationException
    {
        public ToMunchMoney(string message):base(message)
        {

        }
    }
}
