using AutoMapper;
using MyTaskData.Entities;
using MyTaskDomain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTaskDomain.Profiles
{
    public class JobProfile : Profile
    {
        public JobProfile()
        {
            CreateMap<Job, JobDTO>();
            CreateMap<JobDTO, Job>();
        }
    }
}
