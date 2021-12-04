using System.Collections.Generic;

namespace Theatre.DataProcessor.ExportDto
{
    public class ExportTheatersDto
    {
        public string Name { get; set; }

        public sbyte Halls { get; set; }

        public decimal TotalIncome { get; set; }

        public List<ExportTicketsDto> Tickets { get; set; }
    }
}
