namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using AutoMapper;
    
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {

        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Projects");
            var xmlSerializer = new XmlSerializer(typeof(List<ExportProjectsDto>), xmlRoot);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter sw = new StringWriter(sb);

            var projectsDto = context.Projects
                .Where(p => p.Tasks.Any())
                .ToList()
                .Select(p => new ExportProjectsDto
                {
                    TaskCount = p.Tasks.Count,
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = Mapper.Map<List<ExportProjectsTasksDto>>(p.Tasks)
                        .OrderBy(t => t.Name)
                        .ToList()
                })
                .OrderByDescending(p => p.TaskCount)
                .ThenBy(p => p.ProjectName)
                .ToList();

            xmlSerializer.Serialize(sw, projectsDto, namespaces);
             
            return sb.ToString().TrimEnd();
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