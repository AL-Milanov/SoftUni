using BookShop.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace BookShop.DataProcessor.ImportDto
{
    [XmlType("Book")]
    public class ImportBookDto
    {
        [XmlElement("Name")]
        [Required]
        [StringLength(Constraints.BOOK_NAME_MAX_LENGTH,
            MinimumLength = Constraints.BOOK_NAME_MIN_LENGTH)]
        public string Name { get; set; }

        [XmlElement("Genre")]
        [Required]
        [Range(Constraints.BOOK_GENRE_ENUM_MIN, Constraints.BOOK_GENRE_ENUM_MAX)]
        public int Genre { get; set; }

        [XmlElement("Price")]
        [Required]
        [Range(Constraints.BOOK_PRICE_MIN_VALUE, Constraints.BOOK_PRICE_MAX_VALUE)]
        public decimal Price { get; set; }

        [XmlElement("Pages")]
        [Required]
        [Range(Constraints.BOOK_PAGE_MIN_VALUE, Constraints.BOOK_PAGE_MAX_VALUE)]
        public int Pages { get; set; }

        [XmlElement("PublishedOn")]
        [Required]
        public string PublishedOn { get; set; }
    }
}
