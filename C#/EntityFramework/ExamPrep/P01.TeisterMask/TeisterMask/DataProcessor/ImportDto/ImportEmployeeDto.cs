﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TeisterMask.DataProcessor.ImportDto
{
    public class ImportEmployeeDto
    {
        [Required]
        [StringLength(40, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("[0-9]{3}-[0-9]{3}-[0-9]{4}")]
        [StringLength(12)]
        public string Phone { get; set; }

        public List<int> Tasks { get; set; }
    }
}
