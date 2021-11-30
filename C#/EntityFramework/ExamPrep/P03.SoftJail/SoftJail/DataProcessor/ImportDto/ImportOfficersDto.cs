using SoftJail.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class ImportOfficersDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(Constraints.OFFICER_NAME_MAX_LENGTH,
            MinimumLength = Constraints.OFFICER_NAME_MIN_LENGTH)]
        public string Name { get; set; }

        [XmlElement("Money")]
        [Required]
        [Range(Constraints.OFFICER_SALARY_MIN_VALUE, 
            Constraints.OFFICER_SALARY_MAX_VALUE)]
        public decimal Salary { get; set; }

        [XmlElement("Position")]
        [Required]
        public string Position { get; set; }

        [XmlElement("Weapon")]
        [Required]
        public string Weapon { get; set; }

        [XmlElement("DepartmentId")]
        [Required]
        public int DepartmentId { get; set; }

        [XmlArray("Prisoners")]
        public List<ImportPrisonerIdsDto> Prisoners { get; set; }
    }
}
