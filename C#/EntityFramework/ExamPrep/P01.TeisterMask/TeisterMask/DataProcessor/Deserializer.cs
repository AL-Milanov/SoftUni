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
                if (!IsValid(projectDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isProjectOpenDateValid = DateTime.TryParseExact(projectDto.OpenDate,
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime projectOpenDate);

                if (!isProjectOpenDateValid)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var isProjectDueDateValid = DateTime.TryParseExact((projectDto.DueDate),
                    "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dueDate);

                DateTime? projectDueDate = dueDate;

                var project = new Project()
                {
                    Name = projectDto.Name,
                    OpenDate = projectOpenDate,
                    DueDate = string.IsNullOrWhiteSpace(projectDto.DueDate) ? null : projectDueDate,
                };

                project.Tasks = new List<Task>();

                foreach (var taskDto in projectDto.Tasks)
                {
                    if (!IsValid(taskDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var isTaskOpenDateValid = DateTime.TryParseExact(taskDto.OpenDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskOpenDate);

                    var isTaskDueDateValid = DateTime.TryParseExact(taskDto.DueDate,
                        "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime taskDueDate);

                    if (!isTaskOpenDateValid || !isTaskDueDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < project.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (projectDueDate.HasValue && taskDueDate > project.DueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task()
                    {
                        Name = taskDto.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)taskDto.ExecutionType,
                        LabelType = (LabelType)taskDto.LabelType,
                    };

                    project.Tasks.Add(task);
                }

                projects.Add(project);

                sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
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