using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private readonly List<T> data;

        private int index;

        public ListyIterator()
        {
            this.data = new List<T>();
            this.index = 0;
        }
        public ListyIterator(IEnumerable<T> data)
        {
            this.data = new List<T>(data);
        }


        public bool Move()
        {
            index++;
            if (this.index >= data.Count)
            {
                this.index--;
                return false;
            }
            return this.index < this.data.Count;
        }

        public void Print()
        {
            if (data.Count == 0 || index >= data.Count)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(data[index]);
            }
        }

        public bool HasNext()
        {
            int index = this.index + 1;
            return index < this.data.Count;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
