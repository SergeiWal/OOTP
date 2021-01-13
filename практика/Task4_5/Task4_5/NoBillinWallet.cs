using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_5
{
    class NoBillinWallet:ApplicationException
    {
        public NoBillinWallet(string message):base(message)
        {

        }
    }
}
