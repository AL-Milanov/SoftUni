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

            var index = 0;

            for (int i = 0; i < Count; i++)
            {
                if (element.Equals(collection[i]))
                {
                    isRemoved = true;
                    collection[i] = default;

                    Count--;
                    index = i;

                    break;
                }
            }

            if (isRemoved)
            {
                Reorder(index);

            }

            return isRemoved;
        }

        public bool Contains(T element)
        {
            if (element is null)
            {
                throw new NullReferenceException("Element cannot be null!");
            }

            var containsElement = false;

            for (int i = 0; i < Count; i++)
            {
                if (collection[i].Equals(element))
                {
                    return true;
                }
            }

            return containsElement;
        }

        private void Reorder(int index)
        {
            T currentElement = default;

            for (int i = index; i < Count; i++)
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
