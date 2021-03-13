using CollectionOfHierarchy.Contracts;
using System.Collections.Generic;

namespace CollectionOfHierarchy
{
    public class AddRemoveCollection : IAdd, IRemove 
    {
        private List<string> list;

        public AddRemoveCollection()
        {
            list = new List<string>();
        }

        private int LastIndex => list.Count - 1;

        public int Add(string text)
        {
            list.Insert(0, text);

            return list.IndexOf(text);
        }

        public string Remove()
        {
            string last = list[LastIndex];
            list.RemoveAt(LastIndex);
            return last;
        }

    }
}
