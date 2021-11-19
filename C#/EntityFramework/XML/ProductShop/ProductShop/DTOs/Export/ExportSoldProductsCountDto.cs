namespace ProductShop.DTOs.Export
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class ExportSoldProductsCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("products")]
        public List<ExportSoldProductsDto> Products { get; set; }
    }
}
