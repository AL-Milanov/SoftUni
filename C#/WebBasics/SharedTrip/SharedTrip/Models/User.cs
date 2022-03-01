using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class User
    {
        public User()
        {
            UserTrips = new List<UserTrip>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Username { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength (20, MinimumLength = 6)]
        public string Password { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
