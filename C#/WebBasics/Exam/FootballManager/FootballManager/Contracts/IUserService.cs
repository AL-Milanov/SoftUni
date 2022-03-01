using FootballManager.Models;

namespace FootballManager.Contracts
{
    public interface IUserService
    {
        (bool isValid, string message) Login(UserLoginViewModel model);

        string Register(UserRegisterViewModel model);
    }
}
