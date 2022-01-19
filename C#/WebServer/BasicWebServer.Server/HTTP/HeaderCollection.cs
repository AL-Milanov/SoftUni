using System.Collections;
using System.Collections.Generic;

namespace BasicWebServer.Server.HTTP
{
    public class HeaderCollection : IEnumerable<Header>
    {
        private readonly Dictionary<string, Header> headers;

        public HeaderCollection()
        {
            headers = new Dictionary<string, Header>();
        }

        public string this[string name] => headers[name].Value;

        public int Count => headers.Count;

        public void Add(string name, string value)
        {
            headers[name] = new Header(name, value);
        }

        public bool Contains(string name) => headers.ContainsKey(name);

        public IEnumerator<Header> GetEnumerator()
        {
            return headers.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
