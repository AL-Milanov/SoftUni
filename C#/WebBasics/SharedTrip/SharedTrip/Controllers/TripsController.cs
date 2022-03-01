using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public TripsController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        public HttpResponse Add()
        {
            return View();
        }

        [HttpPost]
        public HttpResponse Add(Trip trip)
        {
            dbContext.Trips.Add(trip);
            dbContext.SaveChanges();

            return View();
        }

        [HttpGet]
        public HttpResponse All()
        {
            var trips = dbContext.Trips.ToList();

            return View(trips);
        }

        [HttpGet]
        public HttpResponse Details(Trip tripFromView)
        {
            var trip = dbContext.Trips.FirstOrDefault(t => t.Id == tripFromView.Id);

            return View(trip);
        }
    }
}
