﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public Resource()
        {

        }

        [Key]
        [Required]
        public int ResourseId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public Enum ResourceType { get; set; }

        [Required]
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
