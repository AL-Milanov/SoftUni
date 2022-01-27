using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicWebServer.Controllers
{
    public class UserController : Controller
    {

        private const string LoginForm = @"<form action='/Login' method='POST'> 
   Username: <input type='text' name='Username'/> 
   Password: <input type='text' name='Password'/> 
   <input type='submit' value ='Log In' />  
</form>";

        private const string Username = "user";

        private const string Password = "user123";


        public UserController(Request request) : base(request)
        {
        }

        public Response Login()
        {
            return Html(LoginForm);
        }

        public Response LoginUser()
        {
            Request.Session.Clear();

            var usernameMatches = Request.Form["Username"] == Username;
            var passwordMatches = Request.Form["Password"] == Password;

            if (usernameMatches && passwordMatches)
            {
                var bodyText = "<h3>Logged successfully!</h3>";

                if (Request.Session.ContainsKey(Session.SessionUserKey))
                {
                    return Html(bodyText);
                }

                Request.Session[Session.SessionUserKey] = "MyUserId";

                var cookies = new CookieCollection();
                cookies.Add(Session.SessionUserKey, Request.Session.Id);


                return Html(bodyText, cookies);
            }

            return Redirect("/Login");
        }

        public Response Logout()
        {
            Request.Session.Clear();

            var responseBody = "<h3>Logged out successfully!</h3>";

            return Html(responseBody);
        }

        public Response GetUserData()
        {
            var responseBody = string.Empty;

            if (Request.Session.ContainsKey(Session.SessionUserKey))
            {
                responseBody += $"<h3>Currently logged-in user " +
                    $"is with username '{Username}'</h3>";
            }
            else
            {
                responseBody += "<h3>You should first log in " +
                    "- <a href='/Login'>Login</a></h3>";
            }

            return Html(responseBody);
        }

    }
}
