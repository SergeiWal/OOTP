using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2
{
    class Location
    {
        private int lat;
        private int loNg;
        private int speed;

        public int Lat
        {
            get
            {
                return lat;
            }
            set
            {
                lat = value;
            }
        }

        public int Long
        {
            get
            {
                return loNg;
            }
            set
            {
                loNg = value;
            }
        }
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if (value >= 0) speed = value;
                else throw new Exception("Скорость не может быть отрицательной...");
            }
        }

        public Location(int lt, int lg, int spd)
        {
            Lat = lt;
            Long = lg;
            Speed = spd;
        }

        public override string ToString()
        {
            return $"Lat:{lat} Long:{loNg} Speed:{speed}";
        }

    }
}
