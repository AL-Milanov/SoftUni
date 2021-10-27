using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUni
{
    public class StartUp
    {
        static async Task Main(string[] args)
        {
            var dbContext = new SoftUniContext();

            Console.WriteLine(RemoveTown(dbContext));
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesIfno = context.Employees.ToList();

            foreach (var employee in employeesIfno)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesIfno = context.Employees.Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .Select(e => new
                {
                    FirsName = e.FirstName,
                    Salary = e.Salary
                }).ToList();

            foreach (var employee in employeesIfno)
            {
                sb.AppendLine($"{employee.FirsName} - {employee.Salary:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesIfno = context.Employees.Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    FullName = $"{e.FirstName} {e.LastName}",
                    DepartmentName = e.Department.Name,
                    Salary = e.Salary
                }).ToList();

            foreach (var employee in employeesIfno)
            {
                sb.AppendLine($"{employee.FullName} from {employee.DepartmentName} - ${employee.Salary:f2}");
            }

            return sb.ToString();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Address address = new Address() { AddressText = "Vitoshka 15", TownId = 4 };
            var employee = context.Employees.Where(e => e.LastName == "Nakov").FirstOrDefault();
            employee.Address = address;

            context.Employees.Update(employee);
            context.SaveChanges();

            var employeeAddresses = context.Employees.OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)
                .ToList();

            sb.AppendJoin(Environment.NewLine, employeeAddresses);

            return sb.ToString().Trim();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();


            var employees = context.Employees
                .Include(e => e.Manager)
                .Include(e => e.EmployeesProjects)
                .ThenInclude(e => e.Project)
                .Where(e => e.EmployeesProjects
                            .Any(p => p.Project.StartDate.Year >= 2001 && p.Project.StartDate.Year <= 2003))
                .Take(10)
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - Manager: {employee.Manager.FirstName} {employee.Manager.LastName}");

                foreach (var project in employee.EmployeesProjects)
                {
                    sb.AppendLine($"--{project.Project.Name} - {project.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)} - {(project.Project.EndDate == null ? "not finished" : project.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture))}");
                }

            }

            return sb.ToString().Trim();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context.Addresses.OrderByDescending(a => a.Employees.Count)
                                             .ThenBy(a => a.Town.Name)
                                             .ThenBy(a => a.AddressText)
                                             .Take(10)
                                             .Select(a => new
                                             {
                                                 AddressText = a.AddressText,
                                                 TownName = a.Town.Name,
                                                 EmployeeCount = a.Employees.Count
                                             })
                                             .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().Trim();

        }

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employee147 = context.Employees.Where(e => e.EmployeeId == 147)
                                               .Include(e => e.EmployeesProjects)
                                               .ThenInclude(e => e.Project)
                                               .ToList();

            foreach (var employee in employee147)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");

                foreach (var project in employee.EmployeesProjects.OrderBy(p => p.Project.Name))
                {
                    sb.AppendLine($"{project.Project.Name}");
                }
            }

            return sb.ToString().Trim();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments.Where(d => d.Employees.Count > 5)
                                                 .Include(d => d.Employees)
                                                 .OrderBy(d => d.Employees.Count)
                                                 .ThenBy(d => d.Name)
                                                 .ToList();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.Manager.FirstName} {department.Manager.LastName}");

                foreach (var employee in department.Employees.OrderBy(e => e.FirstName).ThenBy(e => e.LastName))
                {
                    sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                }
            }


            return sb.ToString().Trim();
        }

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var lastTenProjects = context.Projects
                                         .OrderByDescending(p => p.StartDate)
                                         .Take(10)
                                         .OrderBy(p => p.Name)
                                         .Select(p => new
                                         {
                                             p.Name,
                                             p.Description,
                                             p.StartDate
                                         })
                                         .ToList();

            foreach (var project in lastTenProjects)
            {
                sb.AppendLine($"{project.Name}" + Environment.NewLine
                            + $"{project.Description}" + Environment.NewLine
                            + $"{project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departments = new string[4] {
                "Engineering", "Tool Design", "Marketing", "Information Services" };

            StringBuilder sb = new StringBuilder();

            var employeesToIncreaseSalary = context.Employees.Where(e => departments.Contains(e.Department.Name));

            foreach (var employee in employeesToIncreaseSalary)
            {
                employee.Salary *= 1.12M;
            }

            context.SaveChanges();

            var employeeInfo = employeesToIncreaseSalary
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    FullName = $"{e.FirstName} {e.LastName}",
                    Salary = e.Salary
                })
                .ToList();

            foreach (var employee in employeeInfo)
            {
                sb.AppendLine($"{employee.FullName} (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var saStringToUpper = "SA";

            StringBuilder sb = new StringBuilder();

            var employeesWithSa = context.Employees
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    JobTitle = e.JobTitle,
                    Salary = e.Salary,
                    FirstNameToUpper = e.FirstName.ToUpper()
                })
                .Where(e => e.FirstNameToUpper.StartsWith(saStringToUpper))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var employee in employeesWithSa)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle} - (${employee.Salary:f2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var projectIdToRemove = 2;
            StringBuilder sb = new StringBuilder();

            var employeeProjects = context.EmployeesProjects
                .Where(p => p.ProjectId == projectIdToRemove)
                .ToList();

            foreach (var employeeProject in employeeProjects)
            {
                context.EmployeesProjects.Remove(employeeProject);
            }

            context.SaveChanges();

            var projectToRemove = context.Projects.Where(p => p.ProjectId == projectIdToRemove).FirstOrDefault();
            context.Projects.Remove(projectToRemove);

            context.SaveChanges();

            var projects = context.Projects.Take(10).ToList();

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var townToRemove = "Seattle";

            var seattleTown = context.Towns.FirstOrDefault(t => t.Name == townToRemove);
            var addressesFromSeattle = context.Addresses.Where(a => a.Town == seattleTown).ToList();
            var employeesFromSeattle = context.Employees.Where(e => addressesFromSeattle.Contains(e.Address));

            foreach (var employee in employeesFromSeattle)
            {
                employee.Address = null;
            }

            foreach (var address in addressesFromSeattle)
            { 
                context.Addresses.Remove(address);
            }

            context.Towns.Remove(seattleTown);

            context.SaveChanges();

            return $"{addressesFromSeattle.Count} addresses in {townToRemove} were deleted";
        }
    }
}
