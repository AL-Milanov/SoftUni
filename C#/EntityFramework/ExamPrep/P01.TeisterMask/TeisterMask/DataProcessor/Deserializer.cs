namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            var xmlRoot = new XmlRootAttribute("Projects");
            var xmlSerializer = new XmlSerializer(typeof(List<ImportProjectsDto>), xmlRoot);

            var projectsDto = (List<ImportProjectsDto>)xmlSerializer.Deserialize(new StringReader(xmlString));
            var projects = new List<Project>();

            foreach (var projectDto in projectsDto)
            {
                if (IsValid(projectDto))
                {
                    var project = new Project()
                    {
                        Name = projectDto.Name,
                        OpenDate = DateTime.Parse(projectDto.OpenDate),
                        DueDate = string.IsNullOrEmpty(projectDto.DueDate) ?
                        (DateTime?)null : DateTime.Parse(projectDto.DueDate),
                    };

                    project.Tasks = new List<Task>();

                    foreach (var taskDto in projectDto.Tasks)
                    {
                        if (IsValid(taskDto))
                        {
                            if (DateTime.Parse(taskDto.OpenDate) < project.OpenDate ||
                            DateTime.Parse(taskDto.DueDate) > project.DueDate)
                            {
                                sb.AppendLine(ErrorMessage);
                                continue;
                            }

                            var task = new Task()
                            {
                                Name = taskDto.Name,
                                OpenDate = DateTime.Parse(taskDto.OpenDate),
                                DueDate = DateTime.Parse(taskDto.DueDate),
                                ExecutionType = (ExecutionType)taskDto.ExecutionType,
                                LabelType = (LabelType)taskDto.LabelType,
                            };

                            project.Tasks.Add(task);

                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                    }

                    projects.Add(project);

                    sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();
            
            var employeesDto = JsonConvert.DeserializeObject<List<ImportEmployeeDto>>(jsonString);

            var employees = new List<Employee>();

            foreach (var employeeDto in employeesDto)
            {
                if (IsValid(employeeDto))
                {
                    var employee = new Employee()
                    {
                        Username = employeeDto.Username,
                        Email = employeeDto.Email,
                        Phone = employeeDto.Phone,
                    };

                    employee.EmployeesTasks = new List<EmployeeTask>();

                    foreach (var taskId in employeeDto.Tasks.Distinct())
                    {
                        if (context.Tasks.Any(t => t.Id == taskId))
                        {
                            employee.EmployeesTasks.Add(new EmployeeTask()
                            {
                                TaskId = taskId,
                                Employee = employee
                            });
                        }
                        else
                        {
                            sb.AppendLine(ErrorMessage);
                        }
                    }

                    employees.Add(employee);
                    
                    sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
                
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}