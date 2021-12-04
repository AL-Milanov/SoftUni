using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class ImportCastsDto
    {
        [XmlElement("FullName")]
        [Required]
        [StringLength(Constraints.CAST_FULLNAME_MAX_LENGTH,
            MinimumLength = Constraints.CAST_FULLNAME_MIN_LENGTH)]
        public string FullName { get; set; }

        [XmlElement("IsMainCharacter")]
        [Required]
        public string IsMainCharacter { get; set; }

        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(Constraints.CAST_PHONE_REGEX)]
        public string PhoneNumber { get; set; }

        [XmlElement("PlayId")]
        [Required]
        public int PlayId { get; set; }
    }
}
