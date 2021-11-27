namespace TeisterMask.DataProcessor
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {

        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            throw new NotImplementedException();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var busiestEmployeesDto = context.Employees
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .ToList()
                .Select(e => new ExportBusiestEmployeesDto
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                            .Where(t => t.Task.OpenDate >= date)
                            .OrderByDescending(t => t.Task.DueDate)
                            .ThenBy(t => t.Task.Name)
                            .Select(Mapper.Map<ExportTasksDto>)
                            .ToList()
                })
                .OrderByDescending(e => e.Tasks.Count)
                .ThenBy(e => e.Username)
                .Take(10)
                .ToList();

            var employeeJson = JsonConvert.SerializeObject(busiestEmployeesDto, Formatting.Indented);

            return employeeJson;
        }
    }
}