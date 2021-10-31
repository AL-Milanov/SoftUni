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
        public int ResourceId { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public ResourceType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }


    }
}
