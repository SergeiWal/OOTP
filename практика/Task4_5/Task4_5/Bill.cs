using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Task4_5
{
    [DataContract(Name ="Bill", Namespace="Wallet")]
    class Bill: INumber
    {
        [IgnoreDataMember]
        private int number;
        [IgnoreDataMember]
        readonly int[] validNumber ;
        
        public Bill()
        {
            validNumber = new int[] { 5, 10, 20, 50, 100 };
        }
        public Bill(int numb):this()
        {
            Number = numb;
        }

        [DataMember(Name ="value")]
        public int Number
        {
            get { return number; }
            set 
            {
                if (value > 0 && validNumber.Where(n => n == value).Count() != 0)
                    number = value;
                else throw new Exception("Передано не валидное значение купюры...");
            }
        }

    }
}
