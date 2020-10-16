using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace lab6
{
    enum RangType { JUNIOR, MIDDLE, SENIOR};
    class Developer
    {
        private string name;
        private int experience;
        private string language;
        private RangType rang;

        public Developer(string nm, int expr, string lng, RangType rg)
        {
            name = nm;
            experience = expr;
            language = lng;
            rang = rg;
        }

        string Name
        {
            get
            {
                return name;
            }
        }

        int Experience
        {
            get
            {
                return experience;
            }
        }

        string Language
        {
            get
            {
                return language;
            }        
        }

        RangType Rang
        {
            get
            {
                return rang;
            }
        }

        public override string ToString()
        {
            return Name + " " + Rang + " " + Language + " Devoloper " + Experience + "age expriens";
        }
    }
}
