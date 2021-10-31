﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        public StudentCourse()
        {

        }

        [Required]
        [ForeignKey("Student")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course{ get; set; }

    }
}
