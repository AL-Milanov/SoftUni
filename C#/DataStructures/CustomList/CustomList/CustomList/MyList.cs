using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomList
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] collection;

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                return collection[index];
            }
            set
            {
                if (index >= Capacity)
                {
                    throw new IndexOutOfRangeException("Index is outside of bounds of the array");
                }

                collection[index] = value;
            }
        }

        public MyList(int length = 4)
        {
            collection = new T[length];
            Capacity = length;
        }

        public MyList(IEnumerable<T> _collection)
        {
            Capacity = _collection.Count();

            CopyCollection(_collection);
        }

        public void Add(T element)
        {
            if (element == null)
                throw new ArgumentNullException($"{element} cannot be null");

            Resize();

            collection[Count++] = element;
        }

        public bool Remove(T element)
        {
            bool isRemoved = false;

            if (element == null)
            {
                throw new NullReferenceException($"{element} cannot be null!");
            }

            for (int i = 0; i < Count; i++)
            {
                if (element.Equals(collection[i]))
                {
                    isRemoved = true;
                    collection[i] = default;

                    Count--;
                    break;
                }
            }

            if (isRemoved)
            {
                Reorder();

            }

            return isRemoved;
        }

        private void Reorder()
        {
            T currentElement = default;

            for (int i = 0; i < Count; i++)
            {
                currentElement = collection[i];

                if (currentElement is null)
                {
                    currentElement = collection[i + 1];
                }
                else if (collection[i + 1] != null)
                {
                    currentElement = collection[i + 1];
                }
                collection[i] = currentElement;
            }

            collection[Count] = default;
        }

        private void Resize()
        {
            if (Count + 1 > Capacity)
            {
                Capacity *= 2;

                CopyCollection(collection);
            }
        }

        private void CopyCollection(IEnumerable<T> _collection)
        {
            Count = 0;

            collection = new T[Capacity];

            foreach (var item in _collection)
            {
                collection[Count++] = item;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
            {
                if (item == null)
                {
                    break;
                }

                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
