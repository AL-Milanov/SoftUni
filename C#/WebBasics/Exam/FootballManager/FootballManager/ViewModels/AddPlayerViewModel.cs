using FootballManager.Common;
using System.ComponentModel.DataAnnotations;

namespace FootballManager.ViewModels
{
    public class AddPlayerViewModel
    {
        [Required]
        [StringLength(Constraints.PLAYER_FULLNAME_MAX_LENGTH,
            MinimumLength = Constraints.PLAYER_FULLNAME_MIN_LENGTH)]
        public string FullName { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [StringLength (Constraints.PLAYER_POSITION_MAX_LENGTH,
            MinimumLength = Constraints.PLAYER_POSITION_MIN_LENGTH)]
        public string Position { get; set; }

        [Required]
        [Range(Constraints.PLAYER_SPEED_MIN_VALUE,
            Constraints.PLAYER_SPEED_MAX_VALUE)]
        public byte Speed { get; set; }

        [Required]
        [Range(Constraints.PLAYER_ENDURANCE_MIN_VALUE,
            Constraints.PLAYER_ENDURANCE_MAX_VALUE)]
        public byte Endurance { get; set; }

        [Required]
        [StringLength(Constraints.PLAYER_DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }
    }
}
