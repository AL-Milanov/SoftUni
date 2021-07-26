namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this.head;

            while (current != null)
            {
                if (current.Item.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            EnsureNotEmpty();

            T headToRemove = head.Item;

            head = head.Next;
            Count--;

            return headToRemove;
        }

        public void Enqueue(T item)
        {
            Node<T> newNode = new Node<T>(item, null);

            if (Count == 0)
            {
                tail = newNode;
                head = tail;
            } 
            else
            {
                tail.Next = newNode;
                tail = tail.Next;
            }
            Count++;
        }

        public T Peek()
        {
            EnsureNotEmpty();

            return head.Item;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = this.head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}