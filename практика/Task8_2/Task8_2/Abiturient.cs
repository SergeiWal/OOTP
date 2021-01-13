using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_2
{
    class Abiturient
    {
        public string Name { get; }
        public DateTime Date { get; }
        private int[] Numbers;

        private const int NumbersCount = 4;

        public Abiturient(string name, int year, int month, int day, params int[] numbers)
        {
            Name = name;
            if (year > 0 && month <= 12 && month > 0 && day < 32 && day > 0)
            {
                Date = new DateTime(year, month, day);
            }
            else throw new Exception("Переданы не верные значения даты...");
            if (numbers.Length == NumbersCount)
            {
                Numbers = new int[NumbersCount];
                for(int i =0;i<NumbersCount;++i)
                {
                    if (numbers[i] >= 20 && numbers[i] <= 100)
                        Numbers[i] = numbers[i];
                    else throw new Exception("Переданы не валидные значения оценок");
                }
            }
            else throw new Exception("Передано неверное кол-во оценок...");
        }

        public int this[int index]
        {
            get
            {
                return Numbers[index];
            }
        }

        public override bool Equals(object obj)
        {
            if(obj is Abiturient)
            {
                Abiturient abtr = (Abiturient)obj;
                int sum1 = Numbers[0] + Numbers[1] + Numbers[2] + Numbers[3];
                int sum2 = abtr[0] + abtr[1] + abtr[2] + abtr[3];
                if (sum1 == sum2) return true;
                else return false;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (Numbers.GetHashCode() + base.GetHashCode()) / 2;
        }
    }
}
