using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;

namespace Lab14
{
    public enum RangType { JUNIOR, MIDDLE, SENIOR };

    [Serializable]
    [DataContract]
    public class Developer
    {
        [DataMember]
        private string name;
        [DataMember]
        private int experience;
        [DataMember]
        private string language;
        [DataMember]
        private RangType rang;

        public Developer() { }

        public Developer(string nm, int expr, string lng, RangType rg)
        {
            name = nm;
            experience = expr;
            language = lng;
            rang = rg;
        }

        public string Name
        {
            get
            {
                return name;
            }
        }

        public int Experience
        {
            get
            {
                return experience;
            }
        }

        public  string Language
        {
            get
            {
                return language;
            }        
        }

         public RangType Rang
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
