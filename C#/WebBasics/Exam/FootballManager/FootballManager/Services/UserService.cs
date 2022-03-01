using FootballManager.Contracts;
using FootballManager.Data.Common;
using FootballManager.Data.Models;
using FootballManager.Models;
using System.Security.Cryptography;
using System.Text;

namespace FootballManager.Services
{
    public class UserService : IUserService
    {
        private IRepository _repo;
        private IValidationService _validationService;

        public UserService(IRepository repo,
            IValidationService validationService)
        {
            _repo = repo;
            _validationService = validationService;
        }

        public (bool isValid, string message) Login(UserLoginViewModel model)
        {
            var user = _repo.All<User>()
                .Where(u => u.Username == model.Username &&
                u.Password == CalculateHash(model.Password))
                .FirstOrDefault();

            bool isValid = false;
            string message = null;

            if (user == null)
            {
                message = "Invalid username or password.";
                return (isValid, message);
            }

            isValid = true;
            message = user.Id;

            return (isValid, message);
        }

        public string Register(UserRegisterViewModel model)
        {
            var (isValid, error) = _validationService.ValidateModel(model);

            if (!isValid)
            {
                return error;
            }

            var user = new User()
            {
                Username = model.Username,
                Email = model.Email,
                Password = CalculateHash(model.Password),
            };

            _repo.Add(user);

            var isSaved = _repo.SaveChanges();

            if (isSaved != 0)
            {
                error += "User already exists!";
            }

            return error;
        }

        private string CalculateHash(string password)
        {
            byte[] passworArray = Encoding.UTF8.GetBytes(password);

            using (SHA256 sha256 = SHA256.Create())
            {
                return Convert.ToBase64String(sha256.ComputeHash(passworArray));
            }
        }
    }
}
