using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using Theatre.Common;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class ImportPlayDto
    {
        [XmlElement("Title")]
        [Required]
        [StringLength(Constraints.PLAY_TITLE_MAX_LENGTH,
            MinimumLength = Constraints.PLAY_TITLE_MIN_LENGTH)]
        public string Title { get; set; }

        [XmlElement("Duration")]
        [Required]
        public string Duration { get; set; }

        [XmlElement("Rating")]
        [Required]
        [Range(Constraints.PLAY_RATING_MIN, Constraints.PLAY_RATING_MAX)]
        public float Rating { get; set; }

        [XmlElement("Genre")]
        [Required]
        public string Genre { get; set; }

        [XmlElement("Description")]
        [Required]
        [StringLength(Constraints.PLAY_DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        [XmlElement("Screenwriter")]
        [Required]
        [StringLength(Constraints.PLAY_SCREENWRITER_MAX_LENGTH,
            MinimumLength = Constraints.PLAY_SCREENWRITER_MIN_LENGTH)]
        public string Screenwriter { get; set; }
    }
}
