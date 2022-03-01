using FootballManager.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.Data.Models
{
    public class Player
    {
        [Key]
        [StringLength(Constraints.ID_LENGTH)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [StringLength(Constraints.PLAYER_FULLNAME_MAX_LENGTH)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength(Constraints.PLAYER_POSITION_MAX_LENGTH)]
        public string Position { get; set; }

        [Range(Constraints.PLAYER_SPEED_MIN_VALUE, Constraints.PLAYER_SPEED_MAX_VALUE)]
        public byte Speed { get; set; }

        [Range(Constraints.PLAYER_ENDURANCE_MIN_VALUE, Constraints.PLAYER_ENDURANCE_MAX_VALUE)]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(Constraints.PLAYER_DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        public virtual ICollection<UserPlayer> UserPlayers { get; set; }

        public Player()
        {
            UserPlayers = new List<UserPlayer>();
        }
    }
}
