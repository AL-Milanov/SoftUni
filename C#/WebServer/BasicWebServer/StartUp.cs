using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.ActionResponses;
using BasicWebServer.Server.HTTP.ContentResponses;
using System;

namespace BasicWebServer
{
    internal class StartUp
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
Name: <input type='text' name='Name'/>
Age: <input type='number' name='Age'/>
<input type='submit' value='Save' />
</form>";

        static void Main(string[] args) => new HttpServer(routes => routes
                .MapGet("/", new TextResponse("Hello from the Server"))
                .MapGet("/HTML", new HtmlResponse(HtmlForm))
                .MapPost("/HTML", new TextResponse("", AddFormDataAction))
                .MapGet("/Redirect", new RedirectResponse("https://softuni.bg/")))
                .Start();

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var kvp in request.Form)
            {
                response.Body += $"{kvp.Key} - {kvp.Value}";
                response.Body += Environment.NewLine;

            }
        }

    }
}
