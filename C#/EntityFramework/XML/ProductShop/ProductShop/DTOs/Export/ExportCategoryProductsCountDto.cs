﻿namespace ProductShop.DTOs.Export
{
    using System.Xml.Serialization;

    [XmlType("Category")]
    public class ExportCategoryProductsCountDto
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("count")]
        public int Count { get; set; }

        [XmlElement("averagePrice")]
        public string AveragePrice { get; set; }

        [XmlElement("totalRevenue")]
        public decimal TotalRevenue { get; set; }
    }
}
