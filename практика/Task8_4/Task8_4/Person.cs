using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_4
{
    class Person: Human, IScore
    {
        private int amount;
        private static int Count;

        static Person()
        {
            Count = 0;
        }
        public Person(int year, int month, int day, int amn):base(year, month, day)
        {
            Amount = amn;
            Count++;
        }

        public int Amount { 
            get =>amount; 
            set
            {
                if (amount < 0) throw new Exception("Счёт не может быть меньше нуля...");
                amount = value;
            }
        }

        public void Add(int value)
        {
            if (value < 0) throw new Exception("Невалидное значение добавляемой суммы...");
            amount += value;
        }

        public int GetMoney(int value)
        {
            if (amount < 0) throw new Exception("Счёт пуст...");
            if (amount - value < 0) throw new Exception("На счёте не достаточно средств...");
            amount -= value;
            return value;
        }

        public static int GetPersonCount()
        {
            return Count;
        }

        public override bool Equals(object obj)
        {
            if (obj is Person)
            {
                Person p = (Person)obj;
                if (p.Date == Date) return true;
                else return false;
            }
            else return false;
        }

        public override int GetHashCode()
        {
            return amount.GetHashCode() & base.GetHashCode();
        }
    }
}
