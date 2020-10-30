using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    interface IGenericCollection<T> 
    {
        void AddElement(T val);
        void DeleteElement(int idx);
        void  WriteCollection();
    }
}
