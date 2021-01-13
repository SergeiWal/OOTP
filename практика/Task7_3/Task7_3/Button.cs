using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_3
{
    class Button
    {
        private string caption;
        private Point startpoint;
        private int w;
        private int h;

        public string Caption
        {
            get
            {
                return caption;
            }
            set
            {
                caption = value;
            }
        }

        public Point StartPoint
        {
            get
            {
                return startpoint;
            }
            set
            {
                startpoint = value;
            }
        }

        public int Width
        {
            get
            {
                return w;
            }
            set
            {
                if (value > 0) w = value;
                else throw new Exception("Не валидная ширина кнопки...");
            }
        }

        public int Hight
        {
            get
            {
                return h;
            }
            set
            {
                if (value > 0) h = value;
                else throw new Exception("Не валидная высота кнопки...");
            }
        }

        public Button(string name, Point start, int width, int hight)
        {
            Caption = name;
            StartPoint = start;
            Width = width;
            Hight = hight;
        }

        public override string ToString()
        {
            return $"Button {Caption}: startpoint {startpoint}, width {w}, hight {h}.";
        }

        public override bool Equals(object obj)
        {
            if(obj is Button)
            {
                Button bt = (Button)obj;
                if (caption == bt.Caption && w == bt.Width && h == bt.Hight)
                    return true;
                else return false;
            }
            return false;
        }

    }

    class Point
    { 
        public int X { get; set; }
        public int Y { get; set; }


        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        
    }

}
