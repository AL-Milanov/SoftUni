namespace FastFood.Core.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using FastFood.Services.DTO.Employee;
    using FastFood.Services.Interfaces;
    using ViewModels.Employees;

    using AutoMapper;
    using Microsoft.AspNetCore.Mvc;


    public class EmployeesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEmployeeService employeeService;

        public EmployeesController(IMapper mapper, IEmployeeService employeeService)
        {
            this.mapper = mapper;
            this.employeeService = employeeService;
        }

        public IActionResult Register()
        {
            var positionsIdDto = employeeService.GetPositionsDTO();

            var positions = mapper.Map<ICollection<RegisterEmployeeViewModel>>(positionsIdDto).ToList();

            return this.View(positions);
        }

        [HttpPost]
        public IActionResult Register(RegisterEmployeeInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Error", "Home");
            }

            var employeeDto = mapper.Map<CreateEmployeeDTO>(model);

            employeeService.Create(employeeDto);

            return RedirectToAction("All");
        }

        public IActionResult All()
        {
            var employeesDto = employeeService.GetAll();

            var employees = mapper
                .Map< ICollection<AllEmployeeDTO>,
                ICollection <EmployeesAllViewModel>>(employeesDto)
                .ToList();

            return this.View(employees);
        }

        private int ICollection<T>(ICollection<AllEmployeeDTO> employeesDto)
        {
            throw new NotImplementedException();
        }
    }
}
