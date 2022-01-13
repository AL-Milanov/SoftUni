using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicWebServer.Server.HTTP
{
    public class Request
    {
        public Method Method { get; private set; }

        public string Url { get; private set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; private set; }

        public static Request Parse(string request)
        {
            var lines = request.Split(Environment.NewLine);

            var startLine = lines.First().Split(" ");

            Method method = ParseMethod(startLine[0]);

            var url = startLine[1];

            var headers = ParseHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(headers.Count + 2).ToArray();

            var body = string.Join(Environment.NewLine, bodyLines);

            return new Request
            {
                Method = method,
                Url = url,
                Headers = headers,
                Body = body
            };
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
