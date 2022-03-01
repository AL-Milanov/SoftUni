using FootballManager.ViewModels;

namespace FootballManager.Contracts
{
    public interface IPlayerService
    {
        (bool created, string error) CreatePlayer(AddPlayerViewModel model, string userID);

        IEnumerable<PlayerListViewModel> GetPlayers();

        IEnumerable<PlayerListViewModel> GetUserPlayers(string userId);

        bool RemovePlayerFromUserCollection(string userId, string playerId);

        bool AddPlayerToUserCollection(string userId, string playerId);
    }
}
