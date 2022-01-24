using System.Collections;
using System.Collections.Generic;

namespace BasicWebServer.Server.HTTP
{
    public class CookieCollection : IEnumerable<Cookie>
    {

        private Dictionary<string, Cookie> cookies;

        public CookieCollection()
        {
            cookies = new();
        }

        public string this[string name] => cookies[name].Value;

        public void Add(string name, string value)
        {
            var cookie = new Cookie(name, value);

            cookies.Add(name, cookie);
        }

        public bool Contains(string name)
        {
            return cookies.ContainsKey(name);
        }

        public IEnumerator<Cookie> GetEnumerator()
        {
            return cookies.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
