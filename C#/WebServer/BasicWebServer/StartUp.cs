using BasicWebServer.Server;
namespace BasicWebServer
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var server = new HTTPServer("127.0.0.1", 8080);

            server.Start();
        }
    }
}
