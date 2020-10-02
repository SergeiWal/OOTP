using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Date
    {
        private int day;
        private int month;
        private int year;

        public Date()
        {
            day = 2;
            month = 10;
            year = 20;
        }

        public Date(int Day, int Month, int Year)
        {
            day = Day;
            month = Month;
            year = Year;
        }

        public int DAY
        {
            get
            {
                return day;
            }
            set
            {
                day = value;
            }
        }

        public int MONTH
        {
            get
            {
                return month;
            }
            set
            {
                month = value;
            }
        }

        public int YEAR
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
            }
        }

    }
}
