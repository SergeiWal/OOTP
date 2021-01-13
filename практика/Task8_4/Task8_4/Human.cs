using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_4
{
    class Human
    {

        private DateTime date;
        public DateTime Date
        {
            get => date;
            set => date = value;
        }

        public Human(int year, int month, int day)
        {
            date = new DateTime(year, month, day);
        }

    }
}
