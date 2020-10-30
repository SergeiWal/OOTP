using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Owner
    {
        private int id;
        private string name;
        private string organization;

        public Owner()
        {
            id = 03052002;
            name = "Sergei";
            organization = "BSTU";
        }

        public Owner(int ID, string NAME, string ORG)
        {
            id = ID;
            name = NAME;
            organization = ORG;
        }

        public int ID
        {
            get 
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public string NAME
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string ORG
        {
            get
            {
                return organization;
            }
            set
            {
                organization = value;
            }
        }
    }
}
