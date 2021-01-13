using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2
{
    enum StatusValue
    {
        buzy,
        free
    }

    class Taxi
    {
        private string number;
        private Location loc;
        private StatusValue status;

        public string Number
        {
            get => number;
            set => number = value;
        }

        public Location Loc
        {
            get => loc;
            set => loc = value;
        }

        public StatusValue Status
        {
            get => status;
            set => status = value;
        }

        public Taxi(string numb, Location lc, StatusValue state=StatusValue.free)
        {
            Number = numb;
            Loc = lc;
            Status = state;
        }

        public double getPath(int x, int y)
        {
            return Math.Sqrt(Math.Pow((double)(x - loc.Lat),2) - Math.Pow((double)(y - loc.Long), 2));
        }

        public override string ToString()
        {
            return $"Name:{Number} Location:{Loc} Status:{Status}";
        }

    }
}
