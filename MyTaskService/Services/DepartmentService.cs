
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
    public class DepartmentService : BaseService, IDepartmentService
    {
        public DepartmentService(IMapper _mapper, MyTaskDbContext _dbContext)
        {

            mapper = _mapper;
            dbcontext = _dbContext;
        }

        public DepartmentDTO GetDepartment(int Id)
        {
            var Department = dbcontext.Departments.FirstOrDefault(f => f.Id == Id);
            ///cast entities to DTO 
            var DepartmentDTO = mapper.Map<DepartmentDTO>(Department);
            ///return DTO 
            return DepartmentDTO;
        }

        public List<DepartmentDTO> GetDepartments()
        {
            var Department = dbcontext.Departments.ToList();
            ///cast entities to DTO 
            var DepartmentDTO = mapper.Map<List<DepartmentDTO>>(Department);
            ///return DTO 
            return DepartmentDTO;
        }

        public DepartmentDTO InsertOrUpdateDepartment(DepartmentDTO departmentDTO)
        {
            if (departmentDTO.Id > 0)  ///Update Department 
            {
                ///Get Department entity from database by id 
                var _Department = dbcontext.Departments.Find(departmentDTO.Id);
                if (_Department != null)   ///if Exist 
                {

                    try
                    {
                        ///Mapp new values from DepartmentDTO to Department 
                        var mapped_Department = mapper.Map<DepartmentDTO, Department>(departmentDTO, _Department);
                        dbcontext.Departments.Update(mapped_Department);
                        dbcontext.SaveChanges();

                        //  return true;
                        return departmentDTO;
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
                    var mappedDepartment = mapper.Map<Department>(departmentDTO);
                    dbcontext.Departments.Add(mappedDepartment);
                    dbcontext.SaveChanges();
                    // return inserted object ;
                    return departmentDTO;
                }
                catch (Exception e)
                {
                    return null;
                    //return false; 
                }
            }
        }

        public bool RemoveDepartment(int Id)
        {
            try
            {
                ///get obj for delete 
                var Department = dbcontext.Departments.Find(Id);

                ///remove obj from db context 
                dbcontext.Departments.Remove(Department);

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
