using MyTaskDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskService.Interfaces
{
   public interface IDepartmentService
    {
        List<DepartmentDTO> GetDepartments();
        DepartmentDTO GetDepartment(int Id);
        DepartmentDTO InsertOrUpdateDepartment(DepartmentDTO departmentDTO);
        bool RemoveDepartment(int Id);
    }
}
