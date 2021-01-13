using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_5
{
    class Wallet<T> where T : INumber, new()
    {
        private const int maxvalue = 200;
        private List<T> bills;

        public List<T> Bills { get => bills; }
        
        public Wallet()
        {
            bills = new List<T>();
        }

        public void Add(T money)
        {
            bills.Add(money);
            if (BillSum() > 200)
                throw new ToMunchMoney("Превышен макс.размер кошелька...");
        }

        public void Delete()
        {
            if (bills.Count() == 0) throw new NoBillinWallet("Кошелёк пуст, нечего забирать...");
            int idx = MinElement();
            bills.RemoveAt(idx);
        }

        private int BillSum()
        {
            int sum = 0;
            foreach (var i in bills)
                sum += i.Number;
            return sum;
        }

        private int MinElement()
        {
            int minIdx = 0;
            for(int i=1;i<bills.Count();++i)
            {
                if (bills[i].Number < bills[minIdx].Number) minIdx = i;
            }
            return minIdx;
        }
    }
}
