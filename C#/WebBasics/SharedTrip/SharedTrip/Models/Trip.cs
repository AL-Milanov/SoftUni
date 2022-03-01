using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Models
{
    public class Trip
    {
        public Trip()
        {
            UserTrips = new List<UserTrip>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public string StartPoint { get; set; }

        [Required]
        public string EndPoint { get; set; }

        public DateTime DepartureTime { get; set; }

        [MinLength(2)]
        [MaxLength(6)]
        public int Seats { get; set; }

        [StringLength(80)]
        public string Description { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public ICollection<UserTrip> UserTrips { get; set; }
    }
}
