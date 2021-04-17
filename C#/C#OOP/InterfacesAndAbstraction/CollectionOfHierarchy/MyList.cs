using CollectionOfHierarchy.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace CollectionOfHierarchy
{
    public class MyList : IAdd, IRemove
    {
        private const int FirstIndex = 0;
        private List<string> list;
        
        public MyList()
        {
            list = new List<string>();
        }

        public int Used => list.Count;

        public int Add(string text)
        {
            list.Insert(0, text);

            return list.IndexOf(text);
        }

        public string Remove()
        {
            string first = list[FirstIndex];
            list.RemoveAt(FirstIndex);

            return first;
        }
    }
}
