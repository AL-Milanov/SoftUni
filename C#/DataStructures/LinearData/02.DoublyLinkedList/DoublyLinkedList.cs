namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item);

            if (Count == 0)
            {
                tail = newNode;
                head = tail;
                head.Previous = head;
            }
            else
            {
                newNode.Next = head;
                head.Previous = newNode;
                head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item);

            if (Count == 0)
            {
                tail = newNode;
                head = tail;
                head.Previous = head;
            }
            else
            {
                newNode.Previous = tail;
                tail.Next = newNode;
                tail = tail.Next;
            }

            Count++;
        }

        public T GetFirst()
        {
            EnsureNotEmpty();

            return head.Item;
        }

        public T GetLast()
        {
            EnsureNotEmpty();

            return tail.Item;
        }

        public T RemoveFirst()
        {
            EnsureNotEmpty();

            var oldHead = head;
            head = head.Next;
            Count--;

            return oldHead.Item;
        }

        public T RemoveLast()
        {
            EnsureNotEmpty();

            var oldTail = tail;
            tail = tail.Previous;
            Count--;

            return oldTail.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;

            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();
        }
    }
}