using System.Collections.Generic;

namespace SoftJail.DataProcessor.ExportDto
{
    public class ExportPrisonersByCellsDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CellNumber { get; set; }

        public List<ExportOfficerDto> Officers { get; set; }

        public decimal TotalOfficerSalary { get; set; }
    }
}
