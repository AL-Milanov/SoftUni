using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.Routing;
using BasicWebServer.Server.Routing.Contracts;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Server
{
    public class HttpServer
    {

        private readonly IPAddress ipAddress;

        private readonly int port;

        private readonly TcpListener listener;

        private readonly RoutingTable routingTable;

        public HttpServer(string ipAddress, int port, Action<IRoutingTable> routingTableConfig)
        {
            this.ipAddress = IPAddress.Parse(ipAddress);

            this.port = port;

            this.listener = new TcpListener(this.ipAddress, this.port);

            routingTableConfig(this.routingTable = new RoutingTable());
        }

        public HttpServer(int port, Action<IRoutingTable> routingTableConfig)
            : this("127.0.0.1", port, routingTableConfig)
        {

        }

        public HttpServer(Action<IRoutingTable> routingTableConfig)
            : this(8080, routingTableConfig)
        {

        }

        public async Task Start()
        {
            this.listener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests...");

            while (true)
            {
                var connection = await this.listener.AcceptTcpClientAsync();

                _ = Task.Run(async () =>
                 {
                     var networkStream = connection.GetStream();

                     var requestText = await ReadRequest(networkStream);

                     Console.WriteLine(requestText);

                     var request = Request.Parse(requestText);

                     var response = this.routingTable.MatchRequest(request);

                     if (response.PreRenderedAction != null)
                     {
                         response.PreRenderedAction(request, response);
                     }

                     AddSession(request, response);

                     await WriteResponse(networkStream, response);

                     connection.Close();
                 });
            }

        }

        private void AddSession(Request request, Response response)
        {
            var sessionExist = request.Session.ContainsKey(Session.SessionCurrentDateKey);

            if (!sessionExist)
            {
                request.Session[Session.SessionCurrentDateKey] = DateTime.Now.ToString();

                response.Cookies.Add(Session.SessionCookieName, request.Session.Id);
            }
        }

        private async Task WriteResponse(NetworkStream networkStream, Response response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);
        }

        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();
            var totalBytes = 0;

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);
                totalBytes += bytesRead;

                if (totalBytes > 10 * 1024)
                {
                    throw new InvalidOperationException("Request is to large");
                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (networkStream.DataAvailable);

            return requestBuilder.ToString();
        }
    }
}
