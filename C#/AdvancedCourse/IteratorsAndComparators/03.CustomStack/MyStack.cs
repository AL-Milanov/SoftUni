using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _03.CustomStack
{
    class MyStack<T> : IEnumerable<T>
    {
        private List<T> stack;

        public MyStack()
        {
            stack = new List<T>();
        }


        public void Push(T element)
        {
            stack.Add(element);
        }

        public void Pop()
        {
            if (stack.Count > 0)
            {
                stack.RemoveAt(stack.Count - 1);
            }
            else 
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
