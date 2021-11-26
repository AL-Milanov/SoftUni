using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.Data.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(40)]
        public string Name { get; set; }

        public DateTime OpenDate{ get; set; }

        public DateTime? DueDate{ get; set; }

        public ICollection<Task> Tasks { get; set; }
    }
}
