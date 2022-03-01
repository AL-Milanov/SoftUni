using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FootballManager.Services
{
    public class PlayerService : IPlayerService
    {
        private IRepository _repo;
        private IValidationService _validationService;

        public PlayerService(IRepository repo,
            IValidationService validationService)
        {
            _repo = repo;
            _validationService = validationService;
        }

        public bool AddPlayerToUserCollection(string userId, string playerId)
        {
            var user = _repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .FirstOrDefault();

            var player = _repo.All<Player>()
                .Where(u => u.Id == playerId)
                .Include(u => u.UserPlayers)
                .FirstOrDefault();

            if (user != null && player != null)
            {
                var userPlayer = new UserPlayer()
                {
                    Player = player,
                    User = user,
                };

                user.UserPlayers.Add(userPlayer);

                try
                {
                    _repo.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }

                return true;
            }

            return false;
        }

        public (bool created, string error) CreatePlayer(AddPlayerViewModel model, string userID)
        {
            var (isValid, error) = _validationService.ValidateModel(model);

            if (!isValid)
            {
                return (isValid, error);
            }

            var user = _repo.All<User>()
                .Where(u => u.Id == userID)
                .Include(u => u.UserPlayers)
                .FirstOrDefault();

            var player = new Player()
            {
                FullName = model.FullName,
                Speed = model.Speed,
                Position = model.Position,
                Description = model.Description,
                Endurance = model.Endurance,
                ImageUrl = model.ImageUrl,
            };

            var userPlayer = new UserPlayer()
            {
                Player = player,
                User = user
            };

            user.UserPlayers.Add(userPlayer);

            try
            {
                _repo.SaveChanges();
            }
            catch (Exception)
            {
                return (false, error);
            }

            return (isValid, error);
        }

        public IEnumerable<PlayerListViewModel> GetPlayers()
        {
            return _repo.All<Player>()
                .Select(p => new PlayerListViewModel
                {
                    Description = p.Description,
                    Endurance = p.Endurance,
                    FullName = p.FullName,
                    ImageUrl = p.ImageUrl,
                    Speed = p.Speed,
                    Id = p.Id,
                    Position = p.Position
                })
                .ToList();
        }

        public IEnumerable<PlayerListViewModel> GetUserPlayers(string userId)
        {
            var user = _repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .ThenInclude(u => u.Player)
                .FirstOrDefault();

            var userPlayersView = user.UserPlayers
                .Select(u => new PlayerListViewModel
                {
                    Description = u.Player.Description,
                    Endurance = u.Player.Endurance,
                    FullName = u.Player.FullName,
                    ImageUrl = u.Player.ImageUrl,
                    Speed = u.Player.Speed,
                    Id = u.Player.Id,
                    Position = u.Player.Position
                })
                .ToList();

            return userPlayersView;
        }

        public bool RemovePlayerFromUserCollection(string userId, string playerId)
        {
            var user = _repo.All<User>()
                .Where(u => u.Id == userId)
                .Include(u => u.UserPlayers)
                .ThenInclude(u => u.Player)
                .FirstOrDefault();

            if (user != null)
            {
                if (user.UserPlayers.Any(p => p.PlayerId == playerId))
                {
                    var player = user.UserPlayers.FirstOrDefault(p => p.PlayerId == playerId);

                    user.UserPlayers.Remove(player);

                    try
                    {
                        _repo.SaveChanges();
                    }
                    catch (Exception)
                    {
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
