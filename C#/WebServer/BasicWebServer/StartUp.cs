using BasicWebServer.Controllers;
using BasicWebServer.Server;
using BasicWebServer.Server.Controllers;
using System.Threading.Tasks;

namespace BasicWebServer
{
    internal class StartUp
    {

        public static async Task Main(string[] args)
        {
            
            var server = new HttpServer(routes => routes
                   .MapGet<HomeController>("/", c => c.Index())
                   .MapGet<HomeController>("/HTML", c => c.Html())
                   .MapPost<HomeController>("/HTML", c => c.HtmlFromPost())
                   .MapGet<HomeController>("/Redirect", c => c.Redirect())
                   .MapGet<HomeController>("/Content", c => c.Content())
                   .MapPost<HomeController>("/Content", c => c.DownloadContent())
                   .MapGet<HomeController>("/Cookies", c => c.Cookies())
                   .MapGet<HomeController>("/Session", c => c.Session())
                   .MapGet<UserController>("/Login", c => c.Login())
                   .MapPost<UserController>("/Login", c => c.LoginUser())
                   .MapGet<UserController>("/Logout", c => c.Logout())
                   .MapGet<UserController>("/UserProfile", c => c.GetUserData()));

            await server.Start();
        }

    }
}
