using BasicWebServer.Server.Attributes;
using BasicWebServer.Server.Controllers;
using BasicWebServer.Server.HTTP;
using FootballManager.Contracts;
using FootballManager.ViewModels;

namespace FootballManager.Controllers
{
    public class PlayersController : Controller
    {
        private IPlayerService _playerService;

        public PlayersController(Request request,
            IPlayerService playerService)
            : base(request)
        {
            _playerService = playerService;
        }

        [Authorize]
        public Response All()
        {
            var allPlayers = _playerService.GetPlayers();

            return View(new
            {
                User.IsAuthenticated,
                allPlayers
            });
        }

        [Authorize]
        public Response Add()
        {
            return View(new { User.IsAuthenticated });
        }

        [Authorize]
        [HttpPost]
        public Response Add(AddPlayerViewModel model)
        {
            var (isCreated, error) = _playerService.CreatePlayer(model, User.Id);

            if (!isCreated)
            {
                return Redirect("/Players/Add");
            }

            return Redirect("/Players/All");

        }

        [Authorize]
        public Response Collection()
        {
            var userPlayers = _playerService.GetUserPlayers(User.Id);

            return View(new
            {
                User.IsAuthenticated,
                userPlayers
            });
        }

        [Authorize]
        public Response RemoveFromCollection(string playerId)
        {
            _playerService.RemovePlayerFromUserCollection(
                User.Id, playerId);

            return Redirect("/Players/Collection");
        }

        [Authorize]
        public Response AddToCollection(string playerId)
        {
            _playerService.AddPlayerToUserCollection(
                User.Id, playerId);

            return Redirect("/Players/All");
        }
    }
}
