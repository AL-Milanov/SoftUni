using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.Data.Models
{
    public class Theatre
    {
        public Theatre()
        {
            Tickets = new List<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Constraints.THEATRE_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        [Required]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(Constraints.THEATRE_DIRECTOR_MAX_LENGTH)]
        public string Director { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
