using SoftJail.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class Department
    {
        public Department()
        {
            Cells = new List<Cell>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(Constraints.DEPARTMENT_NAME_MAX_LENGTH)]
        public string Name { get; set; }

        public virtual ICollection<Cell> Cells{ get; set; }
    }
}