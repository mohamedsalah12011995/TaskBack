using System;
using AutoMapper;
using MyTaskData;

namespace MyTaskDomain
{
    public class BaseService
    {
        public MyTaskDbContext dbcontext { set; get; }
        public IMapper mapper { set; get; }

    }
}
