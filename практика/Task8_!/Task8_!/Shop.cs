using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8_1
{
    class Shop: IEnumerable
    {
        public Queue<Item> assortment;

        public Shop()
        {
            assortment = new Queue<Item>();
        }

        public void Add(Item newItem)
        {
            assortment.Enqueue(newItem);
        }

        public Item Delete()
        {
            return assortment.Dequeue();
        }

        public void Clear()
        {
            assortment.Clear();
        }

        public Item HeadElement()
        {
            return assortment.First();
        }

        public override bool Equals(object obj)
        {
            if(obj is Shop)
            {
                Shop buf = (Shop)obj;
                if (assortment.Count != buf.assortment.Count) return false;
                for(int i =0;i<assortment.Count;++i)
                {
                    if (assortment.ElementAt(i) != buf.assortment.ElementAt(i))
                        return false;
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return (assortment.GetHashCode() + base.GetHashCode()) / 2;
        }

        class ShopEnumenator : IEnumerator
        {
            private int position = -1;
            private readonly Queue<Item> data;

            public ShopEnumenator(Queue<Item> value)
            {
                data = new Queue<Item>();
                data = value;
            }
            public object Current => data.ElementAt(position);
            public bool MoveNext()
            {
                if (position < data.Count - 1)
                {
                    position++;
                    return true;
                }
                else return false;
            }
            public void Reset()
            {
                position = -1;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new ShopEnumenator(assortment);
        }

        public static Shop operator+(Shop dest, Item newItem)
        {
            dest.Add(newItem);
            return dest;
        }

        public static Shop operator -(Shop dest, int number)
        {
            int len = dest.assortment.Count;
            for (int i = 0; i < number && i<len; ++i) dest.Delete();
            return dest;
        }

        public Item this[int index]
        {
            get
            {
                return assortment.ElementAt(index);
            }
        }
       
    }

    
}
