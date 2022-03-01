using System.ComponentModel.DataAnnotations.Schema;

namespace FootballManager.Data.Models
{
    public class UserPlayer
    {
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        public string PlayerId { get; set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; }
    }
}