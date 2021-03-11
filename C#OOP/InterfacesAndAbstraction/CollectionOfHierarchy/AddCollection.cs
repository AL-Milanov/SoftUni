using CollectionOfHierarchy.Contracts;
using System.Collections;
using System.Collections.Generic;

namespace CollectionOfHierarchy
{
    public class AddCollection : IAdd
    {
        private List<string> list;

        public AddCollection()
        {
            list = new List<string>();
        }

        public string Add(string text)
        {
            list.Add(text);
            return $"{list.IndexOf(text)}";
        }

    }
}
