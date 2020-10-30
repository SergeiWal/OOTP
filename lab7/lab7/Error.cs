using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class CompError: ApplicationException
    {
        public CompError(string message = "****Error in collection!****") :base(message)
        {
        }
    }

    class HardwareExeption : CompError
    {
        public HardwareExeption(string message = "****Hardware for this soft  is very weakly****") :base(message)
        {
            HelpLink = "https://vk.com/id340176600";
        }

        static public void HardwareChrcking(Computer pc, Soft sf)
        {
            if (pc.Hard.Memory < sf.Memory) throw new HardwareExeption();
            if (pc.Hard.RAM < sf.RAM) throw new HardwareExeption();
        }
    }

    class MaliciousSoftware : CompError
    {
        public MaliciousSoftware(string softName) : base($"****{softName} is Malicious Soft!****")
        {
            HelpLink = "https://vk.com/id340176600";
        }

        static public void IsVirus(Soft sf)
        {
            if (sf is Bag)
            {
                if (sf is CConficer) throw new MaliciousSoftware("CConficer");
                else throw new MaliciousSoftware("Incoginto virus");
            }
        }
    }


}
