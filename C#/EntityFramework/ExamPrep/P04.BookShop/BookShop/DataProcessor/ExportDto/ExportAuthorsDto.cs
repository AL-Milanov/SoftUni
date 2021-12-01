using System.Collections.Generic;

namespace BookShop.DataProcessor.ExportDto
{
    public class ExportAuthorsDto
    {
        public string AuthorName { get; set; }

        public List<ExportBooksDto> Books{ get; set; }
    }
}
