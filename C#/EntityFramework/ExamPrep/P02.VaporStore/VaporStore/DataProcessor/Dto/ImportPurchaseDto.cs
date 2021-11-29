using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;
using VaporStore.Common;

namespace VaporStore.DataProcessor.Dto
{
    [XmlType("Purchase")]
    public class ImportPurchaseDto
    {
        [XmlAttribute("title")]
        [Required]
        public string GameTitle { get; set; }

        [XmlElement("Type")]
        [Required]
        public string Type { get; set; }

        [XmlElement("Key")]
        [Required]
        [RegularExpression(Constraints.PURCHASE_PRODUCTKEY_REGEX)]
        public string ProductKey { get; set; }

        [XmlElement("Card")]
        [Required]
        public string Card { get; set; }

        [XmlElement("Date")]
        [Required]
        public string Date { get; set; }

    }
}
