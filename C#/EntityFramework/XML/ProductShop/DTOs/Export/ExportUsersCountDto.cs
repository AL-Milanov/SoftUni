namespace ProductShop.DTOs.Export
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    [XmlType("Users")]
    public class ExportUsersCountDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public List<ExportUserInfoDto> Users { get; set; }
    }
}
