namespace _01._BrowserHistory
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using _01._BrowserHistory.Interfaces;

    public class BrowserHistory : IHistory
    {
        private Stack<ILink> stack;
        private Dictionary<string, ILink> dictionary;

        public BrowserHistory()
        {
            stack = new Stack<ILink>();
            dictionary = new Dictionary<string, ILink>();
        }

        public int Size => stack.Count;

        public void Clear()
        {
            stack.Clear();
            dictionary = new Dictionary<string, ILink>();
        }

        public bool Contains(ILink link)
        {
            return dictionary.ContainsValue(link);
        }

        public ILink DeleteFirst()
        {
            IsEmpty();

            var queue = new Stack<ILink>(stack);
            var removed = queue.Pop();

            stack = new Stack<ILink>(queue);
            dictionary.Remove(removed.Url);

            return removed;
        }

        public ILink DeleteLast()
        {
            IsEmpty();
            var removed = stack.Pop();

            dictionary.Remove(removed.Url);

            return removed;
        }

        public ILink GetByUrl(string url)
        {
            if (!dictionary.ContainsKey(url))
            {
                return null;
            }

            return dictionary[url];
        }

        public ILink LastVisited()
        {
            IsEmpty();

            return stack.Peek();
        }

        public void Open(ILink link)
        {
            stack.Push(link);

            if (!dictionary.ContainsKey(link.Url))
            {
                dictionary.Add(link.Url, link);
            }
            else
            { 
                dictionary[link.Url] = link;
            }
        }

        public int RemoveLinks(string url)
        {
            IsEmpty();

            int count = 0;
            List<ILink> list = new List<ILink>(stack);

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Url.ToLower().Contains(url.ToLower()))
                {
                    list.Remove(list[i]);
                    count++;
                }
            }

            stack = new Stack<ILink>(list);

            return count;
        }

        public ILink[] ToArray()
        {
            return stack.ToArray();
        }

        public List<ILink> ToList()
        {
            List<ILink> list = new List<ILink>();

            var array = stack.ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                list.Add(array[i]);
            }

            return list;
        }

        public string ViewHistory()
        {
            if (Size == 0)
            {
                return "Browser history is empty!";
            }

            var copyArr = stack.ToArray();

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < copyArr.Length; i++)
            {
                sb.Append($"-- {copyArr[i].Url} {copyArr[i].LoadingTime}s{Environment.NewLine}");
            }

            return sb.ToString();
        }

        private void IsEmpty()
        {
            if (Size == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
