using AutoMapper;
using AutoMapper.QueryableExtensions;

using FastFood.Data;
using FastFood.Models;
using FastFood.Services.DTO.Employee;
using FastFood.Services.Interfaces;

using System.Collections.Generic;
using System.Linq;

namespace FastFood.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly FastFoodContext context;

        private readonly IMapper mapper;

        public EmployeeService(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void Create(CreateEmployeeDTO employeeDto)
        {
            var employee = mapper.Map<Employee>(employeeDto);

            context.Employees.Add(employee);
            context.SaveChanges();
        }

        public ICollection<AllEmployeeDTO> GetAll()
        {
            return context.Employees.ProjectTo<AllEmployeeDTO>(mapper.ConfigurationProvider).ToList();
        }

        public ICollection<EmployeePositionsIdDTO> GetPositionsDTO()
        {
            return context.Positions.ProjectTo<EmployeePositionsIdDTO>(mapper.ConfigurationProvider).ToList();
        }
    }
}
