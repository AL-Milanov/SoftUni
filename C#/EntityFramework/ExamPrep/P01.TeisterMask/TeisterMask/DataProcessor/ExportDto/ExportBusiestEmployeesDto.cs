using System.Collections.Generic;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportBusiestEmployeesDto
    {
        public string Username { get; set; }

        public List<ExportTasksDto> Tasks { get; set; }
    }
}
