
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MyTaskData;
using MyTaskData.Entities;
using MyTaskDomain;
using MyTaskDomain.DTO;
using MyTaskService.Interfaces;

namespace MyTaskService.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        public EmployeeService(IMapper _mapper, MyTaskDbContext _dbContext )
        {
            mapper = _mapper;
            dbcontext = _dbContext;
        }

        public EmployeeDTO GetEmployee(int Id)
        {
            var Employees = dbcontext.Employees.FirstOrDefault(f => f.Id == Id);
            ///cast entities to DTO 
            var EmployeeDTO = mapper.Map<EmployeeDTO>(Employees);
            ///return DTO 
            return EmployeeDTO;
        }

        public List<EmployeeDTO> GetEmployees()
        {
            var Employees = dbcontext.Employees.ToList();
            ///cast entities to DTO 
            var EmployeesDTO = mapper.Map<List<EmployeeDTO>>(Employees);
            ///return DTO 
            return EmployeesDTO;
        }

        public EmployeeDTO InsertOrUpdateEmployee(EmployeeDTO employeeDTO)
        {
            if (employeeDTO.Id > 0)  ///Update Employee 
            {
                ///Get employee entity from database by id 
                var _Employee = dbcontext.Employees.Find(employeeDTO.Id);
                if (_Employee != null)   ///if Exist 
                {

                    try
                    {
                        ///Mapp new values from employeeDTO to Employee 
                        var mapped_Employee = mapper.Map<EmployeeDTO, Employee>(employeeDTO, _Employee);
                        dbcontext.Employees.Update(mapped_Employee);
                        dbcontext.SaveChanges();

                        //  return true;
                        return employeeDTO;
                    }
                    catch (Exception x)
                    {
                        return null;
                    }


                }
                else { return null; }
            }
            else
            {
                try
                {
                    var mappedEmployee = mapper.Map<Employee>(employeeDTO);
                    dbcontext.Employees.Add(mappedEmployee);
                    dbcontext.SaveChanges();
                    // return inserted object ;
                    return employeeDTO;
                }
                catch (Exception e)
                {
                    return null;
                    //return false; 
                }
            }
        }

        public bool RemoveEmployee(int Id)
        {
            try
            {
                ///get obj for delete 
                var Employee = dbcontext.Employees.Find(Id);

                ///remove obj from db context 
                dbcontext.Employees.Remove(Employee);

                ///save changes on database 
                dbcontext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
