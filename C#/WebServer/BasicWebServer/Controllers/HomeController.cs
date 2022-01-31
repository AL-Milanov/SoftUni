using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BasicWebServer.Controllers
{
    public class HomeController : Controller
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


        public HomeController(Request request)
            : base(request)
        {
        }

        public Response Index()
        {
            return Text("Wellcome from the server");
        }

        public Response Html()
        {
            return View();
        }

        public Response HtmlPost()
        {
            var formData = string.Empty;

            foreach (var kvp in Request.Form)
            {
                formData += $"{kvp.Key} - {kvp.Value}";
                formData += Environment.NewLine;

            }

            return Text(formData);
        }

        public Response Redirect()
        {
            return Redirect("https://softuni.bg/");
        }

        public Response Content()
        {
            return View();
        }

        public Response DownloadContent()
        {
            DownloadSitesAsTextFile(FileName, new string[]
            { "https://judge.softuni.org/", "https://softuni.org/" }).Wait();

            return File(FileName);
        }

        public Response Cookies()
        {
            var requestHasCookies = Request.Cookies.Any(
                c => c.Name != Server.HTTP.Session.SessionCookieName);
            var bodyText = "";

            if (requestHasCookies)
            {
                var cookieText = new StringBuilder();
                cookieText.AppendLine("<h1>Cookies</h1>");

                cookieText.Append("<table border='1'><tr><th>Name</th><th>Value</th></tr>");

                foreach (var cookie in Request.Cookies)
                {
                    cookieText.Append("<tr>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Name)}</td>");
                    cookieText
                        .Append($"<td>{HttpUtility.HtmlEncode(cookie.Value)}</td>");

                    cookieText.Append("</tr>");
                }

                bodyText = cookieText.ToString();

                return Html(bodyText);
            }

            var cookies = new CookieCollection();
            cookies.Add("My-Cookie", "My-Cookie-Value");
            cookies.Add("My-Second-Cookie", "My-Second-Cookie-Value");

            return Html("<h1>Cookies set!</h1>", cookies);
        }

        public Response Session()
        {
            var sessionExists = Request.Session.ContainsKey(Server.HTTP.Session.SessionCurrentDateKey);
            var bodyText = "";

            if (sessionExists)
            {
                var currentDate = Request.Session[Server.HTTP.Session.SessionCurrentDateKey];
                bodyText = $"Stored date: {currentDate}!";
            }
            else
            {
                bodyText = $"Current date stored!";
            }

            return Text(bodyText);
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

            await System.IO.File.WriteAllTextAsync(fileName, responseString);

        }

    }
}
