using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.Models;

namespace FootballManager.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(Request request,
            IUserService userService)
            : base(request)
        {
            _userService = userService;
        }

        public Response Register()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View(new { User.IsAuthenticated });
        }

        [HttpPost]
        public Response Register(UserRegisterViewModel model)
        {
            var result = _userService.Register(model);

            if (!string.IsNullOrWhiteSpace(result))
            {
                return View(new { User.IsAuthenticated });
            }

            return Redirect("/Users/Login");
        }

        public Response Login()
        {
            if (User.IsAuthenticated)
            {
                return Redirect("/Players/All");
            }

            return View(new { User.IsAuthenticated });
        }

        [HttpPost]
        public Response Login(UserLoginViewModel model)
        {
            Request.Session.Clear();

            var (isValid, userId) = _userService.Login(model);

            if (!isValid)
            {
                return View(new { User.IsAuthenticated });
            }

            SignIn(userId);
            
            return Redirect("/Players/All");
        }

        [Authorize]
        public Response Logout()
        {
            SignOut();

            return Redirect("/");
        }
    }
}
