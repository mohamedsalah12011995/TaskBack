using AutoMapper;
using MyTaskData.Entities;
using MyTaskDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskDomain.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO, Department>();
        }
    }
}
