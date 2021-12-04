using System.ComponentModel.DataAnnotations;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    public class ImportTicketsDto
    {
        [Required]
        [Range(Constraints.TICKETS_PRICE_MIN, Constraints.TICKETS_PRICE_MAX)]
        public decimal Price { get; set; }

        [Required]
        [Range(Constraints.TICKETS_ROW_NUMBER_MIN, Constraints.TICKETS_ROW_NUMBER_MAX)]
        public sbyte RowNumber { get; set; }

        [Required]
        public int PlayId { get; set; }
    }
}