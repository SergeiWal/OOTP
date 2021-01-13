using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_2
{
    public delegate bool Predicate(object obj);
    class Park<T>
    {
        private List<T> park;

        public Park()
        {
            park = new List<T>();
        }

        public List<T> ParkColl
        {
            get => park;
            set => park = value;
        }

        public void Add(T value)
        {
            park.Add(value);
        }

        public void Delete(T value)
        {
            park.Remove(value);
        }

        public void Clear()
        {
            park.Clear();
        }

        public T Find(Predicate pr)
        {
            foreach(var i in park)
            {
                if (pr(i))
                    return i;
            }
            return default(T);
        }

    }
}
