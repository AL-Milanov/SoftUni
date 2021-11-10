using FastFood.Services.DTO.Employee;
using System.Collections.Generic;

namespace FastFood.Services.Interfaces
{
    public interface IEmployeeService
    {
        void Create(CreateEmployeeDTO employeeDto);

        ICollection<EmployeePositionsIdDTO> GetPositionsDTO();

        ICollection<AllEmployeeDTO> GetAll();
    }
}
