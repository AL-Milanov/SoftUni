using BasicWebServer.Server;
using BasicWebServer.Server.HTTP;
using BasicWebServer.Server.HTTP.ActionResponses;
using BasicWebServer.Server.HTTP.ContentResponses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BasicWebServer
{
    internal class StartUp
    {
        private const string HtmlForm = @"<form action='/HTML' method='POST'>
Name: <input type='text' name='Name'/>
Age: <input type='number' name='Age'/>
<input type='submit' value='Save' />
</form>";
        private const string DownloadForm = @"<form action='/Content' method='POST'> 
   <input type='submit' value ='Download Sites Content' />  
</form>";

        private const string FileName = "context.txt";

        public static async Task Main(string[] args)
        {
            await DownloadSitesAsTextFile(FileName, new string[] 
            { "https://judge.softuni.org/", "https://softuni.org/" });

            var server = new HttpServer(routes => routes
                   .MapGet("/", new TextResponse("Hello from the Server"))
                   .MapGet("/HTML", new HtmlResponse(HtmlForm))
                   .MapPost("/HTML", new TextResponse("", AddFormDataAction))
                   .MapGet("/Redirect", new RedirectResponse("https://softuni.bg/"))
                   .MapGet("/Content", new HtmlResponse(DownloadForm))
                   .MapPost("/Content", new TextFileResponse(FileName))
                   .MapGet("/Cookies", new HtmlResponse("", AddCookiesAction)));

            await server.Start();
        }

        private static void AddCookiesAction(Request request, Response response)
        {
            var requestHasCookies = request.Cookies.Any();
            var bodyText = "";

            if (requestHasCookies)
            {
                var cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");

                    cookieText.Append("</tr>");
                }

                bodyText = cookieText.ToString();
            }
            else
            {
                bodyText = "Cookies set!";
            }

            if (!requestHasCookies)
            {
                response.Cookies.Add("My-Cookie", "My-Value");
                response.Cookies.Add("Second-Cookie", "Second-Value");
            }

            response.Body = bodyText;
        }

        private static void AddFormDataAction(Request request, Response response)
        {
            response.Body = "";

            foreach (var kvp in request.Form)
            {
                response.Body += $"{kvp.Key} - {kvp.Value}";
                response.Body += Environment.NewLine;

            }
        }

        private static async Task<string> DownloadWebSiteContent(string url)
        {
            var httpClient = new HttpClient();

            using (httpClient)
            {
                var response = await httpClient.GetAsync(url);

                var html = await response.Content.ReadAsStringAsync();

                return html.Substring(0, 2000);
            }
        }

        private static async Task DownloadSitesAsTextFile(string fileName, string[] urls)
        {
            var downloads = new List<Task<string>>();


            foreach (var url in urls)
            {
                downloads.Add(DownloadWebSiteContent(url));
            }

            var responses = await Task.WhenAll(downloads);

            var responseString = string.Join(Environment.NewLine + new string('-', 100), responses);

            await File.WriteAllTextAsync(fileName, responseString);


        }
    }
}
