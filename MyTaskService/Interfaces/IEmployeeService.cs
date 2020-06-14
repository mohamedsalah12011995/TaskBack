using MyTaskDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskService.Interfaces
{
   public interface IEmployeeService
    {
        List<EmployeeDTO> GetEmployees();
        EmployeeDTO GetEmployee(int Id);
        EmployeeDTO InsertOrUpdateEmployee(EmployeeDTO employeeDTO);
        bool RemoveEmployee(int Id);
    }
}
