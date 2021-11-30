using SoftJail.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.DataProcessor.ImportDto
{
    public class ImportDepartmentDto
    {
        [Required]
        [StringLength(Constraints.DEPARTMENT_NAME_MAX_LENGTH,
            MinimumLength = Constraints.DEPARTMENT_NAME_MIN_LENGTH)]
        public string Name { get; set; }

        [MinLength(1)]
        public List<ImportCellDto> Cells { get; set; }
    }
}
