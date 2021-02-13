using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private List<Employee> employees;

        public Bakery(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.employees = new List<Employee>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => employees.Count;

        public void Add(Employee employee)
        {
            if (this.employees.Count < Capacity)
            {
                this.employees.Add(employee);
            }
        }

        public bool Remove(string name)// ?
        {
            Employee employee = employees.Where(n => n.Name == name).FirstOrDefault();

            if (employee == null)
            {
                return false;
            }

            employees.Remove(employee);
            return true;
        }

        public Employee GetOldestEmployee()
        {
            Employee employee = employees.OrderByDescending(a => a.Age).FirstOrDefault();

            return employee;
        }

        public Employee GetEmployee(string name)
        {
            Employee employee = employees.Where(n => n.Name == name).FirstOrDefault();

            return employee;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee}");
            }
            return sb.ToString();
        }
    }
}
