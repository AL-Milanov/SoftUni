using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto
{
    [XmlType("Purchase")]
    public class ExportPurchasesDto
    {
        [XmlElement("Card")]
        public string Card { get; set; }

        [XmlElement("Cvc")]
        public string Cvc { get; set; }

        [XmlElement("Date")]
        public string Date { get; set; }

        [XmlElement("Game")]
        public ExportGameDto Game{ get; set; }
    }
}