using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_2
{
    static class NewMethods
    {
        public static double Average(this FIT fit)
        {
            double sum = 0;
            for(int i=0;i<fit.Students.Count;++i)
                sum += (fit.Students[i][0] + fit.Students[i][1] + fit.Students[i][2] + fit.Students[i][3]) / 4;
            return sum / fit.Students.Count;
        }
    }
}
