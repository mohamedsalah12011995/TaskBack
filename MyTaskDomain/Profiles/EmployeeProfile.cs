using AutoMapper;
using MyTaskData.Entities;
using MyTaskDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskDomain.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
