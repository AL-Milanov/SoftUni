using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VaporStore.Common;

namespace VaporStore.Data.Models
{
    public class User
    {
        public User()
        {
            Cards = new List<Card>();
        }

        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(Constraints.USER_NAME_MAX_LENGTH)]
        public string Username { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public int Age { get; set; }

        public virtual List<Card> Cards{ get; set; }
    }
}
