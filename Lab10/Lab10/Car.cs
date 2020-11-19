using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab10
{
    class Car
    {
        private string brand;
        private string model;
        private string color;
        private int currentSpeed;
        private bool moveStatus;

        static public int maxSpeed = 220;

        public Car(string nbrand, string nmodel, string ncolor)
        {
            brand = nbrand;
            model = nmodel;
            color = ncolor;
            currentSpeed = 0;
            moveStatus = false;
        }

        public string Brand
        {
            get { return brand; }
            set { brand = value; }
        }

        public string Modedl
        {
            get { return model; }
            set { model = value; }
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }

        public int CurrentSpedd
        {
            get{ return currentSpeed; }
            set { 
                if(value < maxSpeed)currentSpeed = value;
            }
        }

        public bool MoveStatus
        {
            get { return moveStatus; }
            set { moveStatus = value; }
        }


        public void Start()
        {
            if(!moveStatus)
            {
                moveStatus = true;
                currentSpeed = 20;
            }
            else { throw new Exception("Машина уже заведена!"); }
        }

        public void Stop()
        {
            if(moveStatus)
            {
                moveStatus = false;
                currentSpeed = 0;
            }
            else { throw new Exception("Машина уже остановлена!"); }
        }

        public void Peep(int time)
        {
            Console.Beep(300, time);
        }

        public void SpeedIncrease(int nspeed)
        {
            if (currentSpeed + nspeed < maxSpeed) currentSpeed += nspeed;
            else currentSpeed = maxSpeed - 5;

            if (!moveStatus) moveStatus = true;
        }

        public static bool operator ==(Car c1, Car c2)
        {
            if (c1.Modedl == c2.Modedl && c1.Brand == c2.Brand) return true;
            return false;
        }

        public static bool operator !=(Car c1, Car c2)
        {
            if (c1.Modedl != c2.Modedl || c1.Brand != c2.Brand) return true;
            return false;
        }

    }
}
