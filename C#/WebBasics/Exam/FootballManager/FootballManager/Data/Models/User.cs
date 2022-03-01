using FootballManager.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class User
    {
        [Key]
        [StringLength(Constraints.ID_LENGTH)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constraints.USER_USERNAME_MAX_LENGTH)]
        public string Username { get; set; }

        [Required]
        [StringLength(Constraints.USER_EMAIL_MAX_LENGTH)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<UserPlayer> UserPlayers { get; set; }

        public User()
        {
            UserPlayers = new List<UserPlayer>();
        }
    }
}
