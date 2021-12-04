using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTheatreDto
    {
        [Required]
        [StringLength(Constraints.THEATRE_NAME_MAX_LENGTH,
            MinimumLength = Constraints.THEATRE_NAME_MIN_LENGTH)]
        public string Name { get; set; }

        [Required]
        [Range(Constraints.THEATRE_NUMBER_OF_HALLS_MIN, Constraints.THEATRE_NUMBER_OF_HALLS_MAX)]
        public sbyte NumberOfHalls { get; set; }

        [Required]
        [StringLength(Constraints.THEATRE_DIRECTOR_MAX_LENGTH,
            MinimumLength = Constraints.THEATRE_DIRECTOR_MIN_LENGTH)]
        public string Director { get; set; }

        public List<ImportTicketsDto> Tickets { get; set; }
    }
}
