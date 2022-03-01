using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;

namespace FootballManager.Controllers
{

    public class HomeController : Controller
    {
        public HomeController(Request request)
            : base(request)
        {

        }

        public Response Index()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View(new { User.IsAuthenticated });
        }
    }
}