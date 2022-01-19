using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        public IReadOnlyDictionary<string, string> Form { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split(Environment.NewLine);

            var startLine = lines.First().Split(" ");

            Method method = ParseMethod(startLine[0]);

            var url = startLine[1];

            var headers = ParseHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join(Environment.NewLine, bodyLines);

            Dictionary<string, string> form = ParseForm(headers, body);

            return new Request
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body,
                Form = form
            };
        }

        private static Dictionary<string, string> ParseForm(HeaderCollection headers, string body)
        {
            var formCollection = new Dictionary<string, string>();

            if (headers.Contains(Header.ContentType)
                && headers[Header.ContentType] == ContentType.FormUrlEncoded)
            {
                Dictionary<string, string> parsedResult = ParseFromData(body);

                foreach (var kvp in parsedResult)
                {
                    formCollection.Add(kvp.Key, kvp.Value);
                }
            }

            return formCollection;
        }

        private static Dictionary<string, string> ParseFromData(string body)
        {
            return HttpUtility.UrlDecode(body)
                .Split("&")
                .Select(part => part.Split("="))
                .Where(part => part.Length == 2)
                .ToDictionary(part => part[0], 
                              part => part[1],
                              StringComparer.InvariantCultureIgnoreCase);
        }

        private static HeaderCollection ParseHeaders(IEnumerable<string> headers)
        { 
            var headerCollection = new HeaderCollection();

            foreach (var line in headers)
            {
                if (line == string.Empty)
                {
                    break;
                }

                var headersParts = line.Split(":", 2);

                if (headersParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is invalid");
                }

                var name = headersParts[0];
                var value = headersParts[1];

                headerCollection.Add(name, value);
            }

            return headerCollection;
        }

        private static Method ParseMethod(string method)
        {
            try
            {

                return Enum.Parse<Method>(method.ToUpper());
            }
            catch (Exception)
            {

                throw new InvalidOperationException($"Method {method} is not supported");
            }
        }
    }
}
