using SoftJail.Common;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportCellDto
    {
        [Required]
        [Range(Constraints.CELL_NUMBER_MIN_VALUE, 
            Constraints.CELL_NUMBER_MAX_VALUE)]
        public int CellNumber { get; set; }

        [Required]
        public string HasWindow { get; set; }
    }
}