using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public UsersController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public HttpResponse Register()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Register(User user)
        {
            user.Id = Guid.NewGuid().ToString();

            dbContext.Users.Add(user);
            dbContext.SaveChanges();

            return Redirect("Login");
        }

        public HttpResponse Login()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Login(User user)
        {
            return Redirect("/Trips/All");
        }
    }
}
