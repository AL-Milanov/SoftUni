using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        public Homework()
        {

        }

        [Key]
        [Required]
        public int HomeworkId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public Enum ContentType { get; set; }
        [Required]
        public DateTime SubmissionTime { get; set; }

        [Required]
        [ForeignKey("StudentId")]
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        [Required]
        [ForeignKey("CourseId")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

    }
}
