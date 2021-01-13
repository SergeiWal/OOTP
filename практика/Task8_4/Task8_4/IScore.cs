using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_4
{
    interface IScore
    {
        int Amount { get; set; }
        void Add(int value);
        int GetMoney(int value);
    }
}
