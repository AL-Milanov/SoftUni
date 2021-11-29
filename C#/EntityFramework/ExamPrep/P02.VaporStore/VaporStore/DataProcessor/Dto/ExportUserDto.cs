using System.Collections.Generic;
using System.Xml.Serialization;

namespace VaporStore.DataProcessor.Dto
{
    [XmlType("User")]
    public class ExportUserDto
    {

        [XmlAttribute("username")]
        public string Username { get; set; }

        [XmlArray("Purchases")]
        public List<ExportPurchasesDto> Purchases{ get; set; }

        [XmlElement("TotalSpent")]
        public decimal TotalSpent {get; set; } 
    }
}
