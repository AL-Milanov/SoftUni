﻿using P01_StudentSystem.Data.Models.Enumerations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        public Homework()
        {

        }

        [Key]
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        public ContentType ContentType { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        public DateTime SubmissionTime { get; set; }

    }
}
