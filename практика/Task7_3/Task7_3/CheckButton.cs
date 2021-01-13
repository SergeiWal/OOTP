using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_3
{
    enum CheckStates
    {
        Checked,
        Unchecked
    }

    class CheckButton: Button
    {
        public CheckStates State { get; set; }

        public CheckButton(string name, Point start, int width, int hight, CheckStates st) :base(name, start,width,hight)
        {
            State = st;
        }

        public void Check()
        {
            if (State == CheckStates.Checked) State = CheckStates.Unchecked;
            else State = CheckStates.Checked;
        }

        public void Zoom(int value)
        {
            if (value < 0 || value > 100)
                throw new Exception("Неверно переданное процентное значение...");
            Width = Width - (Width * value )/ 100;
            Hight = Hight -  (Hight * value) / 100;
        }

        public override string ToString()
        {
            return base.ToString() + $"check:{State}";
        }
    }


}
