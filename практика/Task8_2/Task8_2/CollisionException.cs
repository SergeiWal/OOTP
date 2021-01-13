using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_2
{
    class CollisionException: ApplicationException
    {
        public CollisionException(string message):base(message)
        {

        }
        public override string ToString()
        {
            return "CollisionException";
        }
    }
}
