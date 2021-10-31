using P01_StudentSystem.Data.Models.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public Resource()
        {

        }

        [Key]
        public int ResourseId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
