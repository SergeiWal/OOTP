using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7_3
{
    class User
    {
        public delegate void CheckDlg();
        public delegate void ResizeDlg(int value);

        public event CheckDlg Click;
        public event ResizeDlg Resize;

        public void Start(int value)
        {
            Click?.Invoke();
            Resize?.Invoke(value);
        }

    }
}
