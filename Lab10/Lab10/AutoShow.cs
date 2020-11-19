using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{

    class Cars<T>: IList<T>  where T: Car
    {
        private List<T> collection;
       
        public Cars(params T[] car)
        {
            collection = new List<T>();
            foreach (var i in car) collection.Add(i);
        }

        public Cars()
        {
            collection = new List<T>();
        }

        public int IndexOf(T value)
        {    
            for (int i = 0; i < collection.Count; ++i)
                if (collection[i] == value) return i;
            return -1;
        }

        public void RemoveAt(int index)
        {
            collection.RemoveAt(index);
        }

        public void Insert(int index, T value)
        {
            collection.Insert(index, value);
        }

       
        public T this[int index]
        {
            get
            {
                if (index >= 0 && index < collection.Count) return collection[index];
                else throw null;
            }

            set
            {
                collection[index] = value;
            }
        }

        public void Add(T item)
        {
            collection.Add(item);
        }

        public void Clear()
        {
            for (int i = 0; i < collection.Count; ++i) collection.RemoveAt(i);
        }

        public bool Remove(T item)
        {
            for (int i = 0; i < collection.Count; ++i)
                if (collection[i] == item)
                {
                    collection.RemoveAt(i);
                    return true;
                }
            return false;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < collection.Count; ++i)
                if (collection[i] == item) return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            collection.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)collection).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)collection).GetEnumerator();
        }

        public int Count
        {
            get
            {
                return collection.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

    }
}
