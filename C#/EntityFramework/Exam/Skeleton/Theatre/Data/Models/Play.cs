using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;
using Theatre.Data.Models.Enums;

namespace Theatre.Data.Models
{
    public class Play
    {
        public Play()
        {
            Casts = new List<Cast>();
            Tickets = new List<Ticket>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Constraints.PLAY_TITLE_MAX_LENGTH)]
        public string Title { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public float Rating { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [StringLength(Constraints.PLAY_DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        [Required]
        [StringLength(Constraints.PLAY_SCREENWRITER_MAX_LENGTH)]
        public string Screenwriter { get; set; }

        public virtual ICollection<Cast> Casts { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
