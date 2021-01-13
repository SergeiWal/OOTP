using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_1
{
    class Item
    {
        public string Name { get; }
        public long ID { get; }
        public double Price { get; set; }

        public Item(string name, long id, double price)
        {
            Name = name;
            ID = id;

            if (price >= 0) Price = price;
            else throw new Exception("Цена не может быть отрицательной.");
        }

        public override string ToString()
        {
            return $"Name:{Name} ID:{ID} Price:{Price}";
        }

        public void Rebate()
        {
            Price -= Price / 2;
        }

    }
}
